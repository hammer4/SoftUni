using System;

class StringsandObjects
{
    static void Main()
    {
        string string1 = "Hello";
        string string2 = "World";
        object obj = string1 + " " + string2;
        string string3 = (string)obj;
    }
}
