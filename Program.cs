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
            Console.Title = "Банк";
            List<Account> accounts = new List<Account>();
            int count = 0;
            accounts.Add(new Account());
            int accountId = count;
            accounts[accountId].Start();
            count++;
            Choise(accounts, count, accountId);
        }
        static void Choise(List<Account> accounts, int count, int accountID)
        {
            Console.WriteLine("\nВЫБЕРИТЕ ДЕЙСТВИЕ");
            Console.WriteLine("1. Положить деньги");
            Console.WriteLine("2. Снять деньги");
            Console.WriteLine("3. Снять ВСЕ деньги");
            Console.WriteLine("4. Открыть новый счёт");
            if (count > 1)
            {
                Console.WriteLine("5. Сменить счёт");
                Console.WriteLine("6. Перевести деньги с текущего счёта на другой");
            }
            Console.WriteLine("Enter. Выход");
            string input = Console.ReadLine();
            int accountID2 = 0;
            switch (input)
            {
                case "1":
                    accounts[accountID].Choise(input, accounts, accountID, accountID2);
                    Console.Clear();
                    accounts[accountID].InfoOut();
                    Choise(accounts, count, accountID);
                    break;
                case "2":
                    accounts[accountID].Choise(input, accounts, accountID, accountID2);
                    Console.Clear();
                    accounts[accountID].InfoOut();
                    Choise(accounts, count, accountID);
                    break;
                case "3":
                    accounts[accountID].Choise(input, accounts, accountID, accountID2);
                    Console.Clear();
                    accounts[accountID].InfoOut();
                    Choise(accounts, count, accountID);
                    break;
                case "4":
                    Console.Clear();
                    accounts.Add(new Account());
                    accountID = count;
                    accounts[accountID].Start();
                    count++;
                    Choise(accounts, count, accountID);
                    break;
                case "5":
                    if (count > 1)
                    {
                        Console.Clear();
                        int number;
                        Console.WriteLine("ВАШИ СЧЕТА");
                        foreach (Account account in accounts)
                        {
                            Console.WriteLine();
                            if (accounts[accountID].InfoNumber() == account.InfoNumber())
                                Console.WriteLine("[Текущий]");
                            account.InfoOut();
                        }
                        do
                        {
                            Console.Write("\nВведите номер счёта, на который хотите перейти: ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out number) == false)
                            {
                                Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                                do
                                {
                                    //Nothing
                                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                                goto case "5";
                            }
                        } while (int.TryParse(input, out number) == false);
                        for (int i = 0; i < count; i++)
                        {
                            if (number == accounts[i].InfoNumber())
                            {
                                accountID = i;
                                break;
                            }
                            else if (i == count - 1)
                            {
                                Console.Write("\nОШИБКА!!! Счёта с таким номером не существует\nНажмите Enter и попробуйте ещё раз . . . ");
                                do
                                {
                                    //Nothing
                                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                                goto case "5";
                            }
                        }
                        Console.Clear();
                        accounts[accountID].InfoOut();
                        Choise(accounts, count, accountID);
                    }
                    else
                        goto default;
                    break;
                case "6":
                    if (count > 1)
                    {
                        Console.Clear();
                        int number2;
                        accountID2 = 0;
                        Console.WriteLine("ВАШИ СЧЕТА");
                        foreach (Account account in accounts)
                        {
                            Console.WriteLine();
                            if (accounts[accountID].InfoNumber() == account.InfoNumber())
                                Console.WriteLine("[Текущий]");
                            account.InfoOut();
                        }
                        do
                        {
                            Console.Write("\nВведите номер счёта, на который хотите перевести деньги: ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out number2) == false)
                            {
                                Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                                do
                                {
                                    //Nothing
                                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                                goto case "6";
                            }
                        } while (int.TryParse(input, out number2) == false);
                        for (int i = 0; i < count; i++)
                        {
                            if (number2 == accounts[i].InfoNumber())
                            {
                                accountID2 = i;
                                break;
                            }
                            else if (i == count - 1)
                            {
                                Console.Write("\nОШИБКА!!! Счёта с таким номером не существует\nНажмите Enter и попробуйте ещё раз . . . ");
                                do
                                {
                                    //Nothing
                                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                                goto case "6";
                            }
                        }
                        input = "6";
                        accounts[accountID].Choise(input, accounts, accountID, accountID2);
                        Console.Clear();
                        accounts[accountID].InfoOut();
                        Choise(accounts, count, accountID);
                    }
                    else
                        goto default;
                    break;
                case "":
                    break;
                default:
                    Console.WriteLine("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    accounts[accountID].InfoOut();
                    Choise(accounts, count, accountID);
                    break;
            }
        }
    }
}