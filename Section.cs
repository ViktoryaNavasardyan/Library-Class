using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_class.Folder
{
    class Section
    {
        protected List<Book> book;
        protected string _name;
        public int GetBookCount { get => book.Count(); }
        public List<Book> Book { get => book; }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public Section() 
        { 
            book = new List<Book>(); 
            
        }
        public Section(List<Book> books, string name) : this()
        {
            Name = name;
            for (int i = 0; i < books.Count(); i++)
            {
                book.Add(books[i]);
            }
        }
        public Section(string name) : this()
        {
            Name = name;
        }
        public int FindIndexOfBook(Book searchedBook)
        {
            int index = -1;
            for (int i = 0; i < GetBookCount; i++)
            {
                if (searchedBook.Name == book[i].Name && searchedBook.Author == book[i].Author && book[i]._isAvailable)
                    index = i;
            }
            return index;
        }
        public int FindIndexOfBook(string name, string genre)
        {
            int index = -1;
            for (int i = 0; i < GetBookCount; i++)
            {
                if (name == book[i].Name && book[i]._isAvailable && genre == book[i].Genre)
                    index = i;
            }
            return index;
        }
        public int FindIndexOfBookByGenre(string genre)
        {
            int index = -1;
            for (int i = 0; i < GetBookCount; i++)
            {
                if (book[i]._isAvailable && genre == book[i].Genre)
                    index = i;
            }
            return index;
        }
        public List<Book> FindByGenre(string searchedGenre)
        {
            List<Book> wantedList = new List<Book>();
            for (int i = 0; i < GetBookCount; i++)
            {
                if (book[i].Genre == searchedGenre && book[i]._isAvailable)
                    wantedList.Add(book[i]);
            }
            return wantedList;
        }
        public bool SearchBook(string name, out Book finalBook)
        {
            for (int i = 0; i < GetBookCount; i++)
            {
                if (book[i].Name == name && book[i]._isAvailable)
                {
                    finalBook = book[i];
                    return true;
                }
            }
            //The section doesn't include this book.
            finalBook = null;
            return false;
        }
        public void GiveBookToTheCustomer(int index)
        {
            if (book[index]._isAvailable)
            {
                book[index]._isAvailable = false;
                return;
            }
            //The book is not available.
            return;
        }
        public void AddBook(Book addedBook)
        {
            book.Add(addedBook);
        }
        public void AddBook(string name, int pages)
        {
            Book tempBook = new Book(name, pages);
            this.AddBook(tempBook);
        }
        public void AddBook(string name, string author, int pages)
        {
            Book tempBook = new Book(name, author, pages);
            this.AddBook(tempBook);
        }
        public void AddBook(string name, string author, string genre)
        {
            Book tempBook = new Book(name, author, genre);
            this.AddBook(tempBook);
        }
        public void AddBook(string name, string author, string genre, int pages)
        {
            Book tempBook = new Book(name, author, genre, pages);
            this.AddBook(tempBook);
        }
        public void RemoveBook(Book removedBook)
        {
            if (FindIndexOfBook(removedBook) == -1)
                return;
            book.Remove(removedBook);
        }
        public bool RemoveBook(string name, string genre)
        {
            if (FindIndexOfBook(name, genre) == -1)
                return false;
            book.Remove(book[FindIndexOfBook(name, genre)]);
            return true;
        }
        public void ShowSection()
        {
            if(GetBookCount == 0)
            {
                Console.WriteLine($"In {Name} section  there are no books.");
                return;
            }
            Console.WriteLine($"In {Name} section  there are {GetBookCount} book(s), which are ");
            for (int i = 0; i < GetBookCount; i++)
            {
                book[i].ShowBook();
                Console.WriteLine("-----------------");
            }
         
        }
    }
    
   
}
