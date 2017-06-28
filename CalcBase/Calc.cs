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


            Console.WriteLine(Operations.GetType().ToString());
            Operations.Add(new MulOperation());
            Operations.Add(new ResOperation());
            Operations.Add(new PowOperation());
            Operations.Add(new SumOperation());
            SetFolderOperations("Exts", "*dll");
        }

        private void SetFolderOperations(string folderName, string ch)
        {
            //директория с расширениями
            var extsDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            

            if (!Directory.Exists(extsDirectory))
                return;
            var exts = Directory.GetFiles(extsDirectory, ch);
            foreach (var file in exts)
            {
                SetDllFile(file);
                Console.WriteLine(file);
            }
        }

        private bool SetDllFile(string dllName)
        {

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
            var ty = typeof(IOperation);
            foreach (var t in types)
            {
                // находим тех, кто реализует интерфейc IOperation
                var interfs = t.GetInterfaces();
                if (interfs.Contains(ty))
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
            //rusName = oper.rusName;

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
        /// Строку в инт
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="def">Если не удалось распарсить, то возвращаем это значение</param>
        /// <returns></returns>
        public static double ToNumber(string arg, double def = 100)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                x = def;
            }

            return x;
        }


    }
}
