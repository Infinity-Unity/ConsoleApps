

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
                    StartGame(lowValue, highValue);
                    break;
                case "2":
                    SetSettings(ref lowValue, ref highValue);
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

    static void StartGame(int lowValue, int highValue)
    {
        Console.WriteLine("Вы началаи игру");
        Console.WriteLine($"Введите число от {lowValue} до {highValue} включительно.");

        Random random = new Random();



        int secretNumber = random.Next(lowValue, highValue + 1);
        Console.WriteLine($"Загадайте число от {lowValue} до {highValue}.");

        while (true)
        {

            Console.Write("Введите число: ");
            string readUserInput = Console.ReadLine();

            if (readUserInput == "q")
            {
                break;
            }

            int userGuessNumber;

            if (!int.TryParse(readUserInput, out userGuessNumber))
            {
                Console.WriteLine("Введенео некорректное число. Повторите попытку!");
                continue;
            }



            if (secretNumber == userGuessNumber)
            {
                Console.WriteLine("Поздравляем с победой!!! Вы угадали число.");
                Console.WriteLine("Хоите продолжить?(Y)");
                string readUserConfirm = Console.ReadLine();
                string fixUserConfirm = readUserConfirm.Trim().ToLower();
                if (fixUserConfirm == "y")
                {
                    Console.WriteLine("Отлично. Продлжаем игру....");
                    secretNumber = random.Next(lowValue, highValue + 1);
                    continue;

                }
                else
                {
                    Console.WriteLine("Вы отказались продолжать игру!");
                    break;
                }

            }
            else
            {
                Console.WriteLine("Вы не угадали число.");
                if(userGuessNumber > secretNumber) Console.WriteLine("Попробуй в меньшую сторону");
                if(userGuessNumber < secretNumber) Console.WriteLine("Попробуй в большую сторону");

            }
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
            if (string.IsNullOrWhiteSpace(readUserConfirm))
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
            else if (readUserConfirm.ToLower().Trim() == "n")
            {
                Console.WriteLine("Вы вышли из настроек.");
                break;
            }
        }


    }

    static void ShowInfo()
    {
        Console.WriteLine("Добро пожаловать в игру угадай число!");
        Console.WriteLine("Ваша задача угадать число, который загадал компьютер.");
        Console.WriteLine("Вы можете выбрать диапазон чисел в настройках, а также настроить другие параметры.");
        Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
        Console.ReadKey();

        Console.Clear();

        Console.WriteLine("Нажмите:\n\n1 - Начать игру!;\n2 - Настройки;\n3 - Выйти из игры;");
    }


    static void ConfirmChoise()
    {
        Console.WriteLine("Хоите продолжить?(Y/N)");
        string readUserConfirm = Console.ReadLine();
    }


}

