using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_class.Folder
{
    class Book
    {
        protected string _name;
        protected string _author;
        protected string _genre;
        protected int _pages;
        public bool _isAvailable;
        public Book() : this(null, null, null, 0, false)
        {   
        }
        public Book(string name, string author, string genre, int pages, bool isAvailable = true)
        {
            _name = name;
            _author = author;
            _genre = genre;
            _pages = pages;
            _isAvailable = isAvailable;
        }
        public Book(string name, string author, string genre) : this(name, author, genre, 0)
        {
        }
        public Book(string name, string author, int pages) : this(name, author, null, pages)
        {
        }
        public Book(string name, int pages) : this(name, null, null, pages)
        {
        }
        public string Name{   get => _name; set => _name = value; }
        public string Author { get => _author; set => _author = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public int Pages { get => _pages; set => _pages = value; }
        public void ShowBook()
        {
            Console.WriteLine($@"             Name --- {Name}
             Author --- {Author}
             Genre --- {Genre}
             Pages --- {Pages}
             Available --- {_isAvailable}");
        }

    }
}
