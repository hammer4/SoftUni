using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TextEditor : ITextEditor
{
    private Trie<Stack<string>> trie;
    private List<string> loggedUsers;
    private List<string> allUsers;


    public TextEditor()
    {
        trie = new Trie<Stack<string>>();
        loggedUsers = new List<string>();
        allUsers = new List<string>();
    }

    public void Clear(string username)
    {
        if (loggedUsers.Contains(username))
        {
            trie.GetValue(username).Push(String.Empty);
        }
    }

    public void Delete(string username, int startIndex, int length)
    {
        if (loggedUsers.Contains(username))
        {
            string oldValue = trie.GetValue(username).Peek();

            if (oldValue.Length >= startIndex + length)
            {
                trie.GetValue(username).Push(oldValue.Substring(0, startIndex) + oldValue.Substring(startIndex + length));
            }
        }
    }

    public void Insert(string username, int index, string str)
    {
        if (loggedUsers.Contains(username))
        {
            string oldValue = trie.GetValue(username).Peek();

            if (oldValue.Length >= index)
            {
                str = str.Substring(1, str.Length - 2);
                string newValue = oldValue.Insert(index, str);
                trie.GetValue(username).Push(newValue);
            }
        }
    }

    public int Length(string username)
    {
        if (loggedUsers.Contains(username))
        {
            return trie.GetValue(username).Peek().Length;
        }

        return 0;
    }

    public void Login(string username)
    {
        if (!allUsers.Contains(username))
        {
            trie.Insert(username, new Stack<string>());
            trie.GetValue(username).Push(String.Empty);
            allUsers.Add(username);
        }

        if (!this.loggedUsers.Contains(username))
        {
            loggedUsers.Add(username);
        }
        else
        {
            trie.Insert(username, new Stack<string>());
            trie.GetValue(username).Push(String.Empty);
        }
    }

    public void Logout(string username)
    {
        loggedUsers.Remove(username);
        trie.GetValue(username).Push(String.Empty);
    }

    public void Prepend(string username, string str)
    {
        if (loggedUsers.Contains(username))
        {
            str = str.Substring(1, str.Length - 2);
            string oldValue = trie.GetValue(username).Peek();
            trie.GetValue(username).Push(str + oldValue);
        }
    }

    public string Print(string username)
    {
        if (loggedUsers.Contains(username))
        {
            return trie.GetValue(username).Peek();
        }

        return null;
    }

    public void Substring(string username, int startIndex, int length)
    {
        if (loggedUsers.Contains(username))
        {
            string oldValue = trie.GetValue(username).Peek();
            if (oldValue.Length > startIndex + length)
            {
                trie.GetValue(username).Push(oldValue.Substring(startIndex, length));
            }
        }
    }

    public void Undo(string username)
    {
        if (loggedUsers.Contains(username))
        {
            if (trie.GetValue(username).Count > 1)
            {
                trie.GetValue(username).Pop();
            }
        }
    }

    public IEnumerable<string> Users(string prefix = "")
    {
        return trie.GetByPrefix(prefix)
            .Where(loggedUsers.Contains)
            .OrderBy(loggedUsers.IndexOf);
    }

    public IEnumerable<string> GetLoggedUsers()
    {
        return loggedUsers;
    }
}
