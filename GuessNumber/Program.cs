

/*
 * Классическая игра "Угадай число".
 * 
 * 
 * 
 */


using System;

class GuessNumber
{
    static void Main(string[] args)
    {
        
        ShowInfo();

        int lowValue = 0;
        int highValue = 10;

        while (true)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    StartGame(lowValue,highValue);
                    break;
                case "2":
                    SetSettings(ref lowValue,ref highValue);
                    break;
                case "3":
                    Console.WriteLine("Вы вышли из игры.");
                    return;
                default:
                    Console.WriteLine("Такой опции не существует.");
                    break;

            }
        }

        
    }

    static void StartGame(int lowValue,int highValue)
    {
        Console.WriteLine("Вы началаи игру");
        Console.WriteLine($"Введите число от {lowValue} до {highValue} включительно.");

        Random random = new Random();

        int randomLowValue = random.Next(lowValue);
        int randomHighValue = random.Next(highValue);

        int secretNumber = random.Next(randomLowValue,randomHighValue + 1);

        while (true)
        {
            Console.WriteLine($"Загадайте число от {randomLowValue} до {randomHighValue}");
            Console.WriteLine(secretNumber);
            if (Console.ReadLine() == "q") break;
        }
    }

    static void SetSettings(ref int lowValue, ref int highValue)
    {
        Console.WriteLine("Настройки");
        Console.WriteLine("Здесь вы можете изменять диапазон.");
        Console.WriteLine($"Текущий диапазон : {lowValue} до {highValue}.");
        Console.WriteLine("Хотите задать диапазон?(Y-задать/N-выйти из настроек)");
        while (true)
        {
            string readUserConfirm = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(readUserConfirm) || readUserConfirm == "")
            {
                Console.WriteLine("Неверный параметр.Повторите попытку");
                continue;
            }


            if (readUserConfirm.ToLower().Trim() == "y")
            {
                Console.Write("Введите минимальное число диапазона: ");
                string low = Console.ReadLine();
                int lowNumber;
                if (!int.TryParse(low, out lowNumber))
                {
                    Console.WriteLine("Некорректно введено число. Повторите попытку!");
                    continue;
                }

                Console.Write("Введите максимальное число диапазона: ");
                string high = Console.ReadLine();
                int highNumber;
                if (!int.TryParse(high, out highNumber))
                {
                    Console.WriteLine("Некорректно введено число. Повторите попытку!");
                    continue;
                }

                Console.WriteLine($"Отлично! Диапазон изменен с [{lowValue} : {highValue}] на [{lowNumber} : {highNumber}].");
                lowValue = lowNumber;
                highValue = highNumber;
                break;
            }
            else if(readUserConfirm.ToLower().Trim() == "n")
            {
                Console.WriteLine("Вы вышли из настроек.");
                break;
            }
        }
        
        int firstOption = 0;
        int secondOption = 0;

    }

    static void ShowInfo()
    {
        Console.SetCursorPosition(10, 10);
        int widthConsole = Console.WindowWidth - 80;
        int heightConsole = Console.WindowHeight - 10;




        Console.SetCursorPosition(widthConsole / 2, heightConsole / 2);
        Console.WriteLine("Добро пожаловать в игру угадай число!");

        Console.SetCursorPosition(widthConsole / 2, (heightConsole / 2) + 1);
        Console.WriteLine("Ваша задача угадать число, который загадал компьютер.");

        Console.SetCursorPosition(widthConsole / 2, (heightConsole / 2) + 2);
        Console.WriteLine("Вы можете выбрать диапазон чисел в настройках, а также настроить другие параметры.");

        Console.SetCursorPosition(widthConsole / 2, (heightConsole / 2) + 2);
        Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
        Console.ReadKey();

        Console.SetCursorPosition(0, 0);
        Console.Clear();

        Console.WriteLine("Нажмите:\n\n1 - Начать игру!;\n2 - Настройки;\n3 - Выйти из игры;");
    }

    
}

