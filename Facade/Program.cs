namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mortgage mortgage = new Mortgage();
            Customer customer = new Customer("Andy", 12500);
            bool eligable = mortgage.IsEligible(customer);
            Console.WriteLine("Result：" + customer.Name + " has been " + (eligable ? "Approved" : "Rejected"));
            Console.ReadLine();
        }
    }

    //銀行子系統
    public class Bank
    {
        public bool HasSufficientSavings(Customer c)
        {
            Console.WriteLine("Check bank account name： " + c.Name + " Application amount:" + c.Amount);
            return true;
        }
    }

    //信用子系統
    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check customer credit：" + c.Name);
            return true;
        }
    }

    //貸款子系統
    public class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    public class Customer(string name, decimal amount)
    {
        public string Name { get; set; } = name;
        public decimal Amount { get; set; } = amount;
    }

    public class Mortgage
    {
        private Bank bank = new Bank();
        private Loan loan = new Loan();
        private Credit credit = new Credit();

        public bool IsEligible(Customer customer)
        {
            Console.WriteLine("{0} applies for {1:C} loan ", customer.Name, customer.Amount);
            bool eligible = true;

            if (!bank.HasSufficientSavings(customer))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(customer))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                eligible = false;
            }

            return eligible;
        }

    }
}
