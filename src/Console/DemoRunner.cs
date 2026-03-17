using AppState;
using Lib;

namespace App;

public class DemoRunner
{
    public static void Run()
    {
        AppState app = new AppState();
        
        Console.Clear();
        while(true)
        {
            try
            {
                Menu.PrintMenu();
                string answer = Console.ReadLine();
                Console.Clear();
                
                switch (answer)
                {
                    case "1": app.InitCollection(); break;
                    case "2": app.AddRecord(Menu.CreateRecord()); break;
                    case "3": app.RemoveRecord(Menu.GetId()); break;
                    case "4": app.PrintCollection(); break;
                    case "5": app.GenerateControlData(); break;
                    case "6": app.SortCollection(); break;
                    case "7": app.PrintIntermediateSteps(); break;
                    case "8": app.PrintStatistics(); break;
                    case "9": app.DevideInFive(); break;
                    case "10": app.FirstToThirdPlace(); break;
                    case "11": return;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}