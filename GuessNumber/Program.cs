

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
        Console.WriteLine("Добро пожаловать в игру угадай число!");
        Console.WriteLine("Ваша задача угадать число, который загадал компьютер.");
        Console.WriteLine("Вы можете выбрать диапазон чисел в настройках, а также настроить другие параметры.");
        Console.WriteLine("Нажмите:\n\n1 - Начать игру!;\n2 - Настройки;\n3 - Выйти из игры;");

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

        while (false)
        {

        }
    }

    static void SetSettings(ref int lowValue, ref int highValue)
    {
        Console.WriteLine("Настройки");
        Console.WriteLine("Здесь вы можете изменять диапазон.");
        Console.WriteLine($"Текущий диапазон : {lowValue} до {highValue}.");
    }
}

