




class Program
{
    static void Main(string[] args)
    {
        



        Console.WriteLine("Добро пожаловать в приложение калькулятор!");
        Console.WriteLine("Введите сначала два числа, а затем оператор.");
        Console.WriteLine("При вводе чисел с плавающей запятой, введите знак в соотвествие с языком системы.");
        Console.WriteLine("Для выхода из программы в качестве первого числа введите q");

        while (true)
        {
           


            Console.Write("Введите первое число: ");
            string? readFirstNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(readFirstNumber))
            {
                continue;
            }

            if (readFirstNumber.ToLower() == "q")
            {
                Console.WriteLine("Вы вышли из программы.");
                break;
            }

            if (!TryReadNumber(readFirstNumber, out float firstNumber))
            {
                Console.WriteLine("Ошибка!! Введите корректное первое число.");
                continue;
            }


            Console.Write("Введите второе число: ");
            string? readSecondNumber = Console.ReadLine();
            if (!TryReadNumber(readSecondNumber, out float secondNumber))
            {
                Console.WriteLine("Ошибка!! Введите корректное второе число.");
                continue;
            }

            Console.Write("Введите символ операции(+,-,*,/): ");
            string? readOperationSymbol = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(readOperationSymbol))
            {
                Console.WriteLine("Символ операции не может пустой!");
                continue;
            }

            if(TryCalculate(firstNumber, secondNumber,readOperationSymbol,out float result))
            {
                Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {result}");
            }







        }




    }

    static bool TryCalculate(float a, float b, string op, out float result)
    {
        result = 0;
        switch (op)
        {
            case "+":
                result = a + b;
                return true;

            case "-":
                result = a - b;
                return true;
            case "*":
                result = a * b;
                return true;
            case "/":
                if (b == 0)
                {
                    Console.WriteLine("Деление на ноль!");
                    return false;
                }
                result = (float)a / b;
                return true;

            default:
                Console.WriteLine($"Команда {op} отсутствует!");
                return false;
        }
        

    }
    static bool TryReadNumber(string prompt, out float result)
    {
        return float.TryParse(prompt, out result);
    }
}
