namespace Product
{

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Создание корректных объектов для тестирования
            Console.WriteLine("=== Класс Product ===");
            
            // Товар 1
            Product product1 = new Product("Телевизор", 60000, 7);
            product1.PrintInfo();


            // Товар 2
            Product product2 = new Product("Книга", 1289, 12);
            
            product2.Quantity = -12;
            product2.PrintInfo();
            



            Console.WriteLine($"Общая стоимость: {product2.GetTotalCost()}");
            

            // Проверка изменения свойств
            Console.WriteLine("=== Изменение свойств ===");
            product1.Price = 45000;  
            product1.Quantity = 3;   
            product1.PrintInfo();

            // Проверка валидации
            Console.WriteLine("=== Валидация ===");
            Product invalidProduct = new Product("Неверный товар", -432, 5); // Цена не может быть отрицательной
            
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка валидации: {ex.Message}");
        }

        try
        {
            Product invalidProduct2 = new Product("", 100, 5); // Пустое название
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка валидации: {ex.Message}");
        }

        try
        {
            Product invalidProduct3 = new Product("Товар", 100, -5); // Отрицательное количество
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка валидации: {ex.Message}");
        }
    }
}
}
