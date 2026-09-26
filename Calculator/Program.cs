
/*
 * Данный проект является учебным.
 * Оно написано после прохождения 1,2 и 3 схемы обучения для новичков.
 * Простой калькулятор, сначала два числа затем символ.
 * Дальше уже обрабатываем ввод от ошибок и делаем вычисления
 * global using и top level statements не люблю.
 * что то по типу out ,ref out in, ? не использовал т.к не до конца разбираю как они работают
 */


using System;



class Calculator
{

    static void Main()
    {
        //Сообщения для пользователя
        Console.WriteLine("Добро пожаловать в приложение калькулятор!");
        Console.WriteLine("Введите сначала два числа, затем символ операции.");
        Console.WriteLine("Для выхода из программы введите q или exit");


        //Основной цикл для обработки
        while (true)
        {
            Console.Write("Введите первое число: ");
            string readFirstNumber = Console.ReadLine();

            //Игнорируем пустые нажатия
            if (string.IsNullOrWhiteSpace(readFirstNumber))
            {
                continue;
            }

            //обработка выхода,потом допилю нормланый выход
            if(readFirstNumber.ToLower() == "q" || readFirstNumber.ToLower() == "exit")
            {
                Console.WriteLine("Вы вышли из программы.Нажмите на любую кнопку чтобы закрыть консоль.");
                Console.ReadKey();
                break;
            }

            //обработка первого числа, в случае ошибки делаем запрос заново. Пример 2w - здесь буква поэтому ошибка
            float firstNumber = 0;
            if(!float.TryParse(readFirstNumber,out firstNumber))
            {
                Console.WriteLine("Некорректно введено первое число. Попробуйте ещё раз!");
                continue;
            }

            //обработка второго числа
            Console.Write("Введите второе число: ");
            string readSecondNumber = Console.ReadLine();
            float secondNumber = 0;
            if (!float.TryParse(readSecondNumber, out secondNumber))
            {
                Console.WriteLine("Некорректно введено второе число. Попробуйте ещё раз!");
                continue;
            }

            Console.Write("Введите символ операции(+,-,*,/): ");
            string symbolOperation = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(symbolOperation))
            {
                Console.WriteLine("Некорректный символ операции.");
                continue;
            }

            //когда все проверки пройдены выводим резульатат
            float result = Calculate(firstNumber,secondNumber,symbolOperation);
            Console.WriteLine($"Результат: {firstNumber} {symbolOperation} {secondNumber} = {result}");


        }


    }

    //Непосредственно сам метод вычисления
    static float Calculate(float a, float b, string op)
    {
        switch (op)
        {
            case "+":
                return a + b;
            case "-":
                return a - b;
            case "*":
                return a * b;
            case "/":
                if(b == 0)
                {
                    Console.WriteLine("Деление на ноль.");
                    return 0;
                }
                return a / b;
            default:
                return 0;
        }
        
    }


}


