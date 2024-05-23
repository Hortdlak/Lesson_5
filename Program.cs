using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Lesson_5
{
    internal class Program
    {

        delegate void MyDelegate(string message);

        static void Main(string[] args)
        {
            #region Практика

            #region Задание 1:Создание метода принимающий список действий и последовательное выполнение

            /* Реализация один
            list.Add(Print1);
            list.Add(Print2);
            */

            //List<Action> list = [Print1, Print2]; // Реализация два

            //DoAction(list);

            #endregion

            #region Задание 2:

            //List<MyDelegate> myDeligates = new List<MyDelegate>()
            //{
            //    (message) => Console.WriteLine($"1 delegate {message}"),
            //    (message) => Console.WriteLine($"2 delegate {message}"),
            //};

            //PrintDelegate(myDeligates);

            #endregion

            #region Задание 3: Спроектируйте интерфейс упрощенного калькулятора c ф-ей отмены последнего действия

            //var calculus = new Calc();

            //calculus.MyEventHandler += Calc_MyEventHandler;
            //calculus.Sum(5);
            //calculus.Divide(5);
            //calculus.CancelLast();
            //calculus.CancelLast();
            //calculus.CancelLast();

            #endregion

            #region Задание 4: Создание метода, принимающий список строк, преобразующий их в числа и выполнения с ними действия.

            //List <string> list = new List<string>() { "Привет","1", "Как","16", "дела"};

            //Parse(list, int.Parse, (x) => Console.WriteLine(x));

            #endregion

            #region Задание 5: IsAdult?

            //List<string> list = new List<string>() { "Привет", "19", "Как", "16", "дела" };

            //IsAdult(list, int.Parse, x => x >= 18, x => Console.WriteLine($"Совершеннолетний. Возраст = {x}"));

            #endregion

            #endregion

            #region Домашнее задание
            /*
             Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран в цикле
             так чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена или введёт пустую строку.
             */

            var calculus = new Calc();

            calculus.Start();


            #endregion
        }

        public static void IsAdult(List <string> ages, Func<string,int> func, Predicate <int> predicate, Action <int> action )
        {
            foreach ( var age in ages )
            {

                if (int.TryParse(age, out int _))
                {
                    int res = func(age);

                    if (predicate(res))
                    {
                        action(res);
                    }
                }
            }
        }

        static void Parse (List<string> text, Func<string,int> func, Action<int> action)
        {
            foreach (var item in text)
            {
                if (int.TryParse(item, out int _))
                {
                    int res = func(item);
                    action(res);
                }
                else
                {
                    Console.WriteLine("Это не число");
                }
                
            }
        }

        private static void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
            {
                Console.WriteLine(((Calc)sender).Result);
            }
            
        }

        static void PrintDelegate(List<MyDelegate> list)
        {
            foreach (MyDelegate item in list)
            {
                item("333");
            }
        }

        public static void DoAction(List<Action> list)
        {
            foreach (var action in list)
            {
                action();
            }
        }
        public static void Print1()
        {
            Console.WriteLine(1111);
        }
        public static void Print2()
        {
            Console.WriteLine(2222);
        }
    }
}
