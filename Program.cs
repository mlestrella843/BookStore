using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyBookstore
{
    class Book
    {
        public string Name { get; set; }
        public int Serial { get; set; }
        public bool Status { get; set; } = false; //flase means available

        public Book(string name, int serial)
        {
            //to do
            Name = name;
            Serial = serial;
        }

        public bool Available()
        {
            //to do
            //should return true if a book is available

            if (Status == false)
            {
       //         Console.WriteLine("El libro esta AVAILABLE libre  " + Status);

                return true;
            }

        //    Console.WriteLine("El libro no esta available  " + Status);
            return false;
        }

        public void Rent()
        {
            if (Status == false)
            {
                //A book can be rented if it's rental status is false
                Status = true;
               // Console.WriteLine("Book:\'" + Name + "\' sucessfully rented");
            }
            else
            {
                //otherwise, the book is not available.
              //  Console.WriteLine("Book:\'" + Name + "\' is already rented");
            }
        }

        public void Return()
        {
            if (Status == true)
            {
                //A book can be returned only if, it was rented before!
                Status = false;
                Console.WriteLine("Book:" + Name + " sucessfully returned");
            }
            else
            {
                // rent status false means, it is available in the store.
                // Therefore, you should generate error message if some users tries to return this book.

                Console.WriteLine("Book has not been rented");
            }
        }


        public void BookInfo()
        {
            //Show name of the book, it's serial and rental status.

            bool variable;

            if (Status == true)
            {
                variable = true;
            }
            else
            {
                variable = false;
            }

          //  Console.WriteLine(name + " is " + (movie._rented ? "rented" : "available"));

            Console.WriteLine("Book Name: " + Name + "  Serial: " + Serial + " Status : " + (variable ? "Rented" : "Available"));       

        }
    }


    class Reader
    {
        public string Name { get; set; }
        public List<Book> books;

        public Reader(string name)
        {
            Name = name;
            books = new List<Book>();
        }

        public void RentABook(Book book)
        {
            //to do
            //user is allowed to rent maximum two books at a time.
            //issue error message, if users want to rent more than two books.

            if (books.Count < 2) //if user currently has less than 2 books rented
            {
                books.Add(book); //Add book to users rented books
                book.Rent(); //rent the book
                Console.WriteLine("Book: '" + book.Name + "' succesfully rented");
            }
            else if (book.Available() == true)
            {
                Console.WriteLine("Sorry! " + Name + ", You cannot rent more than two books!");
            }

        }


        public void ReturnABook(Book book)
        {
            //to do
            //return a book, means change book status and remove the book for the readers list.

            book.Return();

            if (books.Contains(book))
            {
                books.Remove(book);
            }

            
        }

        public void ReaderInfo()

        //to do
        //show reader's name and the list of books rented by the reader.
        {
            if (books.Count == 0)
            {
                return;
            }
            Console.WriteLine("Reader " + Name + " rented following books:");
            foreach (Book books1 in books)
            {
                books1.BookInfo();
            }

        }

    }





    class BookStore
    {
        public List<Book> books;
        public List<Reader> readers;

        public BookStore()
        {
            //to do
            //initialize book store
            books = new List<Book>();
            readers = new List<Reader>();

            return;

        }


        public void AddAReader(string name)

        {
            //add a new reader to the bookstore's reader list.
            readers.Add(new Reader(name));

        }


        public void RemoveAReader(string name)
        {

            //to do
            //remove a reader, therefore, first return all books(if any) rented by the reader then remove the reader.

            int count_reader = readers.Count;
            int i = 0;
            while (i < count_reader)
            {
                Reader reader = readers[i];

                if (reader.Name.Equals(name))
                {
                    foreach (Book book in reader.books)
                    {
                        book.Return();
                    }
                    readers.Remove(reader);
                    return;
                }
                else
                {
                    i++;
                }
            }
        }

            public void AddABook(string name, int serial)
        {
            //to do
            // add a book object to the bookstore's book list.

            books.Add(new Book(name, serial));


        }


        public void RemoveABook(string name, int serial)
        {
            int i = 0;
            int nbooks = books.Count;
            while (i < nbooks)
            {
                if (books[i].Name.Equals(name) && books[i].Serial.Equals(serial))
                {
                    if (books[i].Status)
                    {
                        i++;
                        Console.WriteLine("Sorry! \'" + books[i].Name + "\' is already rented. System cannot remove a rented book!");
                    }
                    else
                    {
                        books.Remove(books[i]);
                        nbooks--;
                    }
                }
                else
                {
                    i++;
                }

            }
            //to do
            //remove a book from book store. Only allowed if bookstore already have the book 'available'!
            //Otherwise, issue an error message because the book is already issued by some reader!
        }


        public void RentABook(string name, string book)
        {
            foreach (Reader reader in readers)
            {
                if (reader.Name.Equals(name))
                {
                    foreach (Book item in books)
                    {
                        if (!item.Status && item.Name.Equals(book))
                        {
                            reader.RentABook(item);
                            return;
                        }
                    }
                }
            }
            //to do
            // A book can be rented, if it is available to the store and not already rented to somone else!
        }

        public void ReturnABook(string name, string book, int serial)
        {
            foreach (Reader reader in readers)
            {
                if (reader.Name.Equals(name))
                {
                    foreach (Book item in books)
                    {
                        if (item.Name.Equals(book) && item.Serial == serial)
                        {
                            reader.ReturnABook(item);
                        }
                    }
                }
            }
            //A book can be returned by a reader, if he/she actually rented the book.
        }


        public void ShowBookstoreInformation()
        {
            foreach (Reader reader in readers)
            {
                reader.ReaderInfo();
            }
            Console.WriteLine("The bookstore have following books available:");
            foreach (Book item in books)
            {
                if (!item.Status)
                {
                    item.BookInfo();
                }
            }
            //to do
            //show bookstore information
            //first show all books that are already rented to some readers.
            //then show all books thar are available to the store.
        }
    }





            class Program
         {
            static void Main(string[] args)
            {
            BookStore bs = new BookStore();
            bs.AddAReader("Emmanuel");
            bs.AddAReader("Vinci");
            bs.AddAReader("Supreet");
            bs.AddABook("Object Oriented Programming", 1);
            bs.AddABook("Object Oriented Programming", 2);
            bs.AddABook("Object Oriented Programming", 3);
            bs.AddABook("Programming Fundamentals", 1);
            bs.AddABook("Programming Fundamentals", 2);
            bs.AddABook("Let us C#", 1);
            bs.AddABook("Programming is Fun", 1);
            bs.AddABook("Life is Beautiful", 1);
            bs.AddABook("Let's Talk About the Logic", 1);
            bs.AddABook("How to ace a job interview", 1);
            bs.ShowBookstoreInformation();

            Console.WriteLine();
            bs.RentABook("Emmanuel", "Object Oriented Programming");
            bs.RentABook("Emmanuel", "How to ace a job interview");
            bs.RentABook("Emmanuel", "Life is Beautiful");
            Console.WriteLine();


            bs.RentABook("Vinci", "Object Oriented Programming");
            bs.RentABook("Vinci", "Programming Fundamentals");
            Console.WriteLine();

            bs.RentABook("Supreet", "Let's Talk About the Logic");
            Console.WriteLine();
            bs.ShowBookstoreInformation();
            Console.WriteLine();


            bs.ReturnABook("Emmanuel", "Object Oriented Programming", 1);
            bs.RentABook("Emmanuel", "Life is Beautiful");
            Console.WriteLine();


            bs.RemoveABook("Let us C#", 1);
            bs.RemoveABook("Let's Talk About the Logic", 1);
            Console.WriteLine();

            bs.RemoveAReader("Emmanuel");
            Console.WriteLine();
            bs.ShowBookstoreInformation();


        }
        }
    }






/*
 Once Executed, Your program will have the following output:

The bookstore have following books available:
Book Name: Object Oriented Programming, Serial: 1, Status: Available
Book Name: Object Oriented Programming, Serial: 2, Status: Available
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamntals, Serial: 1, Status: Available
Book Name: Programming Fundamntals, Serial: 2, Status: Available
Book Name: Let us C#, Serial: 1, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available
Book Name: Let's Talk About the Logic, Serial: 1, Status: Available
Book Name: How to ace a job interview, Serial: 1, Status: Available

Book: 'Object Oriented Programming' successfully rented.
Book: 'How to ace a job interview' successfully rented.
Sorry! Emmanuel, You cannot rent more than two books!

Book: 'Object Oriented Programming' successfully rented.
Book: 'Programming Fundamntals' successfully rented.

Book: 'Let's Talk About the Logic' successfully rented.

Reader Emmanuel rented following books:
Book Name: Object Oriented Programming, Serial: 1, Status: Rented
Book Name: How to ace a job interview, Serial: 1, Status: Rented
Reader Vinci rented following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamntals, Serial: 1, Status: Rented
Reader Supreet rented following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented
The bookstore have following books available:
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamntals, Serial: 2, Status: Available
Book Name: Let us C#, Serial: 1, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available

Book: Object Oriented Programming successfully returned.
Book: 'Life is Beautiful' successfully rented.

Sorry! 'Let's Talk About the Logic' is already rented. Syatem cannot remove a rented book!

Book: How to ace a job interview successfully returned.
Book: Life is Beautiful successfully returned.

Reader Vinci rented following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamntals, Serial: 1, Status: Rented
Reader Supreet rented following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented
The bookstore have following books available:
Book Name: Object Oriented Programming, Serial: 1, Status: Available
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamntals, Serial: 2, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available
Book Name: How to ace a job interview, Serial: 1, Status: Available

C:\Program Files\dotnet\dotnet.exe (process 9596) exited with code 0.
Press any key to close this window . . .
 */





