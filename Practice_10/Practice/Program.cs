namespace Practice
{
    public static class Program
    {
        // Taak 1
        class State
        {
            public decimal Population { get; set; }
            public decimal Area { get; set; }

            public static State operator +(State a, State b)
            {
                return new State
                {
                    Population = a.Population + b.Population,
                    Area = a.Area + b.Area
                };
            }

            public static bool operator >(State a, State b)
            {
                return a.Population > b.Population;
            }

            public static bool operator <(State a, State b)
            {
                return a.Population < b.Population;
            }
        }


        // Task 2
        class Bread
        {
            public int Weight { get; set; }

            public static Sandwich operator +(Bread a, Butter b)
            {
                return new Sandwich { Weight = a.Weight + b.Weight };
            }
        }

        class Butter
        {
            public int Weight { get; set; }
        }

        class Sandwich
        {
            public int Weight { get; set; }
        }


        // Task 3
        class Field
        {
            public int intField { get; set; }
            public string strField { get; set; }

            public static bool operator >(Field a, Field b)
            {
                return a.strField.Length > b.strField.Length;
            }

            public static bool operator <(Field a, Field b)
            {
                return a.strField.Length < b.strField.Length;
            }

            public static bool operator <=(Field a, Field b)
            {
                return a.intField <= b.intField;
            }

            public static bool operator >=(Field a, Field b)
            {
                return a.intField >= b.intField;
            }

            public static bool operator ==(Field a, Field b)
            {
                return a.intField == b.intField && a.strField == b.strField;
            }

            public static bool operator !=(Field a, Field b)
            {
                return !(a == b);
            }

            public override bool Equals(object obj)
            {
                Field other = (Field)obj;
                return this == other;
            }

            public override int GetHashCode()
            {
                return intField.GetHashCode() ^ strField.GetHashCode();
            }
        }


        // Task 4 
        class TaskFour
        {
            public int num { get; set; }


            public static TaskFour operator &(TaskFour a, TaskFour b)
            {
                // Если a истинный, проверяем b, иначе возвращаем ложный объект (num=0)
                if (a)
                {
                    if (b)
                        return b;
                    else
                        return new TaskFour { num = 0 };
                }
                else
                {
                    return new TaskFour { num = 0 };
                }
            }

            public static TaskFour operator |(TaskFour a, TaskFour b)
            {
                if (a)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            }

            public static bool operator false(TaskFour a)
            {
                return a.num < 1 || a.num > 10;
            }

            public static bool operator true(TaskFour a)
            {
                return a.num == 2 || a.num == 3 || a.num == 5 || a.num == 7;
            }
        }


        // Task 5
        class Clock
        {
            public int Hours { get; set; }

            public static implicit operator Clock(int a)
            {
                if (a < 0) a += 24;
                return new Clock { Hours = a };
            }

            public static explicit operator int(Clock clock)
            {
                return clock.Hours;
            }
        }


        // Task 6
        class Celcius
        {
            public double Gradus { get; set; }
        }

        class Fahrenheit
        {
            public double Gradus { get; set; }

            public static implicit operator Fahrenheit(Celcius Tc)
            {
                double Tf = 9.0 / 5.0 * Tc.Gradus + 32;
                return new Fahrenheit { Gradus = Tf };
            }

            public static explicit operator Celcius(Fahrenheit Tf)
            {
                double Tc = 5.0 / 9.0 * (Tf.Gradus - 32);
                return new Celcius { Gradus = Tc };
            }
        }


        // Task 7
        class Dollar
        {
            public decimal Sum { get; set; }
        }

        class Euro
        {
            public decimal Sum { get; set; }

            public static implicit operator Euro(Dollar dollar)
            {
                // 1 euro = 1.14 usd
                decimal price = 1.14m;
                return new Euro { Sum = dollar.Sum / price };
            }

            public static explicit operator Dollar(Euro euro)
            {
                decimal price = 1.14m;
                return new Dollar { Sum = euro.Sum * price };
            }
        }


        // Task 8
        class TextObject
        {
            public string Text { get; set; }

            public static explicit operator int(TextObject obj)
            {
                return obj.Text.Length;
            }

            public static explicit operator char(TextObject obj)
            {
                return obj.Text[0];
            }

            public static implicit operator TextObject(int num)
            {
                return new TextObject { Text = new string('A', num) };
            }
        }

        public static void Main()
        {
            // Task 1
            Console.WriteLine("~~~~~ Task 1 ~~~~~");
            State state1 = new State { Population = 100000000, Area = 500000 };
            State state2 = new State { Population = 70000000, Area = 250000 };
            State state3 = state1 + state2;
            bool isGreater = state1 > state2;
            Console.WriteLine(state3.Population);
            Console.WriteLine(isGreater);


            // Task 2
            Console.WriteLine("~~~~~ Task 2 ~~~~~");
            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight);


            // Task 3
            Console.WriteLine("~~~~~ Task 3 ~~~~~");
            Field field1 = new Field { intField = 60, strField = "hello" };
            Field field2 = new Field { intField = 60, strField = "world" };
            bool isEqually = field1 == field2;
            bool isNotEqually = field1 != field2;
            bool isGreaterOrEqual = field1 >= field2;
            bool isLessOrEqual = field1 <= field2;
            bool isGreaterField = field1 > field2;
            bool isLessField = field1 < field2;
            Console.WriteLine($"Равны: {isEqually}");
            Console.WriteLine($"Не равны: {isNotEqually}");
            Console.WriteLine($"Больше или равно: {isGreaterOrEqual}");
            Console.WriteLine($"Меньше или равно: {isLessOrEqual}");
            Console.WriteLine($"Больше: {isGreaterField}");
            Console.WriteLine($"Меньше: {isLessField}");


            // Task 4
            Console.WriteLine("~~~~~ Task 4 ~~~~~");
            var trueObj1 = new TaskFour { num = 3 }; // true (число в {2,3,5,7})
            var trueObj2 = new TaskFour { num = 2 }; // true
            var falseObj = new TaskFour { num = 0 }; // false (<1 или >10)
            var grayObj = new TaskFour { num = 4 };  // ни true, ни false

            var andResult1 = trueObj1 & falseObj;
            Console.WriteLine($"trueObj1 & falseObj = {andResult1.num}"); // 0 (falseObj)

            var andResult2 = falseObj & trueObj1;
            Console.WriteLine($"falseObj & trueObj1 = {andResult2.num}"); // 0 (falseObj)

            var andResult3 = grayObj & trueObj2;
            Console.WriteLine($"grayObj & trueObj2 = {andResult3.num}");  // 0 (grayObj)

            var orResult1 = trueObj1 | falseObj;
            Console.WriteLine($"trueObj1 | falseObj = {orResult1.num}");  // 3 (trueObj1)

            var orResult2 = falseObj | trueObj2;
            Console.WriteLine($"falseObj | trueObj2 = {orResult2.num}");  // 2 (trueObj2)

            var orResult3 = grayObj | trueObj2;
            Console.WriteLine($"grayObj | trueObj2 = {orResult3.num}");   // 2 (trueObj2, так как grayObj не true)


            // Task 5
            Console.WriteLine("~~~~~ Task 5 ~~~~~");
            Clock clock = new Clock();
            int val = -100;
            clock = val % 24;
            val = (int)clock;
            Console.WriteLine(val);


            // Task 6
            Console.WriteLine("~~~~~ Task 6 ~~~~~");
            Fahrenheit Tf = new Fahrenheit { Gradus = 1 };
            Celcius Tc = (Celcius)Tf;
            Console.WriteLine($"{Tf.Gradus}°F = {Tc.Gradus}°C");

            Celcius TempC = new Celcius { Gradus = 1 };
            Fahrenheit TempF = TempC;
            Console.WriteLine($"{TempC.Gradus}°C = {TempF.Gradus}°F");


            // task 7
            Console.WriteLine("~~~~~ Task 7 ~~~~~");
            Dollar usd = new Dollar { Sum = 1 };
            Euro eur = usd;
            Console.WriteLine($"{usd.Sum} USD = {eur.Sum} EUR");

            Euro euroWallet = new Euro { Sum = 1 };
            Dollar dollarWallet = (Dollar)euroWallet;
            Console.WriteLine($"{euroWallet.Sum} EUR = {dollarWallet.Sum} USD");
            // 0,8771929824561403508771929825


            // Task 8
            TextObject t = 5;
            int length = (int)t;
            char firstChar = (char)t;

            Console.WriteLine(t.Text);
            Console.WriteLine(length);
            Console.WriteLine(firstChar);

        }
    }
}
