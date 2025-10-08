using System;

namespace CET2007w3
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
}
