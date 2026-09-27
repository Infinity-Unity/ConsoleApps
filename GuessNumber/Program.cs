

/*
 * Классическая игра "Угадай число".
 * Данный код немного перегружен из за меню выбора и настроек
 * По умолчанаию задается диапазон от 0 до 10, в коде 10 включен в диапазон
 * все действия и ввод пользователя проверяются на наличие ошибок.
 * В настройках каждый ввод проверяется в отдельном цикле
 * Просто тренеруюсь с string ,TryParse, и с методами
 * Некоторые вещи не применил здесь, допустим null или что типа string?. 
 * 
 * 
 */


using System;

class GuessNumber
{
    // класс рандом для использования метода Next
    static Random random = new Random();
    static void Main(string[] args)
    {
        //приветствие и полсказка для пользователя
        ShowInfo();

        //диапазон случайного числа
        int lowValue = 0;
        int highValue = 10;

        //цикл выбора в меню
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

    //метод для запуска игрового цикла, по умолчанию стартует с диапазаоном от 0 до 11
    static void StartGame(int lowValue, int highValue)
    {
        Console.WriteLine("Вы началаи игру");
        Console.WriteLine($"Введите число от {lowValue} до {highValue} включительно.");

        //число который загадал компьютер
        int secretNumber = random.Next(lowValue, highValue + 1);
        Console.WriteLine($"Загадайте число от {lowValue} до {highValue}.");

        //игровой цикл, выходим в случае выигрыша , или нажатии q
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
                Console.WriteLine("Введено некорректное число. Повторите попытку!");
                continue;
            }

            if (secretNumber == userGuessNumber)
            {
                Console.WriteLine("Поздравляем с победой!!! Вы угадали число.");
                if (ConfirmChoise("Хотите продолжить?"))
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
                if(userGuessNumber > secretNumber) Console.WriteLine("Попробуй в меньшую сторону");
                if(userGuessNumber < secretNumber) Console.WriteLine("Попробуй в большую сторону");

            }
        }
    }

    //настройки для диапазона
    static void SetSettings(ref int lowValue, ref int highValue)
    {
        Console.WriteLine("Настройки");
        Console.WriteLine("Здесь вы можете изменять диапазон.");
        Console.WriteLine($"Текущий диапазон : {lowValue} до {highValue}.");

        if (ConfirmChoise("Хотите задать диапазон?"))
        {
            int lowNumber;
            int highNumber;
            while (true)
            {
                Console.Write("Введите минимальное число диапазона: ");
                string low = Console.ReadLine();
                if (!int.TryParse(low, out lowNumber))
                {
                    Console.WriteLine("Некорректно введено число. Повторите попытку!");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Введите максимальное число диапазона: ");
                string high = Console.ReadLine();
                
                if (!int.TryParse(high, out highNumber))
                {
                    Console.WriteLine("Некорректно введено число. Повторите попытку!");
                    continue;
                }

                if (lowNumber >= highNumber)
                {
                    Console.WriteLine("Максимальный диапазон не может быть меньше минимального. Повторите попытку!");
                    continue;
                }
                break;
            }

            

            Console.WriteLine($"Отлично! Диапазон изменен с [{lowValue} : {highValue}] на [{lowNumber} : {highNumber}].");
            lowValue = lowNumber;
            highValue = highNumber;




        }
        else
        {
            Console.WriteLine("Вы вышли из настроек.");
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


    static bool ConfirmChoise(string question)
    {
        while (true)
        {
            Console.WriteLine(question);
            Console.Write("Введите (Y/N): ");
            string normalizedConfirm = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(normalizedConfirm))
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку!");
                continue;
            }

            string fixConfirm = normalizedConfirm.Trim().ToLower();

            if(fixConfirm == "y")
            {
                return true;
            }
            else if(fixConfirm == "n")
            {
                return false;
            }
            
            Console.WriteLine("Такой опции нету! Повторите попытку");
            
        }
    }


}

