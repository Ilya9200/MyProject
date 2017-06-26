using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int switch_on;
            Calc result = new Calc();
            double x, y;
            while (true)
            {
                Console.WriteLine("Выберете операцию:");
                Console.WriteLine("Введите 1 для сложения");
                Console.WriteLine("Введите 2 для вычитания");
                Console.WriteLine("Введите 3 для умножения");
                Console.WriteLine("Введите 4 для деления");
                switch_on = Convert(Console.ReadLine(), 0);

                Console.WriteLine("Введите первое число:");
                x = Convert(Console.ReadLine(), 0);
                Console.WriteLine("Введите второе число:");
                y = Convert(Console.ReadLine(), 0);
                switch (switch_on)
                {
                    case 1:
                        Console.WriteLine("Res = " + result.Sum(x,y).ToString());
                        break;
                    case 2:
                        Console.WriteLine("Res = " + result.Res(x, y).ToString());
                        break;
                    case 3:
                        Console.WriteLine("Res = " + result.Mul(x, y).ToString());
                        break;
                    case 4:
                        double DivRes;
                        if (result.Div(x, y, out DivRes))
                            Console.WriteLine("Res = " + DivRes.ToString());
                        else
                            Console.WriteLine("Ошибка: на ноль делить нельзя!");
                            break;
                    default:
                        Console.WriteLine("Нажмите крестик, чтобы выйти!!");
                        break;
                }
            }
        }
        /// <summary>
        /// Конвертирует строку в соответствующее целое число
        /// </summary>
        /// <param name="arg">Конвертируемая строка</param>
        /// <param name="def">Значение по умолчанию</param>
        /// <returns>Целое число</returns>
        public static int Convert(string arg, int def)
        {
            int x;
            if (!int.TryParse(arg, out x))
                x = def;
            return x;
        }

        /// <summary>
        /// Конвертирует строку в соответствующее вещественное число
        /// </summary>
        /// <param name="arg">Конвертируемая строка</param>
        /// <param name="def">Значение по умолчанию</param>
        /// <returns>Вещественное число число</returns>
        public static double Convert(string arg, double def)
        {
            double x;
            if (!double.TryParse(arg, out x))
                x = def;
            return x;
        }

    }
}
