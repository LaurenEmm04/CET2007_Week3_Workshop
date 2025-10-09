using System;

namespace CET2007w3
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Hi there! Please choose cash or card payment method.");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Card");
            string PaymentMethod = Console.ReadLine();

            Console.WriteLine("Choose how you would like to be notified of payment");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Text message");
            string Notification = Console.ReadLine();

            Console.WriteLine("Enter item name");
            string Item = Console.ReadLine();

            Console.WriteLine("Enter the total ammount");
            double ammount = Convert.ToDouble(Console.ReadLine());

            IPaymentProcessor paymentProcessor;
            INotifier notifier;

            if (PaymentMethod =="1")
            {
                paymentProcessor = new CardPayment();
            }
            else
            {
                paymentProcessor = new CashPayment();
            }
            if (Notification == "1")
            {
                notifier = new EmailNotifier();
            }
            else
            {
                notifier = new TextNotif();
            }


            paymentProcessor.ProcessPayment(ammount, Item);
            notifier.Notify($"Order has been placed for {Item}. The total is £{ammount:F2}");

                MenuItem[] menu = new MenuItem[2];
            menu[0] = new Meal("Burger", 1.99m);
            menu[1] = new Drink("Cola", 2.20m, "1L");

            foreach (MenuItem item in menu)
            {
                item.Describe();
            }

            MenuItem meal = new Meal("Chicken Nuggets", 6.99m);
            MenuItem drink = new Drink("Sprite", 3.20m, "500ml");
            Console.WriteLine("Meal total for 2 people: £" + meal.CalculateTotal(2));
            Console.WriteLine("Drink total for 2: £" + drink.CalculateTotal(2));
        }
    }




    public abstract class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract decimal CalculateTotal(int quantity);  // abstract methods can't have a body

        public virtual void Describe()
        {
            Console.WriteLine($"{Name} - £{Price:F2}"); // prints burger - £3.99 Cola - £1.50
        }
    }




    public class Meal : MenuItem
    {
        public Meal(string name, decimal price) : base(name, price)
        {

        }

        public override void Describe()  // when overridden, prints
        {
            Console.WriteLine($"Meal: {Name} – £{Price:F2}");  // Meal: Burger - £3.99
        }

        public override decimal CalculateTotal(int quantity)
        {
            decimal tbftax = Price * quantity;
            decimal totalwtax = tbftax * 1.10m; // 10% tax add on
            return totalwtax;
        }
    }




    public class Drink : MenuItem 
    {
        public string Volume { get; set; }

        public Drink(string name, decimal price, string volume) : base(name, price)
        {
            Volume = volume;
        }

        public override void Describe()  // this is the drinks part that's also overridden
        {
            Console.WriteLine($"Drink: {Name} ({Volume}) - £{Price:F2}");  // turns into Drink: Cola (1L) - £2.20
        }

        public override decimal CalculateTotal(int quantity)
        {
            decimal tbftax = Price * quantity;
            decimal totalwtax = tbftax * 1.05m; // 5% tax
            return totalwtax;
        }
    }

    interface IPaymentProcessor
    {
        void ProcessPayment(double amount, string reference);
    }

    interface INotifier
    {
        void Notify(string message);
    }

    public class CardPayment : IPaymentProcessor
    {
        public void ProcessPayment(double ammount, string reference)
        {
            Console.WriteLine($"Card Payment of £{ammount:F2} processed for {reference}");
        }
    }

    public class CashPayment : IPaymentProcessor
    {
        public void ProcessPayment(double amount, string reference)
        {
            Console.WriteLine($"Cash Payment of £{amount:F2} processed for {reference}");
        }
    }


    public class EmailNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class TextNotif : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }
}
