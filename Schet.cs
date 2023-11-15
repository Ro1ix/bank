using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Schet
    {
        private int nom;
        private string name;
        private float sum = 0;
        public void Otk(int number)
        {
            number++;
            nom = number;
            Console.Write("Введите своё имя: ");
            name = Console.ReadLine();
            do
            {
                Console.Write("Введите сумму на счету: ");
                sum = float.Parse(Console.ReadLine());
                if (sum <= 0)
                {
                    Console.WriteLine("\nНа счету должна быть хоть какая-нибудь сумма");
                    Console.WriteLine("Попробуйте ещё раз\n");
                }
            } while (sum <= 0);
        }
        public void Out()
        {
            Console.WriteLine($"\nНомер счёта: {nom}");
            Console.WriteLine($"ФИО: {name}");
            Console.WriteLine($"Сумма на счету: {sum}");
        }
        public void Dob()
        {
            Console.WriteLine("\nКакую сумму хотите положить?");
            float input = float.Parse(Console.ReadLine());
            if (input > 0)
            {
                sum += input;
                Console.WriteLine($"У вас на счету {sum}");
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                Dob();
            }
        }
        public void Umen()
        {
            Console.WriteLine("\nКакую сумму хотите снять?");
            float input = float.Parse(Console.ReadLine());
            if (input <= sum && input >= 0)
            {
                sum -= input;
                Console.WriteLine($"У вас на счету {sum}");
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                Umen();
            }

        }
        public void Obnul()
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
                    Obnul();
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
