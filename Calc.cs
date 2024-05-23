
namespace Lesson_5
{

    public class Calc : ICalc
    {
        public double Result { get; set; }

        public event EventHandler<EventArgs>? MyEventHandler;

        private Stack<double> LastResult { get; set; } = new Stack<double>();

        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
            Console.WriteLine($"Результат: {Result}");
        }

        private void ExecuteOperation(Func<double, double> operation)
        {
            Result = operation(Result);
            PrintResult();
            LastResult.Push(Result);
        }

        public void Divide(int x)
        {
            if (x != 0)
            {
                ExecuteOperation(r => r / x);
            }
            else
            {
                Console.WriteLine("Деление на ноль невозможно.");
            }
        }

        public void Multiply(int x)
        {
            ExecuteOperation(r => r * x);
        }

        public void Subtract(int x)
        {
            ExecuteOperation(r => r - x);
        }

        public void Sum(int x)
        {
            ExecuteOperation(r => r + x);
        }

        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
                Result = res;

                Console.Write("Последнее действие возвращено. ");
                PrintResult();
            }
            else
            {
                Console.WriteLine("Последнее действие не может быть возвращено");
            }
        }

        public void Start()
        {
            Console.WriteLine("Добро пожаловать в калькулятор. Выберите команды:");
            Console.WriteLine("сумма [число], вычитание [число], умножение [число], деление [число], возврат");

            while (true)
            {
                Console.Write("Введите команду: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower()=="отмена") // пустая строка или отмена
                {
                    break;
                }

                var parts = input.Split(' ');
                if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                {
                    switch (parts[0].ToLower())
                    {
                        case "сумма":
                            Sum(value);
                            break;
                        case "вычитание":
                            Subtract(value);
                            break;
                        case "умножение":
                            Multiply(value);
                            break;
                        case "деление":
                            Divide(value);
                            break;
                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }
                else if (parts.Length == 1 && parts[0].ToLower() == "возврат")
                {
                    CancelLast();
                }
                else
                {
                    Console.WriteLine("Неверная команда или значение.");
                }
            }
        }
    }
}
