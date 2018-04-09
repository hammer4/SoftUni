using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User
{
    private HashSet<Category> categories;

    public User(string name)
    {
        this.Name = name;
        this.categories = new HashSet<Category>();
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<Category> Categories
    {
        get
        {
            return this.categories.ToList().AsReadOnly();
        }
    }

    public void AssignToCategory(Category category)
    {
        this.categories.Add(category);
    }
}