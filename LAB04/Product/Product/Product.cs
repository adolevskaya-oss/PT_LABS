namespace Product
{
    public class Product
    {
        private string name;
        private decimal price;
        private int quantity;

        public Product(string name, decimal price, int quantity)
        {
            this.Name = name;      
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название товара не может быть пустым");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Цена не может быть отрицательной");
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество не может быть отрицательным");
                }
                this.quantity = value;
            }
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Товар: {Name}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Количество: {Quantity}");
            Console.WriteLine($"Общая стоимость: {GetTotalCost()} руб.");
            Console.WriteLine("   ");
        }
    }
}