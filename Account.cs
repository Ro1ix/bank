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
        private int number;
        private string name;
        private double sum;
        public void Start()
        {
            Open();
            InfoOut();
        }
        private void Open()
        {
            string input;
            bool error = false;
            do
            {
                Console.Write("Введите номер счёта: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out number) == false)
                {
                    Console.Write("\nОШИБКА!!! Номер должен состоять только из цифр\nНажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                }
            } while (int.TryParse(input, out number) == false);
            do
            {
                Console.Write("Введите своё имя: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    error = true;
                    Console.Write("\nОШИБКА!!! Имя не должно содержать пробелов или пустоту\nНажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Console.WriteLine($"Введите номер счёта: {number}");
                    continue;
                }
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] == ' ')
                    {
                        error = true;
                        Console.Write("\nОШИБКА!!! Имя не должно содержать пробелов или пустоту\nНажмите Enter и попробуйте ещё раз . . . ");
                        do
                        {
                            //Nothing
                        } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                        Console.Clear();
                        Console.WriteLine($"Введите номер счёта: {number}");
                        break;
                    }
                    else
                        error = false;
                }
            } while (error == true);
            do
            {
                do
                {
                    Console.Write("Введите сумму на счету: ");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out sum) == false)
                    {
                        Console.Write("\nОШИБКА!!! Сумма счёта должна состоять только из цифр\nНажмите Enter и попробуйте ещё раз . . . ");
                        do
                        {
                            //Nothing
                        } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                        Console.Clear();
                        Console.WriteLine($"Введите номер счёта: {number}\nВведите своё имя: {name}");
                    }
                } while (double.TryParse(input, out sum) == false);
                if (sum < 0)
                {
                    Console.WriteLine("\nОШИБКА!!! Сумма не должна быть отрицательной\nНажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Console.WriteLine($"Введите номер счёта: {number}\nВведите своё имя: {name}");
                }
            } while (sum < 0);
            Console.Write("\nСЧЁТ ОТКРЫТ! Нажмите Enter, чтобы продолжить . . . ");
            do
            {
                //Nothing
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            Console.Clear();
        }
        public void InfoOut()
        {
            Console.WriteLine($"Номер счёта: {number}");
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Сумма на счету: {sum}");
        }
        public void Choise(string input, List<Account> accounts, int accountID, int accountID2)
        {
            switch (input)
            {
                case "1":
                    Adding();
                    break;
                case "2":
                    Take();
                    break;
                case "3":
                    TakeAll();
                    break;
                case "6":
                    Transfer(accounts, accountID, accountID2);
                    break;
            }
        }
        public int InfoNumber()
        {
            return number;
        }
        private void Adding()
        {
            string input;
            double cash;
            do
            {
                Console.Write("\nВведите сумму, которую хотите положить: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out cash) == false)
                    Console.WriteLine("\nОШИБКА!!! Сумма счёта должна состоять только из цифр\nПопробуйте ещё раз . . .");
            } while (double.TryParse(input, out cash) == false);
            if (cash > 0)
            {
                sum += cash;
                Console.Write($"\nГОТОВО! Деньги зачислены. Ваша сумма на счету: {sum}\nНажмите Enter, чтобы продолжить . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            }
            else
            {
                Console.WriteLine("\nОШИБКА!!! Сумма не должна быть отрицательной\nПопробуйте ещё раз . . .");
                Adding();
            }
        }
        private void Take()
        {
            string input;
            double cash;
            do
            {
                Console.Write("\nВведите сумму, которую хотите снять: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out cash) == false)
                    Console.WriteLine("\nОШИБКА!!! Сумма счёта должна состоять только из цифр\nПопробуйте ещё раз . . .");
            } while (double.TryParse(input, out cash) == false);
            if (cash <= sum && cash >= 0)
            {
                sum -= cash;
                Console.Write($"\nГОТОВО! Деньги сняты. Ваша сумма на счету: {sum}\nНажмите Enter, чтобы продолжить . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            }
            else
            {
                Console.WriteLine("\nОШИБКА!!! Сумма не должна превышать сумму счёта или быть отрицательной\nПопробуйте ещё раз . . .");
                Take();
            }

        }
        private void TakeAll()
        {
            Console.WriteLine("\nВы уверены, что хотите снять все деньги со счета?");
            Console.WriteLine("1. Да      2. Нет");
            string input = Console.ReadLine();
            if (input == "1")
            {
                sum = 0;
                Console.Write($"\nГОТОВО! Деньги сняты. Ваша сумма на счету: {sum}\nНажмите Enter, чтобы продолжить . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            }
            else if (input == "2")
            {
                Console.Write($"\nВаш счёт не изменился: {sum}\nНажмите Enter, чтобы продолжить . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            }
            else
            {
                Console.WriteLine("\nОШИБКА!!! Попробуйте ещё раз . . .");
                TakeAll();
            }
        }
        private void Transfer(List<Account> accounts, int accountID, int accountID2)
        {
            string input;
            double difference;
            do
            {
                Console.Write("\nВведите сумму, которую хотите перевести: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out difference) == false)
                    Console.WriteLine("\nОШИБКА!!! Сумма счёта должна состоять только из цифр\nПопробуйте ещё раз . . .");
            } while (double.TryParse(input, out difference) == false);
            if (difference <= accounts[accountID].sum && difference >= 0)
            {
                accounts[accountID].sum -= difference;
                accounts[accountID2].sum += difference;
                Console.Write($"\nГОТОВО! Деньги переведены\nВаша сумма на счету [{accounts[accountID].number}]: {accounts[accountID].sum}\nВаша сумма на счету [{accounts[accountID2].number}]: {accounts[accountID2].sum}\nНажмите Enter, чтобы продолжить . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            }
            else
            {
                Console.WriteLine("\nОШИБКА!!! Сумма не должна превышать сумму счёта или быть отрицательной\nПопробуйте ещё раз . . .");
                Transfer(accounts, accountID, accountID2);
            }
        }
    }
}