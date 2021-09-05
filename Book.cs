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
        public Book()
        {
            _pages = 0;
            _isAvailable = false;
        }
        public Book(string name, string author, string genre, int pages)
        {
            _name = name;
            _author = author;
            _genre = genre;
            _pages = pages;
            _isAvailable = true;
        }
        public Book(string name, string author, string genre)
        {
            _name = name;
            _author = author;
            _genre = genre;
            _isAvailable = true;
        }
        public Book(string name, string author, int pages)
        {
            _name = name;
            _author = author;
            _pages = pages;
            _isAvailable = true;
        }
        public Book(string name, int pages)
        {
            _name = name;
            _pages = pages;
            _isAvailable = true;
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
