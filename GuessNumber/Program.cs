


using System;
class GuessNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру угадай число!");
        Console.WriteLine("Ваша задача угадать число, который загадал компьютер.");
        Console.WriteLine("Вы можете выбрать диапазон чисел, а также настроить другие параметры.");
        Console.WriteLine("Нажмите:\n\n1 - Начать игру!;\n2 - Настройки;\n3 - Выйти из игры;");



        while (true)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Вы началаи игру");
                    break;
                case "2":
                    Console.WriteLine("Настройки");
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
}

