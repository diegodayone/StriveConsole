using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace StriveConsole
{
    class CommandExecutor
    {
        static string executionPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static bool Execute(string command)
        {
            //cd albums
            //commandParts = [ cd, albums ]
            //dir
            //commandParts = [ dir ]
            //"cd albums "
            //commandParts = [ cd, albums, "" ]
            var commandParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandName = commandParts[0]; //cd or dir or ls...

            switch (commandName.ToLower())
            {
                case "dir":
                case "ls":
                    var files = Directory.GetFiles(executionPath); //get all files
                    var directories = Directory.GetDirectories(executionPath); //get all folders
                    var allTogether = directories.ToList(); //create a list with directories
                    allTogether.AddRange(files); //append all files
                    Console.WriteLine("Results in " + executionPath);
                    foreach (var fileOrDir in allTogether.OrderByDescending(x => x))
                        Console.WriteLine(fileOrDir);
                    break;
                case "cd..":
                    executionPath = new DirectoryInfo(executionPath).Parent.FullName;
                    break;
                case "cd":
                case "pwd":
                    if (commandParts.Length == 1)
                        Console.WriteLine(executionPath);
                    else
                    {
                        var dir = new DirectoryInfo(executionPath);
                        if (commandParts[1] == "..")
                            executionPath = dir.Parent.FullName;
                        else
                        {
                            var fullPathName = command.Replace("cd ", "");
                            //var fullPathName = commandParts.Skip(1).Aggregate((x, y) => x + " " + y);

                            var children = dir.GetDirectories();
                            //single in JS. Take the first element with the same name, or null if no element match
                            //First or default is like a .Where, but returns only 1 item
                            var child = children.FirstOrDefault(x => x.Name.ToLower() == fullPathName.ToLower());
                            if (child == null) Console.WriteLine("Cannot find folder " + fullPathName);
                            else executionPath = child.FullName;
                        }
                        Console.WriteLine(executionPath);
                    }
                    break;
                case "del":
                    //check if a file with the given name exists in the current folder
                    //if so, delete
                    var delDir = new DirectoryInfo(executionPath);
                    var res = delDir
                        .GetFiles() //Get all the files
                        //Search for a file with the specific given name 
                        .FirstOrDefault(x => x.Name.ToLower() == commandParts[1].ToLower());
                    if (res == null) Console.WriteLine("Cannot find file " + commandParts[1]);
                    else res.Delete();

                    //alternative version
                    //var fullPath = executionPath + "\\" + commandParts[1];
                    //if (File.Exists(fullPath))
                    //{
                    //    //delete
                    //}
                    //else
                    //{
                    //    //write file not found;
                    //}

                    break;
                case "quit":
                case "exit":
                    Console.WriteLine("Exiting program");
                    return false;
                case "mv":
                    if (commandParts.Length == 3)
                    {
                        var fullPath = executionPath + "\\" + commandParts[1];
                        if (File.Exists(fullPath))
                            File.Move(fullPath, commandParts[2]);
                        else
                            Console.WriteLine("File not found");
                    }
                    else Console.WriteLine("Wrong number of parameters: usage mv fileName newFileName/newFilePath");
                    break;
                default:
                    Console.WriteLine("Command not available");
                    break;
            }

            return true;
        }
    }
}
