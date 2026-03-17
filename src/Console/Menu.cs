using Lib;

namespace AppState;

public class Menu
{
    public static string[] menuItems =
    {
        "Initialize collection",
        "Add record",
        "Remove record",
        "Print collection",
        "Add seed",
        "Sort",
        "Print steps",
        "Print stats",
        "Divide for 5 seconds",
        "Places",
        "Exit"
    };

    public static void PrintMenu()
    {
        Console.WriteLine("------------------");
        
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{i+1}. {menuItems[i]}");
        }

        Console.WriteLine("------------------");
    }

    public static Record CreateRecord()
    {
        Console.Write("Enter id: ");
        string id = Console.ReadLine();

        Console.Write("Enter full name: ");
        string fullname = Console.ReadLine();

        Console.Write("Enter team name: ");
        string team = Console.ReadLine();

        Console.Write("Enter result: ");
        int seconds = int.Parse(Console.ReadLine());
        
        return new Record(id, fullname, team, seconds);
    }

    public static string GetId()
    {
        Console.WriteLine("Enter id: ");
        return Console.ReadLine();
    }
}