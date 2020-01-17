using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    public class Account: IEquatable<Account>, ISerializable
    {
        private static int id = 0;
        private decimal sum;
        private int bonus = 0;

        public Account(string firstName, string lastName, decimal sum, AccountStatus status)
        {
            Id += ++id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.sum = sum;
            this.accountStatus = status;
        }

        public Account(SerializationInfo info, StreamingContext context)
        {
            try
            {
                Account.id = info.GetInt32("static.id");
                FirstName = info.GetString("firstname");
                LastName = info.GetString("lastname");
                sum = info.GetDecimal("sum");
                accountStatus = (AccountStatus)info.GetValue("status", typeof(AccountStatus));
                bonus = info.GetInt32("bonus");
                Id = info.GetInt32("dynamic.id");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("static.id", Account.id, typeof(int));
            info.AddValue("firstname", FirstName, typeof(string));
            info.AddValue("lastname", LastName, typeof(string));
            info.AddValue("sum", sum, typeof(decimal));
            info.AddValue("status", accountStatus, typeof(AccountStatus));
            info.AddValue("bonus", bonus, typeof(int));
            info.AddValue("dynamic.id", Id, typeof(int));
        }

        public int Id { get;}
        
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Sum 
        {
            get
            {
                return this.sum;
            }    
        }
        public int Bonus 
        { 
            get
            {
                return this.bonus;
            }
        }

        public enum AccountStatus { Silver, Gold, Platinum };

        public AccountStatus accountStatus; 

        public virtual void Add (decimal sum)
        {
            this.sum += sum;
            this.BonusModificationAdd();
        }

        public virtual void WithDraw (decimal sum)
        {
            if(this.sum < sum)
            {
                Console.WriteLine($"Insufficient funds in the account id = {this.Id}");
            }
            else
            {
                this.sum -= sum;
                this.BonusModificationWithdraw();                
            }
        }

        protected virtual void BonusModificationAdd()
        {
            switch (this.accountStatus)
            {
                case AccountStatus.Silver:
                    this.bonus += 10;
                    break;
                case AccountStatus.Gold:
                    this.bonus += 20;
                    break;
                case AccountStatus.Platinum:
                    this.bonus += 30;
                    break;
            }
        }

        protected virtual void BonusModificationWithdraw()
        {
            switch (this.accountStatus)
            {
                case AccountStatus.Silver:
                    this.bonus += 5;
                    break;
                case AccountStatus.Gold:
                    this.bonus += 10;
                    break;
                case AccountStatus.Platinum:
                    this.bonus += 15;
                    break;
            }
        }

        public bool Equals(Account acc)
        {
            return this.Id == acc.Id;
        }
    }    
}
