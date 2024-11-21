using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }
}

class Reader
{
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public Reader(string name)
    {
        Name = name;
        BorrowedBooks = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        if (book.IsAvailable)
        {
            BorrowedBooks.Add(book);
            book.IsAvailable = false;
            Console.WriteLine($"{Name} '{book.Title}' атты кітапты алды.");
        }
        else
        {
            Console.WriteLine($"{book.Title} қолжетімсіз.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            BorrowedBooks.Remove(book);
            book.IsAvailable = true;
            Console.WriteLine($"{Name} '{book.Title}' атты кітапты қайтарды.");
        }
        else
        {
            Console.WriteLine($"{book.Title} сізде болған жоқ.");
        }
    }
}

class Librarian
{
    public string Name { get; set; }

    public Librarian(string name)
    {
        Name = name;
    }

    public void AddBook(Library library, Book book)
    {
        library.Books.Add(book);
        Console.WriteLine($"{Name} кітапханаға '{book.Title}' атты кітапты қосты.");
    }
}

class Library
{
    public List<Book> Books { get; set; }
    public List<Reader> Readers { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Readers = new List<Reader>();
    }

    public void ShowAllBooks()
    {
        Console.WriteLine("Кітапханадағы барлық кітаптар:");
        foreach (var book in Books)
        {
            string status = book.IsAvailable ? "Қолжетімді" : "Арендаға алынған";
            Console.WriteLine($"- {book.Title} ({book.Author}) - {status}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        Librarian librarian = new Librarian("Айдана");

        Book book1 = new Book("Егемен Қазақстан", "Ахмет Байтұрсынұлы", "12345");
        Book book2 = new Book("Қазақ әдебиеті", "Мұхтар Әуезов", "67890");

        librarian.AddBook(library, book1);
        librarian.AddBook(library, book2);

        Reader reader = new Reader("Аружан");
        library.Readers.Add(reader);

        reader.BorrowBook(book1);
        reader.BorrowBook(book2);

        reader.ReturnBook(book1);

        library.ShowAllBooks();
    }
}
