// Using Interface
/* internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("You're using SBI Bank...");
        IBank sbi = BankFactory.GetBankObject("SBI");
        sbi.BankTransfer();
        sbi.CheckBalanace();
        sbi.ValidateCard();
        sbi.WithdrawMoney();
        sbi.MiniStatement();

        Console.WriteLine("You're using AXIX Bank...");
        IBank axix = BankFactory.GetBankObject("AXIX");
        axix.BankTransfer();
        axix.CheckBalanace();
        axix.ValidateCard();
        axix.WithdrawMoney();
        axix.MiniStatement();
    }

    public interface IBank
    {
        void ValidateCard();
        void WithdrawMoney();
        void CheckBalanace();
        void BankTransfer();
        void MiniStatement();
    }

    public class BankFactory
    {
        public static IBank GetBankObject(string bankType)
        {
            IBank BankObject = null;
            if (bankType == "SBI") {
                BankObject = new SBI();
            }
            else if(bankType == "AXIX")
            {
                  BankObject = new Axix();
            }
            return BankObject;
        }
    }

    public class SBI : IBank
    {
        void IBank.BankTransfer()
        {
            Console.WriteLine("SBI Bank Transfer");
        }

        void IBank.CheckBalanace()
        {
            Console.WriteLine("SBI Check Balance");
        }

        void IBank.MiniStatement()
        {
            Console.WriteLine("SBI Mini Statement");
        }

        void IBank.ValidateCard()
        {
            Console.WriteLine("SBI Validate Card");
        }

        void IBank.WithdrawMoney()
        {
            Console.WriteLine("SBI Withdraw Money");
        }
    }
    public class Axix : IBank
    {
        void IBank.BankTransfer()
        {
            Console.WriteLine("Axix Bank Transfer");
        }

        void IBank.CheckBalanace()
        {
            Console.WriteLine("Axix Check Balance");
        }

        void IBank.MiniStatement()
        {
            Console.WriteLine("Axix Mini Statement");
        }

        void IBank.ValidateCard()
        {
            Console.WriteLine("Axix Validate Card");
        }

        void IBank.WithdrawMoney()
        {
            Console.WriteLine("Axix Withdraw Money");
        }
    }
} */

// Using Abstract Class and Abstract Methods
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("You're using SBI Bank...");
        IBank sbi = BankFactory.GetBankObject("SBI");
        sbi.BankTransfer();
        sbi.CheckBalanace();
        sbi.ValidateCard();
        sbi.WithdrawMoney();
        sbi.MiniStatement();

        Console.WriteLine("You're using AXIX Bank...");
        IBank axix = BankFactory.GetBankObject("AXIX");
        axix.BankTransfer();
        axix.CheckBalanace();
        axix.ValidateCard();
        axix.WithdrawMoney();
        axix.MiniStatement();
    }

    public abstract class IBank
    {
        public abstract void ValidateCard();
        public abstract void WithdrawMoney();
        public abstract void CheckBalanace();
        public abstract void BankTransfer();
        public abstract void MiniStatement();
    }

    public class BankFactory
    {
        public static IBank GetBankObject(string bankType)
        {
            IBank BankObject = null;
            if (bankType == "SBI")
            {
                BankObject = new SBI();
            }
            else if (bankType == "AXIX")
            {
                BankObject = new Axix();
            }
            return BankObject;
        }
    }

    public class SBI : IBank
    {
        public override void BankTransfer()
        {
            Console.WriteLine("SBI Bank Transfer");
        }

        public override void CheckBalanace()
        {
            Console.WriteLine("SBI Check Balance");
        }

        public override void MiniStatement()
        {
            Console.WriteLine("SBI Mini Statement");
        }

        public override void ValidateCard()
        {
            Console.WriteLine("SBI Validate Card");
        }

        public override void WithdrawMoney()
        {
            Console.WriteLine("SBI Withdraw Money");
        }
    }
    public class Axix : IBank
    {
        public override void BankTransfer()
        {
            Console.WriteLine("Axix Bank Transfer");
        }

        public override void CheckBalanace()
        {
            Console.WriteLine("Axix Check Balance");
        }

        public override void MiniStatement()
        {
            Console.WriteLine("Axix Mini Statement");
        }

        public override void ValidateCard()
        {
            Console.WriteLine("Axix Validate Card");
        }

        public override void WithdrawMoney()
        {
            Console.WriteLine("Axix Withdraw Money");
        }
    }
}