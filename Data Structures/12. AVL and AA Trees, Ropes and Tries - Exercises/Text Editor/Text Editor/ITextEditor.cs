using System.Collections.Generic;

public interface ITextEditor
{
    void Login(string username);
    void Logout(string username);
    
    void Prepend(string username, string str);
    void Insert(string username, int index, string str);
    void Substring(string username, int startIndex, int length);
    void Delete(string username, int startIndex, int length);

    void Clear(string username);
    int Length(string username);
    string Print(string username);

    void Undo(string username);

    IEnumerable<string> Users(string prefix = "");
}
