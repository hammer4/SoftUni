using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author,string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    private string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            if(value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    private string Author
    {
        get
        {
            return this.author;
        }

        set
        {
            if (value.Split().Length > 1 && Char.IsDigit(value.Split()[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    protected virtual decimal Price
    {
        get
        {
            return this.price;
        }

        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine +
            $"Title: {this.Title}" + Environment.NewLine +
            $"Author: {this.Author}" + Environment.NewLine +
            $"Price: {this.Price:f2}";

    }
}
