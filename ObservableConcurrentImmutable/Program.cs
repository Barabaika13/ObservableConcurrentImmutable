namespace ObservableConcurrentImmutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var customer = new Customer();
            shop._items.CollectionChanged += customer.OnItemChanged;         

            while (true)
            {
                Console.WriteLine("Нажмите A, чтобы добавить товар. Нажмите D, чтобы удалить товар. Нажмите X, чтобы выйти.");
                var key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.A)
                {
                    DateTime currentTime = DateTime.Now;
                    var newItemName = $"Товар от {currentTime}";
                    var newItem = new Item { Id = shop.GetNextItemId(), Name = newItemName };
                    shop.AddItem(newItem);
                }
                else if (key.Key == ConsoleKey.D)
                {
                    Console.Write("Введите ID товара, который вы хотите удалить: ");
                    if (int.TryParse(Console.ReadLine(), out int itemId))
                    {
                        shop.RemoveItem(itemId);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Введите корректный ID.");
                    }
                }
                else if (key.Key == ConsoleKey.X)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }
        }
    }    
}