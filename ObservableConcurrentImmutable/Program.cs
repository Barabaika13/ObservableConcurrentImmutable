namespace ObservableConcurrentImmutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var customer = new Customer();
            shop._items.CollectionChanged += customer.OnItemChanged;
            //var item1 = new Item(1, "apple");
            //var item2 = new Item(2, "banana");
            //var item3 = new Item(3, "orange");
            //var item4 = new Item(4, "watermelon");
            //shop.AddItem(item1);
            //shop.AddItem(item2);
            //shop.AddItem(item3);
            //shop.AddItem(item4);
            //shop.RemoveItem(item2);
            //shop.RemoveItem(item4);

            //shop.AddItem(new Item { Id = 1, Name = "apple" });
            //shop.AddItem(new Item { Id = 2, Name = "orange" });
            //shop.AddItem(new Item { Id = 3, Name = "banana" });
            //shop.AddItem(new Item { Id = 4, Name = "watermelon" });
            //shop.RemoveItem(2);
            //shop.RemoveItem(4);


            while (true)
            {
                Console.WriteLine("Нажмите A, чтобы добавить товар. Нажмите D, чтобы удалить товар. Нажмите X, чтобы выйти.");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.A)
                {
                    DateTime currentTime = DateTime.Now;
                    string newItemName = $"Товар от {currentTime}";
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