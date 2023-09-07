using System.Collections.Specialized;

namespace ObservableConcurrentImmutable
{
    public class Customer
    {
        public void OnItemChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Item newItem in eventArgs.NewItems)
                    {
                        Console.WriteLine($"Добавлен {newItem.Name} с ID {newItem.Id}");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Item oldItem in eventArgs.OldItems)
                    {
                        Console.WriteLine($"Удален {oldItem.Name} с ID {oldItem.Id}");
                    }
                    break;
            }
        }
    }
}
