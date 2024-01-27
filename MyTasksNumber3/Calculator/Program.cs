using System.ComponentModel.Design;

class Work
{
    static void Main()
    {
        
       
        Calculator calculator = new Calculator();
        double value1, value2 = 0;
        const string listValue = "(+ - / * √ % =): ";
        string input = "";
        char operation;
        bool redFlag = true;
        Console.Write("Введите число 1: ");
        value1 = Convert.ToDouble(Console.ReadLine());
        input += value1;
        Console.WriteLine(input);
        while (redFlag) {
            try
            {
               

                Console.Write("Введите операцию из списка: " + listValue);
                operation = Convert.ToChar(Console.ReadLine() ?? " ");
                input += operation;
                Console.WriteLine(input);
                if (operation != '=')
                {
                    Console.Write("Введите 2 число: ");
                    value2 = Convert.ToDouble(Console.ReadLine());
                    input += value2;
                    Console.Write(input);
                }
                switch (operation)
                {
                    case '+':
                        value1 = calculator.Plus(value1, value2);
                        Console.Write($"= {value1}");
                        Console.WriteLine();
                        break;
                    case '-':
                        value1 = calculator.Minus(value1, value2);
                        Console.Write($"= {value1}");
                        Console.WriteLine();
                        break;
                    case '/':
                        value1 = calculator.Division(value1, value2);
                        Console.Write($"= {value1}");
                        Console.WriteLine();
                        break;
                    case '*':
                        value1 = calculator.Multiplication(value1, value2);
                        Console.Write($"= {value1}");
                        Console.WriteLine();
                        break;
                    case '%':
                        value1 = calculator.ProcentOfNum(value1, value2);
                        Console.Write($"= {value1}");
                        Console.WriteLine();
                        break;
                    case '√':
                        value1 = calculator.Sqrt(value1);
                        Console.Write($"= {value1}");
                        Console.WriteLine();
                        break;
                    case '=':
                        calculator.CheckResult();
                        redFlag = false;
                        break;
                    default:
                        goto case '=';
                }
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }
        }

    }
    
    
}


class Calculator 
{
    private double res = 0;

    public double Plus(double val1, double val2) => res =val1 + val2; 
    public double Minus(double val1,double val2) => res = val1 - val2;
    public double Multiplication(double val1,double val2) => res = val1 * val2; 
    public double Division(double val1,double val2)
    {
        if (val2 != 0) res = val1 /= val2;
        else 
        { 
            Console.WriteLine("На 0 делить нельзя");
        }
        return res;
       
    }
    public double ProcentOfNum(double val1, double val2) => (val1 / 100) * val2; 
    public double Sqrt(double val1)
    {
        res = Math.Sqrt(val1);
        return res;
    }
    public void CheckResult()=>Console.Write(res);
    
    public void Erase(ref double val1) => val1 = 0;
}

