using System.Collections.ObjectModel;

namespace ObservableConcurrentImmutable
{
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
                Console.WriteLine($"Товар с ID {itemId} не найден");
            }
        }

        public int GetNextItemId()
        {
            return nextItemId++;
        }
    }
}
