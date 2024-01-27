using System;
using TaskHome;

class Work
{
    // список месяцов для дз 1 и 2
    static string[] MonthName = {
        "январь",
        "февраль",
        "март",
        "апрель",
        "май",
        "июнь",
        "июль",
        "август",
        "сентябрь",
        "октябрь",
        "ноябрь",
        "декабрь"
        };
    static void Main()
    {
        HomeWork5();
    }
    static void HomeWork1()
    {


        try
        {

            Console.Write("введите номер месяца: ");
            uint UserValue = Convert.ToUInt32(Console.ReadLine());
            switch (UserValue <= 12)
            {
                case true:
                    Console.WriteLine("ваш месяц " + MonthName[UserValue - 1]);
                    break;
                case false:
                    Console.WriteLine("такого мнсяца нет");
                    break;
            }
        }
        catch
        {
            Console.WriteLine("вы ввели не число или число <= 0");
        }
    }
    static void HomeWork2()
    {
        try
        {

            Console.Write("введите номер месяца: ");
            uint UserValue = Convert.ToUInt32(Console.ReadLine());
            if (UserValue <= 12)
            {
                Console.WriteLine("ваш месяц " + MonthName[UserValue - 1]);
            }
            else
            {
                Console.WriteLine("такого мнсяца нет");
            }
        }
        catch
        {
            Console.WriteLine("вы ввели не число или число <= 0");
        }
    }
    static void HomeWork3()
    {
        try
        {
            Console.Write("Введите число: ");
            Console.WriteLine((Convert.ToInt32(Console.ReadLine()) % 2 == 0) ? "число чётное" : "число не чётное");
        }
        catch
        {
            Console.WriteLine("вы ввели не число");
        }
    }
    static void HomeWork4() 
    {
        string? messageFromError = null;
        try
        {
            Console.Write("введите температуру: ");
            int t = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((t > -5) ? "Тепло" : (t <= -5 & t > -20) ? "Нормально" : "Холодно");
        }
        catch(FormatException)
        {
            messageFromError = "Вы ввели не число";
        }
        finally
        {
            if(messageFromError != null) {  Console.WriteLine(messageFromError); }
        }

    }
    static void HomeWork5()
    {
        BaseColor data = new BaseColor();
        bool redFlag = false;
        int? indexElement = null;
        bool Breaker = true;
        while (Breaker)
        {
            var existingColors = data.Colors.ToList();
            try
            {
                redFlag = false;
                Console.Write("Введите номер цвета: ");
                uint numberColor = Convert.ToUInt32(Console.ReadLine());
                for (int i = 0; i < existingColors.Count; i++)
                {
                    if (numberColor == existingColors[i].numberColor)
                    {
                        indexElement = i;
                        redFlag = true;
                        break;
                    }
                }
                if (redFlag)
                {
                    Console.WriteLine("ваш цвет: " + existingColors[indexElement ?? 0].nameColor);
                }
                else
                {
                    Console.WriteLine("К сожалению совпадений нет, хотите добавить свой цвет?");
                    Console.Write("Если да введите 1: ");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            AddInDbvalueColors(data);
                            break;
                        default:
                           Breaker = false;
                            Console.WriteLine("Программа завершена, вы выбрали не 1");
                            break;
                    }
                }
           
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
                break;
            }
            data.SaveChanges();
        }
    }
    #region вспомогательный метод
    private static void AddInDbvalueColors(BaseColor color)
    {
        try
        {
            Console.Write("введите название цвета: ");
            string? text = Console.ReadLine();
            Console.Write("Введите номер цвета: ");
            uint numberColor = Convert.ToUInt32(Console.ReadLine());
            color.Colors.Add(new Color() { nameColor = text ?? "неизвестный цвет", numberColor = (int)numberColor });
            Console.WriteLine("Успешно!");
        }
        catch(Exception ex) 
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
    #endregion





}
