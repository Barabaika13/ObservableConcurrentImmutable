using System.Collections.Concurrent;

namespace Concurrent
{
    internal class Program
    {
        static ConcurrentDictionary<string, int> books = new ConcurrentDictionary<string, int>();

        static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            // Start the background task
            //Task backgroundTask = UpdateBookPercentagesAsync(cancellationTokenSource.Token);
            Task backgroundTask = Task.Run(() => UpdateBookPercentagesAsync(cancellationTokenSource.Token));

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Add a book");
                Console.WriteLine("2 - Display a list of unread books");
                Console.WriteLine("3 - Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the title of the book: ");
                        string title = Console.ReadLine();
                        AddBook(title);
                        break;
                    case "2":
                        DisplayUnreadBooks();
                        break;
                    case "3":
                        cancellationTokenSource.Cancel(); // Signal the background task to exit
                        await backgroundTask; // Wait for the background task to complete
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddBook(string title)
        {
            books.TryAdd(title, 0);
        }

        static void DisplayUnreadBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Key} - {book.Value}%");
            }
        }

        static async Task UpdateBookPercentagesAsync(CancellationToken cancellationToken)
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
                            // Remove the book if it's 100% read
                            books.TryRemove(book.Key, out int value);
                        }
                    }
                }
                await Task.Delay(1000); // Sleep for 1 second asynchronously
            }
        }
    }
}