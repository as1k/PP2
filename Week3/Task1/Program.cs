using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    enum FSIMode
    {
        Folder, File
    }
    class Layer
    {
        int selectedIndex;
        public DirectoryInfo[] Directories
        {
            get;
            set;
        }
        public FileInfo[] Files
        {
            get;
            set;
        }
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (value < 0) selectedIndex = Directories.Length + Files.Length - 1;
                else if (value > Directories.Length + Files.Length - 1) selectedIndex = 0;
                else selectedIndex = value;
            }
        }
        void SelectedColor(int i)
        {
            if (i == SelectedIndex)
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            else
                Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Directories.Length; i++)
            {
                SelectedColor(i);
                Console.WriteLine((i + 1) + ". " + Directories[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < Files.Length; i++)
            {
                SelectedColor(i + Directories.Length);
                Console.WriteLine((i + Directories.Length + 1) + ". " + Files[i].Name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo firstdir = new DirectoryInfo(@"C:\Users\User\Desktop\TestFarMan");
            Layer l = new Layer
            {
                Directories = firstdir.GetDirectories(),
                Files = firstdir.GetFiles(),
                SelectedIndex = 0
            };
            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);
            bool quit = false;
            FSIMode mode = FSIMode.Folder;
            while (!quit)
            {
                if (mode == FSIMode.Folder)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    history.Peek().SelectedIndex--;

                else if (key.Key == ConsoleKey.DownArrow)
                    history.Peek().SelectedIndex++;

                else if (key.Key == ConsoleKey.Enter)
                {
                    int newopen = history.Peek().SelectedIndex;
                    if (newopen < history.Peek().Directories.Length)
                    {
                        DirectoryInfo d = history.Peek().Directories[newopen];
                        Layer ly = new Layer
                        {
                            Directories = d.GetDirectories(),
                            Files = d.GetFiles(),
                            SelectedIndex = 0
                        };
                        history.Push(ly);
                    }
                    else
                    {
                        mode = FSIMode.File;
                        StreamReader sr = new StreamReader(history.Peek().Files[newopen - history.Peek().Directories.Length].FullName);
                        string s = sr.ReadToEnd();
                        sr.Close();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine(s);
                    }
                }

                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (mode == FSIMode.Folder)
                    {
                        if (history.Count > 1)
                            history.Pop();
                    }
                    else
                        mode = FSIMode.Folder;
                }

                else if (key.Key == ConsoleKey.D)
                {
                    int todelete = history.Peek().SelectedIndex;
                    int j = todelete;
                    if (todelete < history.Peek().Directories.Length) { history.Peek().Directories[todelete].Delete(true); }
                    else { history.Peek().Files[todelete - history.Peek().Directories.Length].Delete(); }
                    history.Pop();

                    if (history.Count() == 0)
                    {
                        Layer lay = new Layer
                        {
                            Directories = firstdir.GetDirectories(),
                            Files = firstdir.GetFiles(),
                            SelectedIndex = j - 2
                        };
                        history.Push(lay);
                    }

                    else
                    {
                        int i = history.Peek().SelectedIndex;
                        DirectoryInfo dd = history.Peek().Directories[i];
                        Layer ly = new Layer
                        {
                            Directories = dd.GetDirectories(),
                            Files = dd.GetFiles(),
                            SelectedIndex = j--
                        };
                        history.Push(ly);
                    }
                }


                else if (key.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    int torename = history.Peek().SelectedIndex;
                    int i = torename;
                    string name, fullname;
                    int selectedMode;

                    if (torename < history.Peek().Directories.Length)
                    {
                        name = history.Peek().Directories[torename].Name;
                        fullname = history.Peek().Directories[torename].FullName;
                        selectedMode = 1;
                    }
                    else
                    {
                        name = history.Peek().Files[torename - history.Peek().Directories.Length].Name;
                        fullname = history.Peek().Files[torename - history.Peek().Directories.Length].FullName;
                        selectedMode = 2;
                    }

                    string path = fullname.Remove(fullname.Length - name.Length);
                    Console.WriteLine("Please enter the new name with extension");
                    string newname = Console.ReadLine();

                    if (selectedMode == 1) { new DirectoryInfo(history.Peek().Directories[torename].FullName).MoveTo(path + newname); }
                    else { new FileInfo(history.Peek().Files[torename - history.Peek().Directories.Length].FullName).MoveTo(path + newname); }
                    history.Pop();

                    if (history.Count == 0)
                    {
                        Layer lay = new Layer
                        {
                            Directories = firstdir.GetDirectories(),
                            Files = firstdir.GetFiles(),
                            SelectedIndex = i
                        };
                        history.Push(lay);
                    }
                    else
                    {
                        torename = history.Peek().SelectedIndex;
                        DirectoryInfo dir = history.Peek().Directories[torename];
                        Layer ly = new Layer
                        {
                            Directories = dir.GetDirectories(),
                            Files = dir.GetFiles(),
                            SelectedIndex = i
                        };
                        history.Push(ly);
                    }
                }


                else if (key.Key == ConsoleKey.Escape)
                {
                    quit = true;
                }
            }

        }
    }
}