
/*int*/



namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? readFirstNumber;
            string? readSecondNumber;
            string? readOperationSymbol;

            float firstNumber;
            float secondNumber;

            bool validInput = false;
            bool validFirstRead = false;
            bool validSecondRead = false;

            Console.WriteLine("Добро пожаловать в калькулятор!\nВведите сначала два числа, затем операцию.\nВниание при введении чисел с плавающей точкой,введите запятую.");
            do
            {
                Console.Write("Введите первое число: ");
                readFirstNumber = Console.ReadLine();
                validFirstRead = float.TryParse(readFirstNumber, out firstNumber);
                if (!validFirstRead)
                {
                    Console.Clear();
                    Console.WriteLine("Введите корректное первое число!");
                    continue;
                }


                Console.Write("Введите второе число: ");
                readSecondNumber = Console.ReadLine();
                validSecondRead = float.TryParse(readSecondNumber, out secondNumber);

                if (!validSecondRead)
                {
                    Console.Clear();
                    Console.WriteLine("Введите корректное второе число!");
                    continue;
                }

                Console.Write("Введите символ операции(+-*/^%): ");
                readOperationSymbol = Console.ReadLine();

                



                if(validFirstRead & validSecondRead)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели данные некорректно. Попробуйте еще раз.");
                    continue;
                }

                switch (readOperationSymbol)
                {
                    case "+":
                        Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {firstNumber + secondNumber}");
                        break;
                    case "-":
                        Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {firstNumber - secondNumber}");
                        break;
                    case "*":
                        Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {firstNumber * secondNumber}");
                        break;
                    case "/":
                        Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {firstNumber / secondNumber}");
                        break;
                    case "^":
                        Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {Math.Pow(firstNumber,secondNumber)}");
                        break;
                    case "%":
                        Console.WriteLine($"{firstNumber} {readOperationSymbol} {secondNumber} = {firstNumber % secondNumber}");
                        break;
                }

            } while (!validInput);
            

            
        }
    }
}
