using System;

namespace BankProject
{
    class Program
    {
        private static Bank bank = new Bank("Belinvestbank");
        private static bool isRunning = true;
        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("Create", Create),
            new Tuple<string, Action<string>>("Close", Close),
            new Tuple<string, Action<string>>("Open", Open),
            new Tuple<string, Action<string>>("Write", Write),
            new Tuple<string, Action<string>>("Display", Display),
            new Tuple<string, Action<string>>("Add", Add),
            new Tuple<string, Action<string>>("Withdraw", WithDraw),
            new Tuple<string, Action<string>>("Exit", Exit),
        };
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to {bank.Name}");

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                if (inputs.Length == 0)
                {
                    continue;
                }

                var command = inputs[0];

                if (string.IsNullOrEmpty(command))
                {
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    var parameters = inputs.Length > 1 ? inputs[1] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    Console.WriteLine($"Command not found - {command}");
                }
            }
            while (isRunning);
        }

        static void Create(string parameters)
        {
            string firstname;
            string lastname;
            decimal sum;
            Account.AccountStatus status;

            Console.Write("First Name: ");
            firstname = Console.ReadLine();
            Console.Write("Last Name: ");
            lastname = Console.ReadLine();
            
            while (true)
            {
                Console.Write("Sum: ");
                if (decimal.TryParse(Console.ReadLine(), out sum))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid sum");
                }
            }

            while (true)
            {
                Console.Write("Account status: ");
                if (Account.AccountStatus.TryParse(Console.ReadLine(), out status))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a account status");
                }
            }

            bank.CreateAccount(new Account(firstname, lastname, sum, status));
            bank.WriteToStorageDefault();
        }

        static void Close(string parameters)
        {
            int id;
            if (int.TryParse(parameters, out id))
            {
                bank.CloseAccount(id);
            }
            else
            {
                Console.WriteLine("Please enter a valid ID");
            }
        }

        static void Display(string parameters)
        {
            if(string.IsNullOrEmpty(parameters))
            {
                bank.DisplayAccounts();
            }
            else
            {
                int id;
                if(int.TryParse(parameters, out id))
                {
                    bank.DisplayAccounts(id);
                }
                else
                {
                    Console.WriteLine("Please enter a valid ID as a parameter");
                }
            }

        }

        static void Add(string parameters)
        {
            var inputs = parameters.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (inputs.Length < 2 || string.IsNullOrEmpty(inputs[0]) || string.IsNullOrEmpty(inputs[1]))
            {
                Console.WriteLine("Please enter id and sum as parameters"); 
                return;
            }
            else
            {
                if(int.TryParse(inputs[0], out int id) && decimal.TryParse(inputs[1], out decimal sum))
                {
                    bank.Add(id, sum);
                }
                else
                {
                    Console.WriteLine("Please enter valid id and sum as parameters");
                }
            }
        }

        static void WithDraw(string parameters)
        {
            var inputs = parameters.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (inputs.Length < 2 || string.IsNullOrEmpty(inputs[0]) || string.IsNullOrEmpty(inputs[1]))
            {
                Console.WriteLine("Please enter id and sum as parameters");
                return;
            }
            else
            {
                if (int.TryParse(inputs[0], out int id) && decimal.TryParse(inputs[1], out decimal sum))
                {
                    bank.Withdraw(id, sum);
                }
                else
                {
                    Console.WriteLine("Please enter valid id and sum as parameters");
                }
            }
        }
        static void Open(string parameters)
        {
            if(!string.IsNullOrEmpty(parameters))
            {
                bank.OpenStorage(parameters);
            }
        }

        static void Write(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                bank.WriteToStorage(parameters);
            }
            else
            {
                bank.WriteToStorageDefault();
            }
        }

        static void Exit(string parameters)
        {
            isRunning = false;
        }
    }
}
