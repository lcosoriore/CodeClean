﻿internal class Program
{
    public static List<string> TaskList { get; set; }

    static void Main(string[] args)
    {
        TaskList = new List<string>();
        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if (menuSelected == 1)
            {
                ShowMenuAdd();
            }
            else if (menuSelected == 2)
            {
                ShowMenuRemove();
            }
            else if (menuSelected == 3)
            {
                ShowMenuTaskList();
            }
        } while (menuSelected != 4);
    }
    /// <summary>
    /// Show the main menu 
    /// </summary>
    /// <returns>Returns option indicated by user</returns>
    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        // Read line
        string readOption = Console.ReadLine();
        return Convert.ToInt32(readOption);
    }

    public static void ShowMenuRemove()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            // Show current taks
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
            }
            Console.WriteLine("----------------------------------------");

            string readTaskNumber = Console.ReadLine();
            // Remove one position
            int indexToRemove = Convert.ToInt32(readTaskNumber) - 1;
            if (indexToRemove > -1)
            {
                if (TaskList.Count > 0)
                {
                    string taskDescription = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + taskDescription + " eliminada");
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string taskDescription = Console.ReadLine();
            TaskList.Add(taskDescription);
            Console.WriteLine("Tarea registrada");
        }
        catch (Exception)
        {
        }
    }

    public static void ShowMenuTaskList()
    {
        if (TaskList == null || TaskList.Count == 0)
        {
            Console.WriteLine("No hay tareas por realizar");
        }
        else
        {
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}