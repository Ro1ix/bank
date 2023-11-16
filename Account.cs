using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Account
    {
        public int number { get; set; }
        public string name { get; set; }
        public double sum { get; set; }
        public void Start()
        {
            Open();
        }
        private void Open()
        {
            Console.Write("Введите номер счёта: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите своё имя: ");
            name = Console.ReadLine();
            do
            {
                Console.Write("Введите сумму на счету: ");
                sum = Convert.ToDouble(Console.ReadLine());
                if (sum < 0)
                {
                    Console.WriteLine("ОШИБКА!!! Нажмите любую клавишу и попробуйте ещё раз");
                    Console.ReadKey();
                }
            } while (sum < 0);
        }
        public void InfoOut()
        {
            Console.WriteLine($"\nНомер счёта: {number}");
            Console.WriteLine($"ФИО: {name}");
            Console.WriteLine($"Сумма на счету: {sum}");
        }
        public void Add()
        {
            Console.WriteLine("\nКакую сумму хотите положить?");
            double input = Convert.ToDouble(Console.ReadLine());
            if (input > 0)
            {
                sum += input;
                Console.WriteLine($"У вас на счету {sum}");
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                Add();
            }
        }
        public void Take()
        {
            Console.WriteLine("\nКакую сумму хотите снять?");
            double input = Convert.ToDouble(Console.ReadLine());
            if (input <= sum && input >= 0)
            {
                sum -= input;
                Console.WriteLine($"У вас на счету {sum}");
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                Take();
            }

        }
        public void TakeAll()
        {
            Console.WriteLine("\nВы уверены, что хотите снять все деньги со счета?");
            Console.WriteLine("1. Да      2. Нет");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    sum = 0;
                    Console.WriteLine($"У вас на счету {sum}");
                    break;
                case "2":
                    Console.WriteLine("Ваш счёт не изменился");
                    break;
                default:
                    Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                    TakeAll();
                    break;
            }
        }
        public int Perenos()
        {
            Console.WriteLine("Какую сумму вы хотите перевести?");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input < 0 || input > sum)
            {
                Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                Perenos();
            }
            else
            {
                sum -= input;
            }
            return input;
        }
        public void Zanos(int raznitsa)
        {
            sum += raznitsa;
        }
    }
}