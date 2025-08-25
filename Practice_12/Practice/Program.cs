using System.Collections;

namespace Practice
{
    internal class Program
    {
        /* Task_2 */
        public static class ValueValidator
        {
            public static void EnsureIsDouble(object value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Значение не может быть null");

                if (!(value is double))
                    throw new InvalidValueTypeException(value.GetType());
            }
        }

        public class InvalidCollectionIndexException : Exception
        {
            public int Index { get; }
            public int CollectionSize { get; }

            public InvalidCollectionIndexException(int index, int collectionSize)
                : base($"Недопустимый индекс: {index}. Коллекция содержит {collectionSize} элементов.")
            {
                Index = index;
                CollectionSize = collectionSize;
            }
        }

        public class ReplacementSizeMismatchException : Exception
        {
            public int AvailableSpace { get; }
            public int ReplacementLength { get; }

            public ReplacementSizeMismatchException(int availableSpace, int replacementLength)
                : base($"Несоответствие размеров: доступно {availableSpace} элементов, попытка замены {replacementLength} элементами.")
            {
                AvailableSpace = availableSpace;
                ReplacementLength = replacementLength;
            }
        }

        public class ElementNotFoundException : Exception
        {
            public object SearchedValue { get; }

            public ElementNotFoundException(object value)
                : base($"Элемент '{value}' не найден в коллекции")
            {
                SearchedValue = value;
            }
        }

        public class InvalidCollectionRangeException : Exception
        {
            public int StartIndex { get; }
            public int RemoveCount { get; }
            public int CollectionSize { get; }

            public InvalidCollectionRangeException(int start, int count, int size)
                : base($"Недопустимый диапазон: индекс начала {start}, количество {count}. " +
                       $"Коллекция содержит {size} элементов.")
            {
                StartIndex = start;
                RemoveCount = count;
                CollectionSize = size;
            }
        }

        public class InsufficientArraySizeException : Exception
        {
            public int RequiredSize { get; }
            public int ActualSize { get; }
            public int CollectionSize { get; }

            public InsufficientArraySizeException(int required, int actual, int collectionSize)
                : base($"Недостаточно места в массиве: требуется {required} элементов, " +
                       $"доступно {actual}. Коллекция содержит {collectionSize} элементов.")
            {
                RequiredSize = required;
                ActualSize = actual;
                CollectionSize = collectionSize;
            }
        }

        public class InvalidValueTypeException : Exception
        {
            public Type ActualType { get; }

            public InvalidValueTypeException(Type actualType)
                : base($"Недопустимый тип значения: {actualType.Name}. Ожидается Double.")
            {
                ActualType = actualType;
            }
        }


        /* Task_3 */
        public static double ProcessArrayList(ref ArrayList list)
        {
            double sum = 0;

            foreach (double item in list)
            {
                sum += item;
            }

            double average = sum / list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToDouble(list[i]) < average)
                {
                    list[i] = 0.0;
                }
            }

            return average;
        }


        /* Task_1 */
        public static void ArrayListDemo()
        {
            ArrayList list = new ArrayList();
            double[] arr = new double[5];

            Console.WriteLine("~~~~~~~~~~~~~~~~~~ МАССИВ - СПИСОК(ARRAYLIST) ~~~~~~~~~~~~~~~~~~\n");

            // 0. Initial
            Console.WriteLine("===== INITIAL STATE =====");
            Console.WriteLine($"Initial: Count={list.Count}, Capacity={list.Capacity}");
            Console.WriteLine($"Is fixed size: {list.IsFixedSize}");
            Console.WriteLine($"Is read-only: {list.IsReadOnly}");
            Console.WriteLine($"Is synchronized: {list.IsSynchronized}");
            Console.WriteLine($"SyncRoot: {list.SyncRoot}\n");

            // 1. Добавление элементов
            Console.WriteLine("\n===== ADDING ELEMENTS =====");
            list.Add(0.3);
            list.Add(1.2);
            list.Add(1.3);
            Console.WriteLine($"After initial Add(): Count={list.Count}, Capacity={list.Capacity}");
            foreach (double d in list) Console.WriteLine(d);

            try
            {
                int insertIndex = 0;

                // Проверяем возможность вставки
                if (insertIndex < 0 || insertIndex > list.Count)
                {
                    throw new InvalidCollectionIndexException(insertIndex, list.Count);
                }

                list.Insert(insertIndex, 0.4);
                Console.WriteLine($"After Insert(): Count={list.Count}, Capacity={list.Capacity}");
                foreach (double d in list) Console.WriteLine(d);
            }
            catch (InvalidCollectionIndexException ex)
            {
                Console.WriteLine($"Ошибка Insert: \"{ex.Message}\"");
            }

            list.AddRange(new double[] { 1.1, 0.1 });
            Console.WriteLine($"After AddRange(): Count={list.Count}, Capacity={list.Capacity}");
            foreach (double d in list) Console.WriteLine(d);

            list.InsertRange(0, new double[] { 11.1, 0.2 });
            Console.WriteLine($"After InsertRange(): Count={list.Count}, Capacity={list.Capacity}");
            foreach (double d in list) Console.WriteLine(d);

            // 2. Удаление элементов
            Console.WriteLine("\n===== REMOVING ELEMENTS =====");
            Console.WriteLine($"Before removal: Count={list.Count}, Capacity={list.Capacity}");
            foreach (double d in list) Console.WriteLine(d);

            list.Remove(11.1);
            Console.WriteLine($"After Remove(): Count={list.Count}, Capacity={list.Capacity}");
            foreach (double d in list) Console.WriteLine(d);

            try
            {
                int RemoveAtIndex = 0;
                if (RemoveAtIndex < 0 || RemoveAtIndex > list.Count)
                {
                    throw new InvalidCollectionIndexException(RemoveAtIndex, list.Count);
                }
                list.RemoveAt(RemoveAtIndex);
            }
            catch (InvalidCollectionIndexException ex)
            {
                Console.WriteLine($"Ошибка RemoveAt: \"{ex.Message}\"");
            }

            try
            {
                int startIndex = 0;
                int removeCount = 1;

                if (startIndex < 0 || startIndex >= list.Count)
                {
                    throw new InvalidCollectionIndexException(startIndex, list.Count);
                }

                int availableCount = list.Count - startIndex;
                if (removeCount > availableCount)
                {
                    throw new InvalidCollectionRangeException(startIndex, removeCount, list.Count);
                }

                list.RemoveRange(startIndex, removeCount);
            }
            catch (InvalidCollectionIndexException ex)
            {
                Console.WriteLine($"Ошибка RemoveRange: \"{ex.Message}\"");
            }
            catch (InvalidCollectionRangeException ex)
            {
                Console.WriteLine($"Ошибка RemoveRange: \"{ex.Message}\"");
            }

            // 3. Изменение порядка
            Console.WriteLine("\n===== REORDERING ELEMENTS =====");
            list.Reverse();
            Console.WriteLine("After Reverse()");
            foreach (double d in list) Console.WriteLine(d);

            list.Sort();
            Console.WriteLine("After Sort()");
            foreach (double d in list) Console.WriteLine(d);

            // 4. Поиск элементов
            Console.WriteLine("\n===== SEARCH OPERATIONS =====");
            Console.WriteLine($"- Index of 1.1: {list.IndexOf(1.1)}");
            Console.WriteLine($"- Last index of 1.1: {list.LastIndexOf(1.1)}");
            Console.WriteLine($"- list[0]: {list[0]}");

            try
            {
                ArrayList array = new ArrayList();
                array.BinarySearch(1);
                object value = 1.3;
                double result = list.BinarySearch(value);

                if (result < 0)
                {
                    throw new ElementNotFoundException(value);
                }
                else
                {
                    Console.WriteLine($"- BinarySearch: ({value}): {result}");
                }
            }
            catch (ElementNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: \"{ex.Message}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 5. Замена элементов
            Console.WriteLine("\n===== REPLACING ELEMENTS =====");
            try
            {
                int startIndex = 0;
                double[] newValues = { 0.9, 1.0, 1.1 };

                if (startIndex < 0 || startIndex >= list.Count)
                {
                    throw new InvalidCollectionIndexException(startIndex, list.Count);
                }

                int availableSpace = list.Count - startIndex;
                if (newValues.Length > availableSpace)
                {
                    throw new ReplacementSizeMismatchException(availableSpace, newValues.Length);
                }

                list.SetRange(startIndex, newValues);
                Console.WriteLine("После SetRange:");
                foreach (double d in list) Console.WriteLine(d);
            }
            catch (InvalidCollectionIndexException ex)
            {
                Console.WriteLine($"Ошибка: \"{ex.Message}\"");
            }
            catch (ReplacementSizeMismatchException ex)
            {
                Console.WriteLine($"Ошибка: \"{ex.Message}\"");
            }

            // 6. Работа с диапазонами
            Console.WriteLine("\n===== RANGE OPERATIONS =====");
            ArrayList range = list.GetRange(0, 2);
            Console.WriteLine("GetRange(index=0, count=2):");
            foreach (double item in range) Console.WriteLine(item);

            // 7. Копирование в массив
            Console.WriteLine("\n===== COPY OPERATION =====");
            Console.WriteLine("Before CopyTo():");
            for (int i = 0; i < arr.Length; i++) Console.WriteLine($"[{i}]: {arr[i]}");

            try
            {
                int requiredSpace = list.Count - 0;
                if (requiredSpace > arr.Length)
                {
                    throw new InsufficientArraySizeException(requiredSpace, arr.Length, list.Count);
                }

                list.CopyTo(arr, 0);

                Console.WriteLine("After CopyTo():");
                for (int i = 0; i < arr.Length; i++) Console.WriteLine($"[{i}]: {arr[i]}");
            }
            catch (InsufficientArraySizeException ex)
            {
                Console.WriteLine($"Ошибка CopyTo: \"{ex.Message}\"");
            }

            // 8. Очистка и проверка
            Console.WriteLine("\n===== CLEAR & VERIFY =====");

            Console.WriteLine("Before ProcessArrayList():");
            foreach (double d in list) Console.WriteLine(d);
            ProcessArrayList(ref list);
            Console.WriteLine("After ProcessArrayList():");
            foreach (double d in list) Console.WriteLine(d);

            Console.WriteLine($"Contains 1.1 before Clear(): {list.Contains(1.1)}");
            list.Clear();
            Console.WriteLine($"Contains 1.1 after Clear(): {list.Contains(1.1)}");

            Console.WriteLine($"After clear: Count={list.Count}, Capacity={list.Capacity}");

            Console.WriteLine($"Before TrimToSize(): Capacity={list.Capacity}");
            list.TrimToSize();
            Console.WriteLine($"After TrimToSize(): Capacity={list.Capacity}");
        }

        public static void QueueDemo()
        {
            Queue queue = new Queue();

            Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~ ОЧЕРЕДЬ (QUEUE) ~~~~~~~~~~~~~~~~~~\n");

            Console.WriteLine("===== QUEUE CORE PROPERTIES =====");
            Console.WriteLine($"Initial Count: {queue.Count}");
            Console.WriteLine($"IsSynchronized: {queue.IsSynchronized}");
            Console.WriteLine($"SyncRoot: {queue.SyncRoot}\n");

            //1.Добавление элементов
            try
            {
                object value1 = 1.1;
                ValueValidator.EnsureIsDouble(value1);
                queue.Enqueue(value1);

                object value2 = 2.1;
                ValueValidator.EnsureIsDouble(value2);
                queue.Enqueue(value2);

                object value3 = 3.1;
                ValueValidator.EnsureIsDouble(value3);
                queue.Enqueue(value3);

                object value4 = 4.1;
                ValueValidator.EnsureIsDouble(value4);
                queue.Enqueue(value4);

                object value5 = 999; // здесь будет исключение
                ValueValidator.EnsureIsDouble(value5);
                queue.Enqueue(value5);

                PrintQueue();
            }
            catch (InvalidValueTypeException ex)
            {
                Console.WriteLine($"Ошибка: \"{ex.Message}\"");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка: \"{ex.Message}\"");
            }

            // 2. Демонстрация ToArray()
            Console.WriteLine("===== TOARRAY() DEMONSTRATION =====");
            object?[] arrayFromQueue = queue.ToArray();
            Console.WriteLine("ToArray result:");
            for (int i = 0; i < arrayFromQueue.Length; i++)
            {
                Console.WriteLine($"[{i}]: {arrayFromQueue[i]}");
            }
            Console.WriteLine();

            // 3. Копирование в массив
            try
            {
                double[] queueArray = new double[queue.Count - 1]; // Намеренно маленький массив
                Console.WriteLine("Новый массив ДО CopyTo():");
                for (int i = 0; i < queueArray.Length; i++) Console.WriteLine($"[{i}]: {queueArray[i]}");
                Console.WriteLine();

                // Проверяем возможность копирования
                int requiredSpace = queue.Count - 0; // От начального индекса 0
                if (requiredSpace > queueArray.Length)
                {
                    throw new InsufficientArraySizeException(requiredSpace, queueArray.Length, queue.Count);
                }

                queue.CopyTo(queueArray, 0);

                Console.WriteLine("Новый массив ПОСЛЕ CopyTo():");
                for (int i = 0; i < queueArray.Length; i++)
                {
                    Console.WriteLine($"[{i}]: {queueArray[i]}");
                }
                Console.WriteLine();
            }
            catch (InsufficientArraySizeException ex)
            {
                Console.WriteLine($"Ошибка копирования: \"{ex.Message}\"");
            }

            // 4. Работа с элементами
            while (queue.Count > 0)
            {
                Console.WriteLine($"firstNum: {queue.Peek()}");
                PrintQueue();

                var num = queue.Dequeue();
                Console.WriteLine($"Dequeue: {num} =>");
                PrintQueue();
            }

            // 5. Очистка очереди
            Console.WriteLine("===== CLEAR() DEMONSTRATION =====");
            queue.Enqueue(0.1);
            Console.WriteLine($"Before Clear: Count={queue.Count}");
            queue.Clear();
            Console.WriteLine($"After Clear: Count={queue.Count}");
            PrintQueue();

            void PrintQueue()
            {
                Console.Write("Queue: ");
                foreach (var item in queue) Console.Write(item + " ");
                Console.WriteLine($"\nCount: {queue.Count}\n");
            }
        }

        public static void HashTableDemo()
        {
            Hashtable table = new Hashtable();

            Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~ Hashtable ~~~~~~~~~~~~~~~~~~\n");

            Console.WriteLine($"Count: {table.Count}");
            Console.WriteLine($"IsFixedSize: {table.IsFixedSize}");
            Console.WriteLine($"IsReadOnly: {table.IsReadOnly}");
            Console.WriteLine($"IsSynchronized table: {table.IsSynchronized}");
            Console.WriteLine($"SyncRoot: {table.SyncRoot}\n");

            try
            {
                object value1 = 1.1;
                ValueValidator.EnsureIsDouble(value1);
                table.Add("key1", value1);

                object value2 = 2.2;
                ValueValidator.EnsureIsDouble(value2);
                table["key2"] = value2;

                // Намеренно добавляем неверное значение
                object invalidValue = 42; // int вместо double
                ValueValidator.EnsureIsDouble(invalidValue);
                table.Add("key3", invalidValue);
            }
            catch (InvalidValueTypeException ex)
            {
                Console.WriteLine($"Ошибка типа: \"{ex.Message}\"");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка дубликата: \"{ex.Message}\"");
            }

            Console.WriteLine("\nKeys:");
            foreach (var key in table.Keys) Console.WriteLine(key);
            Console.WriteLine("\nValues:");
            foreach (var key in table.Values) Console.WriteLine(key);

            Hashtable clone = (Hashtable)table.Clone();
            Console.WriteLine("\nClone count: " + clone.Count);

            Console.WriteLine("Contains 'key2': " + table.Contains("key2"));
            Console.WriteLine("ContainsKey 'key2': " + table.ContainsKey("key2"));
            Console.WriteLine("ContainsValue 'key2': " + table.ContainsValue(2.2));

            DictionaryEntry[] entries = new DictionaryEntry[table.Count];
            table.CopyTo(entries, 0);
            Console.WriteLine("\nCopied array:");
            foreach (var entry in entries) Console.WriteLine($"{entry.Key}: {entry.Value}");

            Console.WriteLine("\nHashTable:");
            IDictionaryEnumerator enumerator = table.GetEnumerator();
            while (enumerator.MoveNext()) Console.WriteLine($"{enumerator.Key}: {enumerator.Value}");
            Console.WriteLine($"Count: {table.Count}");

            table.Remove("key1");
            Console.WriteLine("\nAfter remove:");
            PrintHashtable(table);

            table.Clear();
            Console.WriteLine("After Clear():");
            PrintHashtable(table);

            void PrintHashtable(Hashtable table)
            {
                foreach (DictionaryEntry entry in table)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
                Console.WriteLine($"Count: {table.Count}\n");
            }
        }


        /* Task_4 */
        public static void CheckRoundBrackets()
        {
            Stack stack = new Stack();

            Console.WriteLine("~~~~~~~~~~~~~~~ СТЕК (STACK) ~~~~~~~~~~~~~~~");

            Console.WriteLine("Введите строку со скобками:");
            string input = Console.ReadLine();

            foreach (char ch in input)
            {

                if (ch == '(')
                {
                    if (stack.Contains('('))
                        Console.WriteLine("Стек содержит открывающую скобку '('");

                    stack.Push(ch);
                    Console.WriteLine("Push: '(' добавлен в стек. Кол-во элементов: " + stack.Count);
                }
                else if (ch == ')')
                {
                    if (!stack.Contains('('))
                        Console.WriteLine("В стеке нет открывающей скобки '('");

                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Ошибка: Лишний ')'");
                        Console.WriteLine("FINAL: " + stack.Count + " - скобочная структура неправильная");
                        return;
                    }

                    Console.WriteLine("Peek: Вершина стека перед Pop: " + stack.Peek());
                    stack.Pop();
                    Console.WriteLine("Pop: удалена открывающая скобка. Осталось элементов: " + stack.Count);

                    // ToArray — показываем содержимое стека (если что-то осталось)
                    object[] arr = stack.ToArray();
                    Console.Write("Текущее содержимое стека: ");
                    foreach (var item in arr)
                        Console.Write(item + " ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Пропущен символ '{ch}', не являющийся скобкой.");
                }
            }

            if (stack.Count == 0)
                Console.WriteLine("FINAL: " + stack.Count + " - скобочная структура правильная");
            else
                Console.WriteLine("FINAL: " + stack.Count + " - скобочная структура неправильная");

            // Clear — очищаем стек
            stack.Clear();
            Console.WriteLine("Стек очищен. Размер теперь: " + stack.Count);
        }


        /* Task_5 */
        public class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int Course { get; set; }
            public int MathGrades { get; set; }
            public int PhysicsGrades { get; set; }
            public int Informatics { get; set; }

            public Student(string lastname, string firstname, int course, int math, int physics, int informatics)
            {
                LastName = lastname;
                FirstName = firstname;
                Course = course;
                MathGrades = math;
                PhysicsGrades = physics;
                Informatics = informatics;
            }
        }

        public static void StudentQueue()
        {
            Queue queue = new Queue();

            Student student1 = new Student("Иванов", "Иван", 1, 5, 4, 3);
            Student student2 = new Student("Петров", "Пётр", 2, 4, 3, 5);
            Student student3 = new Student("Смирнова", "Анна", 3, 5, 5, 4);
            Student student4 = new Student("Кузнецов", "Алексей", 1, 3, 2, 4);
            Student student5 = new Student("Волкова", "Елена", 4, 4, 4, 5);
            Student student6 = new Student("Соколов", "Николай", 2, 3, 3, 3);
            Student student7 = new Student("Морозова", "Мария", 3, 5, 5, 5);

            queue.Enqueue(student1);
            queue.Enqueue(student2);
            queue.Enqueue(student3);
            queue.Enqueue(student4);
            queue.Enqueue(student5);
            queue.Enqueue(student6);
            queue.Enqueue(student7);

            Console.WriteLine($"Сейчас в очереди: {queue.Count} студентов");

            Student[] studentArray = new Student[queue.Count];
            Console.WriteLine("\nСодержимое массива ДО CopyTo():");
            queue.CopyTo(studentArray, 0);

            Console.WriteLine("\nСодержимое массива ПОСЛЕ CopyTo():");
            foreach (var s in studentArray)
            {
                Console.WriteLine($"{s.LastName} {s.FirstName}, курс: {s.Course}");
            }

            Student firstStudent = (Student)queue.Peek();
            Console.WriteLine($"\nПервый студент: {firstStudent.LastName}");

            Console.WriteLine($"Иванов в очереди: {queue.Contains(student1)}");

            object[] array = queue.ToArray();
            Console.WriteLine($"\nОчередь преобразована в массив из {array.Length} студентов");

            Queue clone = (Queue)queue.Clone();
            Console.WriteLine($"Создан клон очереди. Содержит: {clone.Count} студентов");

            clone.Clear();
            Console.WriteLine($"Клон очереди очищен. Содержит: {clone.Count} студентов");

            Student studentWorst = null;
            double ratingStudentWorst = 5;

            while (queue.Count > 0)
            {
                Student student = (Student)queue.Dequeue(); ;

                double rating = (student.MathGrades + student.PhysicsGrades + student.Informatics) / 3.0;

                if (student.Course == 2)
                {
                    if (rating < ratingStudentWorst)
                    {
                        studentWorst = student;
                        ratingStudentWorst = rating;
                    }
                }

                Console.WriteLine($"\n{student.LastName} {student.FirstName}\nКурс: {student.Course}\nОценка: {rating:F2}");
            }

            Console.WriteLine($"\n~~~~~ Худший Студент ~~~~~\n{studentWorst.LastName} {studentWorst.FirstName}\nКурс: {studentWorst.Course}\nОценка: {ratingStudentWorst:F2}\n");
        }


        /* Task_6.1 - Task_6.2 */
        public class Person
        {
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class NewStudent : Person
        {
            public Person BasePerson { get; }

            public NewStudent(Person person)
            {
                BasePerson = person;
                Name = person.Name;
            }
        }


        /* Task_6.3 - Task_6.6 */
        public class TestCollections
        {
            public List<Person> BaseItems { get; set; }
            public List<string> StringItems { get; set; }
            public Dictionary<Person, NewStudent> BaseToDerived { get; set; }
            public Dictionary<string, NewStudent> StringToDerived { get; set; }

            public TestCollections(int length)
            {
                BaseItems = new List<Person>();
                StringItems = new List<string>();
                BaseToDerived = new Dictionary<Person, NewStudent>();
                StringToDerived = new Dictionary<string, NewStudent>();

                for (int i = 0; i < length; i++)
                {
                    Person person = new Person { Name = $"Person{i}" };
                    BaseItems.Add(person);

                    string key = person.ToString();
                    StringItems.Add(key);

                    NewStudent student = new NewStudent(person);

                    BaseToDerived.Add(student.BasePerson, student);

                    StringToDerived.Add(key, student);
                }
            }
        }


        /* Task_6.7 */
        static void SearchTime<T>(ICollection<T> collection, T item, string description)
        {
            var start = DateTime.Now;
            bool found = collection.Contains(item);
            var end = DateTime.Now;
            double elapsedMs = (end - start).TotalMilliseconds;
            Console.WriteLine($"{description}: найден={found}, время поиска = {elapsedMs} мс");
        }

        static void Main(string[] args)
        {
            //ArrayListDemo();
            //QueueDemo();
            //HashTableDemo();
            //CheckRoundBrackets();
            //StudentQueue();

            TestCollections testCollections = new TestCollections(10);

            Console.WriteLine("\nQueue1 (Базовые объекты):");
            foreach (var person in testCollections.BaseItems)
            {
                Console.WriteLine($"- {person.Name}");
            }

            Console.WriteLine("\nQueue2 (Строковые ключи):");
            foreach (var str in testCollections.StringItems)
            {
                Console.WriteLine($"- {str}");
            }

            Console.WriteLine("\nQueue3 (Пары [Person → Student]):");
            foreach (var pair in testCollections.BaseToDerived)
            {
                Console.WriteLine($"- Ключ: {pair.Key.Name}, Значение: {pair.Value.Name}");
            }

            Console.WriteLine("\nQueue4 (Пары [string → Student]):");
            foreach (var pair in testCollections.StringToDerived)
            {
                Console.WriteLine($"- Ключ: {pair.Key}, Значение: {pair.Value.Name}");
            }

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~ SearchTime ~~~~~~~~~~~~~~~~~~\n");

            var warmup = DateTime.Now;

            int length = 1000;
            TestCollections testCollections2 = new TestCollections(length);

            var firstKey = testCollections2.BaseItems[0];
            var middleKey = testCollections2.BaseItems[length / 2];
            var lastKey = testCollections2.BaseItems[length - 1];
            var notExistKey = new Person { Name = "NotExist" };

            var firstStr = testCollections2.StringItems[0];
            var middleStr = testCollections2.StringItems[length / 2];
            var lastStr = testCollections2.StringItems[length - 1];
            var notExistStr = "NotExist";

            var firstValue = testCollections2.BaseToDerived[firstKey];
            var middleValue = testCollections2.BaseToDerived[middleKey];
            var lastValue = testCollections2.BaseToDerived[lastKey];
            var notExistValue = new NewStudent(notExistKey);

            // List<Person>
            SearchTime(testCollections2.BaseItems, firstKey, "List<Person> - Первый");
            SearchTime(testCollections2.BaseItems, middleKey, "List<Person> - Центральный");
            SearchTime(testCollections2.BaseItems, lastKey, "List<Person> - Последний");
            SearchTime(testCollections2.BaseItems, notExistKey, "List<Person> - Не существует");

            Console.WriteLine();

            // List<string>
            SearchTime(testCollections2.StringItems, firstStr, "List<string> - Первый");
            SearchTime(testCollections2.StringItems, middleStr, "List<string> - Центральный");
            SearchTime(testCollections2.StringItems, lastStr, "List<string> - Последний");
            SearchTime(testCollections2.StringItems, notExistStr, "List<string> - Не существует");

            Console.WriteLine();

            // Dictionary<Person, NewStudent> - ContainsKey
            SearchTime(testCollections2.BaseToDerived.Keys, firstKey, "Dict<Person,Student>.Keys - Первый");
            SearchTime(testCollections2.BaseToDerived.Keys, middleKey, "Dict<Person,Student>.Keys - Центральный");
            SearchTime(testCollections2.BaseToDerived.Keys, lastKey, "Dict<Person,Student>.Keys - Последний");
            SearchTime(testCollections2.BaseToDerived.Keys, notExistKey, "Dict<Person,Student>.Keys - Не существует");

            Console.WriteLine();

            // Dictionary<string, NewStudent> - ContainsKey
            SearchTime(testCollections2.StringToDerived.Keys, firstStr, "Dict<string,Student>.Keys - Первый");
            SearchTime(testCollections2.StringToDerived.Keys, middleStr, "Dict<string,Student>.Keys - Центральный");
            SearchTime(testCollections2.StringToDerived.Keys, lastStr, "Dict<string,Student>.Keys - Последний");
            SearchTime(testCollections2.StringToDerived.Keys, notExistStr, "Dict<string,Student>.Keys - Не существует");

            Console.WriteLine();

            // Dictionary<Person, NewStudent> - ContainsValue
            SearchTime(testCollections2.BaseToDerived.Values, firstValue, "Dict<Person,Student>.Values - Первый");
            SearchTime(testCollections2.BaseToDerived.Values, middleValue, "Dict<Person,Student>.Values - Центральный");
            SearchTime(testCollections2.BaseToDerived.Values, lastValue, "Dict<Person,Student>.Values - Последний");
            SearchTime(testCollections2.BaseToDerived.Values, notExistValue, "Dict<Person,Student>.Values - Не существует");
        }
    }
}
