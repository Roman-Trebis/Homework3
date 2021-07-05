using System;
using System.Diagnostics;

namespace Homework____1
{
    [Serializable]
    class Program
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Program()
        {

        }

        public Program(int id, string name)
        {
            Id = id;
            Name = name;
        }

        static int Scan(Program[] a, int id)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Id == id)
                {
                    Console.WriteLine($"ID процесса {a[i].Id} {a[i].Name} ");
                    return i;
                }
            }
            return -1;
        }

        static void Exit(Program[] a, int b, int i)
        {
            switch (i)
            {
                case 1:
                    Process[] kill = Process.GetProcessesByName(a[b].Name);
                    foreach (Process worker in kill)
                    {
                        worker.Kill();
                    }
                    break;

                case 2:
                    Process[] kill2 = Process.GetProcessesByName(a[b].Name);
                    foreach (Process worker in kill2)
                    {
                        worker.CloseMainWindow();
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            /*
             Задание 1. Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс. Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса. В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
            */

            Program[] ProgramMass = new Program[Process.GetProcesses().Length];
            int a = 0;

            foreach (Process pro in Process.GetProcesses())
            {
                ProgramMass[a] = new Program(pro.Id, pro.ProcessName);
                a++;
            }

            for (int i = 0; i < ProgramMass.Length; i++)
            {
                Console.WriteLine($"ID процесса {ProgramMass[i].Id} {ProgramMass[i].Name}");
            }
            Console.Write("Введите ID процесса: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int innum = Scan(ProgramMass, id);
            if (innum == 1)
            {
                Console.WriteLine("Процесс с таким ID не найден.");
            }
            Console.Write("Как вы хотите завершить процесс: 1 жестко / 2 просто закрыть: ");
            int exit = Convert.ToInt32(Console.ReadLine());
            Exit(ProgramMass, innum, exit);

            Console.ReadKey();
        }
    }
}
