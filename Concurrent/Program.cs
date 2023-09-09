using System.Collections.Concurrent;

namespace Concurrent
{
    internal class Program
    {
        static ConcurrentDictionary<string, int> books = new ConcurrentDictionary<string, int>();

        static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();            
            var task = Task.Run(() => UpdatePercentagesAsync(cancellationTokenSource.Token));
            //var task = UpdatePercentagesAsync(cancellationTokenSource.Token);
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Добавить книгу");
                Console.WriteLine("2 - Вывести список книг");
                Console.WriteLine("3 - Выйти");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название книги: ");
                        string title = Console.ReadLine();
                        AddBook(title);
                        break;
                    case "2":
                        ShowBooks();
                        break;
                    case "3":
                        cancellationTokenSource.Cancel();
                        await task;
                        Console.WriteLine("Выход");
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }

        static void AddBook(string title)
        {
            books.TryAdd(title, 0);
        }

        static void ShowBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Key} - {book.Value}%");
            }
        }

        static async Task UpdatePercentagesAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var book in books)
                {
                    int currentPercentage = book.Value;
                    if (currentPercentage < 100)
                    {
                        int newPercentage = currentPercentage + 1;
                        books.TryUpdate(book.Key, newPercentage, currentPercentage);
                        if (newPercentage == 100)
                        {                            
                            books.TryRemove(book.Key, out int value);
                        }
                    }
                }
                await Task.Delay(1000);
            }
        }
    }
}