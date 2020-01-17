using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankProject
{
    public class Bank
    {
        private string path = "Bankstorage.dat";
        private List<Account> accounts = new List<Account>();
        public string Name { get; }

        public Bank(string name)
        {
            this.Name = name;
            this.OpenStorageDefault();
        }

        public void Add(int id, decimal sum)
        {
            Account acc = accounts.Find(i => i.Id == id);
            if(acc != null)
            {
                acc.Add(sum);
                this.WriteToStorageDefault();
            }
            else
            {
                Console.WriteLine("there is no account with such ID");
            }
        }

        public void Withdraw(int id, decimal sum)
        {
            Account acc = this.accounts.Find(i => i.Id == id);
            if (acc != null)
            {
                acc.WithDraw(sum);
                this.WriteToStorageDefault();
            }
            else
            {
                Console.WriteLine("there is no account with such ID");
            }
        }

        public void OpenStorage(string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    this.accounts = (List<Account>)formatter.Deserialize(fs);                    
                }
                this.path = path;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
                      
        }

        public void WriteToStorage(string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {                    
                    formatter.Serialize(fs, accounts);                    
                }
                this.path = path;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public void OpenStorageDefault()
        {
            this.OpenStorage(this.path);
        }

        public void WriteToStorageDefault()
        {
            this.WriteToStorage(this.path);
        }

        public void CreateAccount(Account acc)
        {
            accounts.Add(acc);
            Console.WriteLine($"Account with ID = {acc.Id} has been succesfully created");
            this.WriteToStorageDefault();
        }

        public void CloseAccount (int id)
        {
            Account acc = accounts.Find(i => i.Id == id);   
            
            if(acc != null)
            {
                Console.WriteLine($"Account with ID = {acc.Id}, belongs to {acc.FirstName} {acc.LastName}\nBalance: {acc.Sum}\nClose account? Y/N");
                if(Console.ReadLine().ToLowerInvariant() == "y")
                {
                    accounts.Remove(acc);
                    Console.WriteLine($"Account with ID = {id} has been successfully closed");
                    this.WriteToStorageDefault();
                }
            }
            else
            {
                Console.WriteLine("There is no account with such ID");
            }            
        }

        public void DisplayAccounts()
        {
            foreach(Account acc in accounts)
            {
                Console.WriteLine($"{acc.Id}, {acc.FirstName}, {acc.LastName}, {acc.Sum}, {acc.Bonus}, {acc.accountStatus}");
            }
        }

        public void DisplayAccounts(int id)
        {
            bool exists = false;
            foreach (Account acc in accounts)
            {
                if(acc.Id == id)
                {
                    exists = true;
                    Console.WriteLine($"{acc.Id}, {acc.FirstName}, {acc.LastName}, {acc.Sum}, {acc.Bonus}, {acc.accountStatus}");
                }                
            }
            if(!exists)
            {
                Console.WriteLine("There is no account with such ID");
            }
        }

    }
}
