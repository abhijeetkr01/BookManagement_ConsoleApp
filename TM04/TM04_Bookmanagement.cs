using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM04
{
    class Author
        {
            private string AuthorName;
            private string AuthorEMail;
            private char Gender;

            public Author(string aname, string email, char gen)
            {
                AuthorName = aname;
                AuthorEMail = email;
                Gender = gen;
            }

            public string _AuthorName
            {
                get
                {
                    return AuthorName;
                }
                set
                {
                    AuthorName = value;
                }
            }
            public string _AuthorEMail
            {
                get
                {
                    return AuthorEMail;
                }
                set
                {
                    AuthorEMail = value;
                }
            }
            public char _Gender
            {
                get
                {
                    return Gender;
                }
                set
                {
                    Gender = value;
                }
            }

            public string DisplayAuthorDetails()
            {
                return "Author Name: " + AuthorName + "\nAuthor Email: " + AuthorEMail + "\nGender: " + Gender;
            }
        }

    class Book
        {
            private string ISBN;
            private string BookName;
            private int YearPublished;
            private decimal Price;
            private Author AuthorDetails;

            public Book() { }

            public Book(string isbn, string bname, int yrpub, decimal price, Author adetails)
            {
                ISBN = isbn;
                BookName = bname;
                YearPublished = yrpub;
                Price = price;
                AuthorDetails = adetails;
            }

            public string _ISBN
            {
                get
                {
                    return ISBN;
                }
                set
                {
                    ISBN = value;
                }
            }
            public string _BookName
            {
                get
                {
                    return BookName;
                }
                set
                {
                    BookName = value;
                }
            }
            public int _YearPublished
            {
                get
                {
                    return YearPublished;
                }
                set
                {
                    YearPublished = value;
                }
            }
            public decimal _Price
            {
                get
                {
                    return Price;
                }
                set
                {
                    Price = value;
                }
            }
            public Author _AuthorDetails
            {
                get
                {
                    return AuthorDetails;
                }
                set
                {
                    AuthorDetails = value;
                }
            }

            public string DisplayBookDetails()
            {
                return "ISBN: " + ISBN + "\nBookName: " + BookName + "\nYear Published: " + YearPublished + "\nPrice: " + Price + "\n" + _AuthorDetails.DisplayAuthorDetails(); ;
            }
        }

    class BookManagement
        {
            private static Book[] Rack = new Book[10];
            private static int j = 0;

            public BookManagement()
            {
                for (int i = 0; i < 10; i++)
                    Rack[i] = new Book();

            }

            public static void AddBook()
            {
                if (j == 10)
                {
                    Console.WriteLine("Rack is filled. Can’t add more books");
                }
                else
                {
                    Console.WriteLine("ISBN: ");
                    string _isbn = Console.ReadLine();
                    Console.WriteLine("Book Name: ");
                    string _bname = Console.ReadLine();
                    Console.WriteLine("Year Publsihed: ");
                    int _yrpb = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Price: ");
                    decimal _price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Author Name: ");
                    string _aname = Console.ReadLine();
                    Console.WriteLine("Author Email: ");
                    string _email = Console.ReadLine();
                    Console.WriteLine("Gender: ");
                    char _gen = Convert.ToChar(Console.ReadLine());

                    Author A1 = new Author(_aname, _email, _gen);
                    Book B1 = new Book(_isbn, _bname, _yrpb, _price, A1);

                    Rack[j]._ISBN = B1._ISBN;
                    Rack[j]._BookName = B1._BookName;
                    Rack[j]._YearPublished = B1._YearPublished;
                    Rack[j]._Price = B1._Price;
                    Rack[j]._AuthorDetails = B1._AuthorDetails;
                    j++;
                }

            }

            public static bool SearchBook()
            {
                string isb;
                Console.WriteLine("Enter Book's ISBN:");
                isb = Console.ReadLine();
                for (int k = 0; k < j; k++)
                {
                    if (Rack[k]._ISBN == isb)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static void UpdateBookDetails()
            {
                string isb;
                Console.WriteLine("Enter Book's ISBN:");
                isb = Console.ReadLine();
                for (int k = 0; k < j; k++)
                {
                    if (Rack[k]._ISBN == isb)
                    {
                        Console.WriteLine("Enter Book Name: ");
                        Rack[k]._BookName = Console.ReadLine();
                        Console.WriteLine("Enter Published Year: ");
                        Rack[k]._YearPublished = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Price: ");
                        Rack[k]._Price = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Author Name: ");
                        Rack[k]._AuthorDetails._AuthorName = Console.ReadLine();
                        Console.WriteLine("Enter Auhtor's Email: ");
                        Rack[k]._AuthorDetails._AuthorEMail = Console.ReadLine();
                        Console.WriteLine("Enter Author's Gender: ");
                        Rack[k]._AuthorDetails._Gender = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("\nDetails Updated.");
                        break;
                    }
                    else
                        Console.WriteLine("ISBN not matched.");
                }
            }

            public static void ViewBooks()
            {

                for (int k = 0; k < j; k++)
                {
                    Console.WriteLine("\nDetials of Book {0}", k + 1);
                    Console.WriteLine(Rack[k].DisplayBookDetails());
                }
            }

            public static void ViewAuthor()
            {
                for (int k = 0; k < j; k++)
                {
                    Console.WriteLine("\nDetials of Authors {0}", k + 1);
                    Console.WriteLine(Rack[k]._AuthorDetails.DisplayAuthorDetails());
                }
            }
        }

    class TM04_Bookmanagement
    {
        public static void Menu()
        {
            Console.WriteLine("\n\n\t\tBook Author Details");
            Console.WriteLine("1. Add Book.");
            Console.WriteLine("2. Search Book.");
            Console.WriteLine("3. Update Book.");
            Console.WriteLine("4. View All Book.");
            Console.WriteLine("5. View All Authors.");
            Console.WriteLine("6. Exit");
            Console.WriteLine("\nPlease enter your choice::");
        }

        public static void Main()
        {
            int i = 0;
            BookManagement BM1 = new BookManagement();

            do
            {
                Menu();
                i = Convert.ToInt16(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        BookManagement.AddBook();
                        break;
                    case 2:
                        Console.WriteLine(BookManagement.SearchBook());
                        break;
                    case 3:
                        BookManagement.UpdateBookDetails();
                        break;
                    case 4:
                        BookManagement.ViewBooks();
                        break;
                    case 5:
                        BookManagement.ViewAuthor();
                        break;
                    default:
                        Console.WriteLine("EXITING.");
                        break;
                }
            } while (i != 6);
        }
    }
}

