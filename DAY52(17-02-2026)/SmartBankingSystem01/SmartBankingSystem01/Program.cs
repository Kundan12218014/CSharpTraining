namespace SmartBankingSystem01
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    public class MinimumBalanceException : Exception
    {
        public MinimumBalanceException(string message) : base(message) { }
    }
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string message) : base(message) { }
    }
    public abstract class BankAccount
    {
        public String AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }
        protected List<string> TransactionHistory { get; set; } = new List<string>();
        //public BankAccount(string AccountNumber,string CustomerName,double Balance)
        //{
        //    AccountNumber = AccountNumber;
        //    Balance = Balance;
        //    CustomerName = CustomerName;
        //}
        public BankAccount(string accNo, string name, double balance)
        {
            AccountNumber = accNo;
            CustomerName = name;
            Balance = balance;
        }

        public virtual void Deposit(double amount)
        {
            if (amount<= 0)
            {
                throw new InvalidTransactionException("Deposit amount must be Positive.");
            }
            Balance += amount;
            TransactionHistory.Add($"Deposited {amount} on {DateTime.Now}");
        }
        public virtual void WithDraw(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("WithDraw amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient Balance");
            }
            Balance -= amount;
            TransactionHistory.Add($"Withdrawn {amount} on {DateTime.Now}");
        }
        public abstract double CalculateInterest();

        public void ShowHistory()
        {
            Console.WriteLine($"Transaction History for {CustomerName}");
            foreach(var item in TransactionHistory)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class SavingAccount : BankAccount
    {
        private const double MinimumBalance = 1000;
        private const double InterestRate = 0.04;
        public SavingAccount(string accountNo, string name, double balance) : base(accountNo, name, balance)
        {

        }
        public override void WithDraw(double amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                throw new MinimumBalanceException("Minimum balance rule voileted.");
            }
            base.WithDraw(amount);
        }
        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }
    public class CurrentAccount: BankAccount
    {

        private const double  OverDraftLimt=50000;
        public CurrentAccount(string accountNo, string name, double balance) : base(accountNo, name, balance)
        {

        }
        public override void WithDraw(double amount)
        {
            if (Balance - amount < -OverDraftLimt)
            {
                throw new InsufficientBalanceException("Overdraft limit Exceeded");
            }
            Balance -= amount;
            TransactionHistory.Add($"Withdrawn {amount} on {DateTime.Now}");

        }
        public override double CalculateInterest()
        {
            return 0;
        }
    }
    public class LoanAccount: BankAccount
    {
        private const double InterestRate = 0.1;
        public LoanAccount(string accountNumber,string name,double balance) : base(accountNumber, name, balance) { }
        public override void Deposit(double amount)
        {
            throw new InvalidTransactionException("Cannot deposit into loan account");
        }
        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }

    }
    public class BankingSystem
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        public void AddAccount(BankAccount account)
        {
            accounts.Add(account);
        }
        public BankAccount GetAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void Transfer(string fromAcc,string toAcc,double amount)
        {
            var sender = GetAccount(fromAcc);
            var reciver = GetAccount(toAcc);

            if (sender == null || reciver == null)
            {
                throw new InvalidTransactionException("Invalid Account number");
            }

            sender.WithDraw(amount);
            reciver.Deposit(amount);

            Console.WriteLine("Transfer Successful.");
        }
        public void RunLinqQueries()
        {
            Console.WriteLine("\nAccounts with balance > 500000");
            var richAccount = accounts.Where(a => a.Balance > 500000);
            PrintAccount(richAccount);
            Console.WriteLine("\nTotal Bank Balance:");
            Console.WriteLine(accounts.Sum(a=>a.Balance));

            Console.WriteLine("\nTop 3 Highest Balance Account");
            var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
            PrintAccount(top3);

            Console.WriteLine("\nGroup By Account Type: ");
            var grouped = accounts.GroupBy(a => a.GetType().Name);
            foreach(var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach(var acc in group)
                {
                    Console.WriteLine(" "+acc.CustomerName);
                }
            }

            Console.WriteLine("\nCutomers starting with R: ");
            var rCustomers = accounts.Where(a => !string.IsNullOrEmpty(a.CustomerName) && a.CustomerName.StartsWith("R"));
            foreach(var acc in rCustomers)
                Console.WriteLine(acc.CustomerName);

        }
        private void PrintAccount(IEnumerable<BankAccount>bankAccount)
        {
            foreach (var acc in bankAccount)
            {
                Console.WriteLine(acc.CustomerName + " - " + acc.Balance);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            BankingSystem bank = new BankingSystem();
            bank.AddAccount(new SavingAccount("SBI01", "Kundan", 8000000));
            bank.AddAccount(new CurrentAccount("SBI02", "Gautam", 80000000));
            bank.AddAccount(new CurrentAccount("SBI03", "Arti", 80000000));
            bank.AddAccount(new SavingAccount("SBI04", "Nilu", 80000000));
            bank.AddAccount(new LoanAccount("SBI05", "Riya", 120000));

            try
            {
                bank.Transfer("SBI01", "SBI02",10000);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bank.RunLinqQueries();

        }
    }
}
