using CodeClean;

internal class Program
{
    public static List<string> TaskList { get; set; }

    static void Main(string[] args)
    {
        TaskList = new List<string>();
        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if ((Menu)menuSelected == Menu.Add)
            {
                ShowMenuAdd();
            }
            else if ((Menu)menuSelected == Menu.Remove)
            {
                ShowMenuRemove();
            }
            else if ((Menu)menuSelected == Menu.List)
            {
                ShowMenuTaskList();
            }
        } while ((Menu)menuSelected != Menu.Exit);
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
            ShowTaskList();

            string readTaskNumber = Console.ReadLine();
            // Remove one position
            int indexToRemove = Convert.ToInt32(readTaskNumber) - 1;
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                    string taskDescription = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + taskDescription + " eliminada");
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
            ShowTaskList();
        }
    }

    public static void ShowTaskList()
    {
        Console.WriteLine("----------------------------------------");
        int indexTask = 0;
        TaskList.ForEach(task => Console.WriteLine(++indexTask + ". " + task));
       
        Console.WriteLine("----------------------------------------");

    }
}