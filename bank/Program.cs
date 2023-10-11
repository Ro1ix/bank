using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            Schet bank = new Schet();
            Schet bank_2 = new Schet();
            bank.Otk(number);
            number++;
            number = SecondBank(bank_2, number);
            bank.Out();
            Choise1(bank, bank_2, number);
        }
        static int SecondBank(Schet bank_2, int number)
        {
            Console.WriteLine("\nЖелаете открыть второй счёт?");
            Console.WriteLine("1. Да      2. Нет");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bank_2.Otk(number);
                    number++;
                    break;
                case "2":
                    Console.WriteLine("\nВы не открыли второй счёт");
                    break;
                default:
                    Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                    SecondBank(bank_2, number);
                    break;
            }
            return number;
        }
        static void Choise1(Schet bank, Schet bank_2, int number)
        {
            Console.WriteLine("\nВыберите операцию");
            Console.Write("1. Положить деньги      2. Снять деньги      3. Снять всё      ");
            if (number == 2)
                Console.WriteLine("4. Переключиться на другой счёт      5. Перевести на другой счёт");
            else
                Console.WriteLine();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bank.Dob();
                    Choise1(bank, bank_2, number);
                    break;
                case "2":
                    bank.Umen();
                    Choise1(bank, bank_2, number);
                    break;
                case "3":
                    bank.Obnul();
                    Choise1(bank, bank_2, number);
                    break;
                case "4":
                    if (bank_2 != null)
                    {
                        bank_2.Out();
                        Choise2(bank, bank_2, number);
                    }
                    else
                    {
                        Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                        Choise1(bank, bank_2, number);
                    }    
                    break;
                case "5":
                    int raznitsa = bank.Perenos();
                    bank_2.Zanos(raznitsa);
                    bank_2.Out();
                    bank.Out();
                    Choise1(bank, bank_2, number);
                    break;
                default:
                    Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                    Choise1(bank, bank_2, number);
                    break;
            }
        }
        static void Choise2(Schet bank, Schet bank_2, int number)
        {
            Console.WriteLine("\nВыберите операцию");
            Console.Write("1. Положить деньги      2. Снять деньги      3. Снять всё      4. Переключиться на другой счёт      5. Перевести на другой счёт");
            Console.WriteLine();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bank_2.Dob();
                    Choise2(bank, bank_2, number);
                    break;
                case "2":
                    bank_2.Umen();
                    Choise2(bank, bank_2, number);
                    break;
                case "3":
                    bank_2.Obnul();
                    Choise2(bank, bank_2, number);
                    break;
                case "4":
                    bank.Out();
                    Choise1(bank, bank_2, number);
                    break;
                case "5":
                    int raznitsa = bank_2.Perenos();
                    bank.Zanos(raznitsa);
                    bank.Out();
                    bank_2.Out();
                    Choise2(bank, bank_2, number);
                    break;
                default:
                    Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                    Choise2(bank, bank_2, number);
                    break;
            }
        }
    }
}
