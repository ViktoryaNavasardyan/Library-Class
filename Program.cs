using System;
using System.Collections.Generic;
using library_class.Folder;


namespace library_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Library openning and closing time.
            Console.WriteLine($"Our libraries open at {Library.openingTime} and close at {Library.closingTime}.");
            BooksSectionsLibrary();
            SearchRemove();
            FindAndGiveBooks();
            
        }
        //Adding books and section into Library 1
        static void BooksSectionsLibrary()
        {
            Book book1 = new Book("Life of Pi", "Yann Martel", "Action", 326);
            Book book2 = new Book("Little Women", "Louisa May Alcott", "Classics", 528);
            Book book3 = new Book("The Adventures of Sherlock Holmes", "Sir Arthur Conan Doyle", "Detective", 164);
            Book book4 = new Book("Bird Box", "Josh Malerman", "Horror", 305);
            Book book5 = new Book("Harry Potter and the Order of the Phoenix", "Joanne Rowling", "Action", 766);
            Book book6 = new Book("1984", "George Orwell", "Classics", 320);
            Book book7 = new Book("Pride and Prejudice", "Jane Austen", "Classecs", 384);
            Book book8 = new Book("The Cat in the Hat", "Theodor Seuss Geisel", "Story", 61);
            Book book9 = new Book("Charlie and the Chocolate Factory", "Roald Dahl", "Novel", 30);
            Book book10 = new Book("Wonder", "Raquel Jaramillo Palacio", "Novel", 310);
            List<Book> ForAdults = new List<Book>() { book1, book2, book3, book4, book5, book6, book7 };
            List<Book> ForKids = new List<Book>() { book8, book9, book10 };
            Section Adults = new Section(ForAdults, "Adults");
            Section Kids = new Section(ForKids, "Kids");
            List<Section> MySections = new List<Section>() { Adults, Kids };
            Library MyLibrary = new Library(MySections);
            MyLibrary.ShowLibrary();
        }

        //Creating sections and adding sections and books into library 2.
        //Search some book, remove it, after that repead searching. Removing the section
        static void SearchRemove()
        {
            Library MySecondLibrary = new Library();
            //Create new section by name "study".
            Section Study = new Section("Study");
            //create book
            Book book = new Book("Grock algorithms", "Aditya Bhargava", "Programming", 500);
            //add the book into the section
            Study.AddBook(book);
            //add another book into the same section 
            Study.AddBook("Linar Algebra", "Aleqsanyan", "Algebra", 450);
            //add section into library
            MySecondLibrary.AddSection(Study);

            //Show "Study" section
            //MySecondLibrary.GetSection[MySecondLibrary.FindIndexOfSection("Study")].ShowSection();

            //Add new section by name
            MySecondLibrary.AddSection("Tests");
            //Add book into library in section Tests.
            MySecondLibrary.GetSection[MySecondLibrary.FindIndexOfSection("Tests")].AddBook("Harcashar", 3);

            //Show "Tests" Section
            //MySecondLibrary.GetSection[MySecondLibrary.FindIndexOfSection("Tests")].ShowSection();

            //Print My Library
            MySecondLibrary.ShowLibrary();

            //Search some book, remove it, after that repead searching
            Book resultBook = new Book();
            if (MySecondLibrary.GetSection[MySecondLibrary.FindIndexOfSection("Tests")].SearchBook("Harcashar", out resultBook))
            {
                Console.WriteLine("Here is searched book->");
                resultBook.ShowBook();
                Console.WriteLine("We find the book, so now we can remove it.");
                MySecondLibrary.GetSection[MySecondLibrary.FindIndexOfSection("Tests")].RemoveBook("Harcashar", null);
                Console.WriteLine("Repead searching to make sure that the book was removed.");
                if (!MySecondLibrary.GetSection[MySecondLibrary.FindIndexOfSection("Tests")].SearchBook("Harcashar", out resultBook))
                {
                    Console.WriteLine("The book was removed.");
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Removing is not succeed.");
            }
            else
                Console.WriteLine("The book was not found.");
            //trying remove section "Tests"
            Section resultSection = new Section();
            if (MySecondLibrary.SearchSection("Tests", out resultSection))
            {
                Console.WriteLine("Here is searched section->");
                resultSection.ShowSection();
                Console.WriteLine("We find the section, so now we can remove it.");
                MySecondLibrary.RemoveSection("Tests");
                Console.WriteLine("Repead searching to make sure that the section was removed.");
                if (!MySecondLibrary.SearchSection("Tests", out resultSection))
                {
                    Console.WriteLine("The section was removed.");
                }
                else
                    Console.WriteLine("Removing is not succeed.");
            }
            else
                Console.WriteLine("The section was not found.");

        }

        //Add books to the library 3, find books by giving genre, giving to the person,checking available books
        //and all books after giving
        static void FindAndGiveBooks()
        {
            Library MyThirdLibrary = new Library();
            MyThirdLibrary.AddSection("English");
            MyThirdLibrary.AddSection("Russian");
            MyThirdLibrary.AddSection("Armenian");
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("English")].AddBook("Engish First Class", "School", "First Class", 58);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("English")].AddBook("English Second Class", "School", "Second Class", 50);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("English")].AddBook("English Third Class", "School", "Third Class", 70);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("Russian")].AddBook("Russian First Class", "School", "First Class", 40);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("Russian")].AddBook("Russian Second Class", "School", "Second Class", 57);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("Russian")].AddBook("Russian Third Class", "School", "Third Class", 60);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("Armenian")].AddBook("Armenian First Class", "School", "First Class", 42);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("Armenian")].AddBook("Armenian Second Class", "School", "Second Class", 37);
            MyThirdLibrary.GetSection[MyThirdLibrary.FindIndexOfSection("Armenian")].AddBook("Armenian Third Class", "School", "Third Class", 64);
            MyThirdLibrary.ShowLibrary();
            //Someone wanted to find books of first class.
            List<Book> FirstClassBooks = new List<Book>();
            FirstClassBooks = MyThirdLibrary.GetBooksByGenre("First Class");
            Console.WriteLine("Books of First Class ->");
            foreach (Book books in FirstClassBooks)
            {
                books.ShowBook();
                Console.WriteLine("------------");
            }
            //now the person want to take the books of first class
            Console.WriteLine("We give books of first class to person.----");
            for (int i = 0; i < MyThirdLibrary.GetSection.Count; i++)
            {
                int index = MyThirdLibrary.GetSection[i].FindIndexOfBookByGenre("First Class");
                if (index == -1)
                {
                    Console.WriteLine("The book was not found.");
                }
                else
                    MyThirdLibrary.GetSection[i].GiveBookToTheCustomer(index);
            }
            //checking available books
            Console.WriteLine("After giving some books to person, let's check available books.");
            List<Book> AvailableBooks = new List<Book>();
            for (int i = 0; i < MyThirdLibrary.GetSection.Count; i++)
            {
                AvailableBooks = MyThirdLibrary.SearchAvailableBooks();
            }
            foreach (Book books in AvailableBooks)
            {
                books.ShowBook();
                Console.WriteLine("------------");
            }
            Console.WriteLine("After giving some books to person, let's check all books.");
            List<Book> AllBooks = new List<Book>();
            for (int i = 0; i < MyThirdLibrary.GetSection.Count; i++)
            {
                AllBooks = MyThirdLibrary.GetAllBooks();
            }
            foreach (Book books in AllBooks)
            {
                books.ShowBook();
                Console.WriteLine("------------");
            }
        }
    }
}
