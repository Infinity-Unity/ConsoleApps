
/*
 * 
 * Эта вторая версия калькулятора с вводом в одну строку.
 * На данный момент реализовал рабочую версию, пока что без проверок на лишние символы операции, допустим 2++2 это оишбка и программа падает
 * Поэтому пока что тут нету приоритеты операций, а так все работает отлично.
 * 
 */



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

            if (lowerInput == "clear")
            {
                Console.Clear();
                continue;
            }

            string fixExpression = readInput.Replace(" ", "");
            
            //Console.WriteLine(fixExpression);
            //Calculate(fixExpression);
            FindNumberAndCalcaulate(fixExpression);
        }
    }

    static void FindNumberAndCalcaulate(string expression) // 1 + 2 * 3 = 7
    {
        string buffer = "";
        float result = 0f;
        char op = ' ';
        

        for(int i  = 0; i < expression.Length; i++)
        {

            if (char.IsDigit(expression[i]) || expression[i] == '.')
            {

                buffer += expression[i];
                

            }
            else
            {
                //float buffNum = float.Parse(buffer);
                float buffNum = 0;
                
                if (!float.TryParse(buffer, out buffNum)) //новое : TryParse вместо parse
                {
                    Console.WriteLine($"Введено некорректное выражение! Повторите попытку.\nСамое выражение {expression[i]}");
                    continue;
                }
                if(op == ' ')
                {
                    result = buffNum;
                }
                else
                {
                    result = Calculate(buffNum,result,op);
                }

                op = expression[i];
                buffer = "";
            }
        }

        if(buffer != "")
        {
            //float buffNum = float.Parse(buffer);
            float buffNum = 0;

            if (!float.TryParse(buffer, out buffNum)) //p.s проверка вне цикла , 
            {
                Console.WriteLine($"Введено некорректное выражение! Повторите попытку.\nСамое выражение {buffer}");
                return;
            }
            if (op == ' ')
                result = buffNum;
            else
                result = Calculate(buffNum, result, op);
        }
        Console.WriteLine("Результат:  " + result + '.');
        
    }

   
    static float Calculate(float bufferNum,float result, char op)
    {
        

        switch (op)
        {
            case '+':
                result += bufferNum;
                break;
            case '-':
                result -= bufferNum;
                break;
            case '*':
                result *= bufferNum;
                break;
            case '/':
                if(bufferNum == 0)
                {
                    Console.WriteLine("Ошибка деления.");
                    return float.NaN;
                }
                result /= bufferNum;
                break;
            
        }

        return result;
    }
    
}

