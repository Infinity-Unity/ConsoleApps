using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в калькулятор 2.0!");
        Console.WriteLine("Введите выражение в одну строку.(Пример 3 + 2).");
        Console.WriteLine("Для выхода из программы введите q или exit.");

        while (true)
        {
            string readInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(readInput))
            {
                Console.WriteLine("Некорректный ввод! Повторите попытку.");
                continue;
            }

            string lowerInput = readInput.ToLower();
            if (lowerInput == "q" || lowerInput == "exit")
            {
                Console.WriteLine("Вы вышли из программы. Нажмите любую кнопку чтобы закрыть консоль.");
                Console.ReadKey();
                break;
            }

            string fixExpression = readInput.Replace(" ", "");
            
            //Console.WriteLine(fixExpression);
            Calculate(fixExpression);
        }
    }

    static void Calculate(string expression)
    {
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '+') {
                int n1, n2;
                int.TryParse(expression[i - 1].ToString(), out n1);
                int.TryParse(expression[i + 1].ToString(), out n2);
                Console.WriteLine(n1);
                Console.WriteLine(n2);
                Console.WriteLine(n1+n2);
            }
        }
    }

    
}

