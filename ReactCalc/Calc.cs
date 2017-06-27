using ReactCalc.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace ReactCalc
{
    /// <summary>
    /// Калькулятор
    /// </summary>
    public class Calc
    {
        public IList<IOperation> Operations { get; private set; }
        public string rusName { get; set; }

        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());
            Operations.Add(new PowOperation());
            Operations.Add(new ResOperation());
            Operations.Add(new MulOperation());
            SetDllFile("\\DevineLibrery.dll");
            SetDllFile("\\FactorialLibrery.dll");
        }

        private bool SetDllFile(string dll)
        {
            var dllName = Directory.GetCurrentDirectory() + dll;

            if (!File.Exists(dllName))
            {
                Console.WriteLine("Файл " + dllName + " не подключен");
                return false;
            }

            // загружаем сборку 
            var assembly = Assembly.LoadFrom(dllName);
            // получаем всем типы/классы из нее
            var types = assembly.GetTypes();
            // перебираем типы
            foreach (var t in types)
            {
                // находим тех, кто реализует интерфейc IOperation
                var interfs = t.GetInterfaces();
                if (interfs.Contains(typeof(IOperation)))
                {
                    // создаем экземпляр найденного класса
                    var instance = Activator.CreateInstance(t) as IOperation;//делаем из t IOperation
                    if (instance != null)
                    {
                        // добавляем его в наш список операций
                        Operations.Add(instance);
                    }
                }
            }
            return true;
        }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            // находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(selector);
            rusName = oper.rusName;

            if (oper != null)
            {
                // вычисляем результат 
                var result = oper.Execute(args);
                // отдаем пользователю
                return result;
            }

            throw new NotSupportedException("Не найдена запрашиваемая операция");
        }

        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }

        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
        }

        public double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }

        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Целое число</returns>
        [Obsolete("Используйте Execute('sum', new[]{x, y}). Данная функция будет удалена в версии 4.0")]
        public double Sum(double x, double y)
        {
            return Execute("sum", new[] { x, y });
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }

        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        public double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }

    }
}
