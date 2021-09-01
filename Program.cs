using System;

namespace library_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Library openning and closing time.
            Console.WriteLine($"Our library opens at {Library.openingTime} and closes at {Library.closingTime}.");
            //Create library
            int count;
            Console.WriteLine("Please input the count of library's sections, more than 0.");
            String UserInput = Console.ReadLine();
            while (!int.TryParse(UserInput, out count))
            {
                Console.WriteLine("Not a valid number, try again.");

                UserInput = Console.ReadLine();
            }
            Library MyLibrary = new Library(count);
            MyLibrary.ShowLibrary();
        }
    }
}
