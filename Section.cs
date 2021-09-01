using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_class.Folder
{
    class Section
    {
        //sections uzum em unena grqer, ashxatoxner u janr
        Book[] book = new Book[100];
        Employee[] employee = new Employee[50];
        static int b_count = 0;
        static int e_count = 0;
        string _sectionGenre;
        public string SectionGenre
        {
            get => _sectionGenre;
            set
            {
                if (value != "gitakan" && value != "gexarvestakan" && value != "erajshtakan"
                    && value != "gexankarchakan" && value != "mankakan" && value != "bjshkakan")
                {
                    Console.WriteLine("This is not a valid ganre.Try again.");
                    value = Console.ReadLine();
                }
                else _sectionGenre = value;
            }
        }
        public Section(string genre)
        {
            SectionGenre = genre;
        }
        public void AddBook(int index, string name, string autor, string genre, string aboutbook)
        {
            book[index].Name = name;
            book[index].Autor = autor;
            book[index].Genre = genre;
            book[index].About = aboutbook;
            b_count++;
        }
        public void AddEmployee(int index, string name, DateTime dt, int salary)
        {
            employee[index].Name = name;
            employee[index].start = dt;
            employee[index].Salary = salary;
        }
        public void ShowSection()
        {
            Console.WriteLine($@"In this section there are {b_count} books, which are ");
            for (int i = 0; i < b_count; i++)
            {
                book[i].ShowBook();
            }
            Console.WriteLine("Employees are ");
            for (int i = 0; i < e_count; i++)
            {
                employee[i].ShowEmployee();
            }
        }
    }
    struct Book
    {
        string _name, _autor, _genre, _about;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Autor
        {
            get => _autor;
            set => _autor = value;
        }
        public string Genre
        {
            get => _genre;
            set => _genre = value;
        }
        public string About
        {
            get => _about;
            set => _about = value;
        }
        public void ShowBook()
        {
            Console.WriteLine($@" Name --- {_name}
Autor --- {_autor}
Ganre --- {_genre}
About book --- {_about}");
        }
        
    }
    struct Employee
    {
        public DateTime start;
        string name;
        int salary;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Salary
        {
            get => salary;
            set
            {
                if (value < 30000)
                {
                    Console.WriteLine("Salary can nor be under 30000.");
                    salary = 30000;
                }
                else
                    salary = value;
            }
        }
        public void ShowEmployee()
        {
            Console.WriteLine($@" Name --- {name}
Start --- {start}
Salary --- {salary}");
        }
    }
}
