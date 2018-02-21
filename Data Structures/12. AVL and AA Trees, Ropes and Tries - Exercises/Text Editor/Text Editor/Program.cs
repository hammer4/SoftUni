using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();

        string command;

        while((command = Console.ReadLine()) != "end")
        {
            string[] commandArgs = command.Split();

            switch (commandArgs[0])
            {
                case "login":
                    editor.Login(commandArgs[1]);
                    break;
                case "logout":
                    editor.Logout(commandArgs[1]);
                    break;
                case "users":
                    if(commandArgs.Length == 1)
                    {
                        editor.GetLoggedUsers()
                            .ToList()
                            .ForEach(Console.WriteLine);
                    }
                    else
                    {
                        editor.Users(commandArgs[1])
                            .ToList()
                            .ForEach(Console.WriteLine);
                    }
                    break;
                default:
                    switch (commandArgs[1])
                    {
                        case "insert":
                            editor.Insert(commandArgs[0], int.Parse(commandArgs[2]), String.Join(" ", commandArgs.Skip(3)));
                            break;
                        case "prepend":
                            editor.Prepend(commandArgs[0], String.Join(" ", commandArgs.Skip(2)));
                            break;
                        case "substring":
                            editor.Substring(commandArgs[0], int.Parse(commandArgs[2]), int.Parse(commandArgs[3]));
                            break;
                        case "delete":
                            editor.Delete(commandArgs[0], int.Parse(commandArgs[2]), int.Parse(commandArgs[3]));
                            break;
                        case "clear":
                            editor.Clear(commandArgs[0]);
                            break;
                        case "length":
                            Console.WriteLine(editor.Length(commandArgs[0]));
                            break;
                        case "print":
                            string result = editor.Print(commandArgs[0]);
                            if(result != null)
                            {
                                Console.WriteLine(result);
                            }
                            break;
                        case "undo":
                            editor.Undo(commandArgs[0]);
                            break;
                    }
                    break;
            }
        }
    }
}
