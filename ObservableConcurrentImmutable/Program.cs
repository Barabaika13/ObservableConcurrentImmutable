using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
                Console.WriteLine("Press 'A' to add a new item, 'D' to delete an item, or 'X' to exit.");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.A)
                {
                    DateTime currentTime = DateTime.Now;
                    string newItemName = $"Item from {currentTime}";
                    var newItem = new Item { Id = shop.GetNextItemId(), Name = newItemName };
                    shop.AddItem(newItem);
                }
                else if (key.Key == ConsoleKey.D)
                {
                    Console.Write("Enter the ID of the item to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int itemId))
                    {
                        shop.RemoveItem(itemId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid item ID.");
                    }

                }
                else if (key.Key == ConsoleKey.X)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please press 'A', 'D', or 'X'.");
                }

            }

        }
    }

    public class Shop
    {
        private int nextItemId = 1;

        public ObservableCollection<Item> _items;
        public Shop()
        {
            _items = new ObservableCollection<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(int itemId)
        {
            var itemToRemove = _items.FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
            else
            {
                Console.WriteLine($"Item with ID {itemId} not found");
            }
        }

        public int GetNextItemId()
        {
            return nextItemId++;
        }

    }

    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public Item(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
    }


    public class Customer
    {
        public void OnItemChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Item newItem in eventArgs.NewItems)
                    {
                        Console.WriteLine($"{newItem.Name} added with ID {newItem.Id}");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Item oldItem in eventArgs.OldItems)
                    {
                        Console.WriteLine($"{oldItem.Name} with ID {oldItem.Id} removed");
                    }
                    break;
            }
        }
    }
}