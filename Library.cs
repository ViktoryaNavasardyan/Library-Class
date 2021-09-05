using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_class.Folder
{
    class Library
    {
        public static string openingTime = "9:30";
        public static string closingTime = "18:30";
        protected List<Section> section;
        public List<Section> GetSection { get => section; }
        public Library() { section = new List<Section>(); }
        public Library(List<Section> sections) : this()
        {
            for (int i = 0; i < sections.Count(); i++)
            {
                section.Add(sections[i]);
            }
        }
        public int FindIndexOfSection(Section searchedSection)
        {
            int index = -1;
            for (int i = 0; i < section.Count(); i++)
            {
                if (searchedSection.Name == section[i].Name)
                    index = i;
            }
            return index;
        }
        //find by name
        public int FindIndexOfSection(string name)
        {
            int index = -1;
            for (int i = 0; i < section.Count(); i++)
            {
                if (section[i].Name == name)
                    index = i;
            }
            return index;
        }
        //search section
        public bool SearchSection(string name, out Section finalSection)
        {
            for (int i = 0; i < section.Count(); i++)
            {
                if (section[i].Name == name)
                {
                    finalSection = section[i];
                    return true;
                }
            }
            //The section doesn't include this book.
            finalSection = null;
            return false;
        }
        //search available books
        public List<Book> SearchAvailableBooks()
        {
            List<Book> result = new List<Book>();
            for (int i = 0; i < section.Count(); i++)
            {
                for (int j = 0; j < section[i].GetBookCount; j++)
                {
                    if (section[i].Book[j]._isAvailable)
                    {
                        result.Add(section[i].Book[j]);
                    }
                }
            }
            return result;
        }
        //getAllBooks
        public List<Book> GetAllBooks()
        {
            List<Book> result = new List<Book>();
            for (int i = 0; i < section.Count(); i++)
            {
                for (int j = 0; j < section[i].GetBookCount; j++)
                {
                        result.Add(section[i].Book[j]);
                }
            }
            return result;
        }
        //Get Section Books by section name
        public List<Book> GetSectionBooksBySectionName(string sectionName)
        {
            List<Book> result = new List<Book>();
            for (int i = 0; i < section.Count(); i++)
            {
                for (int j = 0; j < section[i].GetBookCount; j++)
                {
                    if (section[i].Name == sectionName)
                        result.Add(section[i].Book[j]);
                }
            }
            return result;
        }
        //Get Books By Genre
        public List<Book> GetBooksByGenre(string genre)
        {
            List<Book> result = new List<Book>();
            for (int i = 0; i < section.Count(); i++)
            {
                for (int j = 0; j < section[i].GetBookCount; j++)
                {
                    if (section[i].Book[j].Genre == genre)
                        result.Add(section[i].Book[j]);
                }
            }
            return result;
        }
        public bool SearchBook(Book givingBook, out Book result)
        {
            result = null;
            for (int i = 0; i < section.Count(); i++)
            {
                for (int j = 0; j < section[i].GetBookCount; j++)
                {
                    if (section[i].SearchBook(givingBook.Name, out result))
                        return true;
                }
            }
            //The library doesn't include this book.
            return false;
        }
        //Search book by name
        public bool SearchBook(string name, out Book result)
        {
            result = null;
            for (int i = 0; i < section.Count(); i++)
            {
                for (int j = 0; j < section[i].GetBookCount; j++)
                {
                    if (section[i].SearchBook(name, out result))
                        return true;
                }
            }
            //The library doesn't include this book.
            return false;
        }
        public void AddSection(string sectionName)
        {
            Section addedSection = new Section(sectionName);
            section.Add(addedSection);
        }
        public void AddSection(Section s)
        {
            section.Add(s);
        }
        public bool RemoveSection(string sectionName)
        {
            int resultIndex = FindIndexOfSection(sectionName);
            if ( resultIndex == -1)
            {
                return false;
            }
            section.Remove(section[resultIndex]);
            return true;
            
        }
        public void ShowLibrary()
        {
            Console.WriteLine("In this library there are this sections ->");
            for(int i = 0; i < section.Count(); i++)
            {
                section[i].ShowSection();
            Console.WriteLine("==============================================================================");
            }
        }

    }
}
