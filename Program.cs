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
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account() { number = 0, name = "", sum = 0 });
            accounts[0].Start();


            number++;
            number = SecondBank(bank_2, number);
            bank.InfoOut();
            Choise1(bank, bank_2, number);
        }
        static int SecondBank(Account bank_2, int number)
        {
            Console.WriteLine("\nЖелаете открыть второй счёт?");
            Console.WriteLine("1. Да      2. Нет");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bank_2.Open(number);
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
        static void Choise1(Account bank, Account bank_2, int number)
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
                    bank.Add();
                    Choise1(bank, bank_2, number);
                    break;
                case "2":
                    bank.Take();
                    Choise1(bank, bank_2, number);
                    break;
                case "3":
                    bank.TakeAll();
                    Choise1(bank, bank_2, number);
                    break;
                case "4":
                    if (bank_2 != null)
                    {
                        bank_2.InfoOut();
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
                    bank_2.InfoOut();
                    bank.InfoOut();
                    Choise1(bank, bank_2, number);
                    break;
                default:
                    Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз");
                    Choise1(bank, bank_2, number);
                    break;
            }
        }
        static void Choise2(Account bank, Account bank_2, int number)
        {
            Console.WriteLine("\nВыберите операцию");
            Console.Write("1. Положить деньги      2. Снять деньги      3. Снять всё      4. Переключиться на другой счёт      5. Перевести на другой счёт");
            Console.WriteLine();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bank_2.Add();
                    Choise2(bank, bank_2, number);
                    break;
                case "2":
                    bank_2.Take();
                    Choise2(bank, bank_2, number);
                    break;
                case "3":
                    bank_2.TakeAll();
                    Choise2(bank, bank_2, number);
                    break;
                case "4":
                    bank.InfoOut();
                    Choise1(bank, bank_2, number);
                    break;
                case "5":
                    int raznitsa = bank_2.Perenos();
                    bank.Zanos(raznitsa);
                    bank.InfoOut();
                    bank_2.InfoOut();
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