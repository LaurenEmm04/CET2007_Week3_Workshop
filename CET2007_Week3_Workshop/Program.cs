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
        }
    }




    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"{Name} - £{Price:F2}"); //prints burger - £3.99 Cola - £1.50
        }
    }

    public class Meal : MenuItem
    {
        public Meal(string name, decimal price) : base(name, price) { }
        public override void Describe()  //when overritten, prints
        {
            Console.WriteLine($"Meal: {Name} – £{Price:F2}");  //Meal: Burger - £3.99
        }
    }

    public class Drink : MenuItem
    {
        public string Volume { get; set; }
        public Drink(string name, decimal price, string volume) : base(name, price)
        {
            Volume = volume;
        }

        public override void Describe()  //this is the drinks part thats also overritten
        {
            Console.WriteLine($"Drink: {Name} ({Volume}) - £{Price:F2}");  // turns into Drink: Cola: (500ml) - £1.50
        }
    }
}
