using System;
using System.Collections.Generic;
using System.Text;

public class Book : IComparable<Book>
{
    private List<string> authors;

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.authors = new List<string>(authors);
    }

    public string Title { get; private set; }

    public int Year { get; private set; }

    public IReadOnlyCollection<string> Authors
    {
        get
        {
            return this.authors.AsReadOnly();
        }
    }

    public int CompareTo(Book other)
    {
        if(this.Year.CompareTo(other.Year) != 0)
        {
            return this.Year.CompareTo(other.Year);
        }

        return this.Title.CompareTo(other.Title);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}