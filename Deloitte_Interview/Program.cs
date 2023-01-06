using System;
using System.Reflection;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        ChooseTask();
    }

    public static void ChooseTask()
    {
        Console.WriteLine("Choose Task\n" +
            "Press 1 for SQL Task\n" +
            "Press 2 for Programming Task");

        int taskNo = int.Parse(Console.ReadKey().KeyChar.ToString());

        switch (taskNo)
        {
            case 1:
                Console.Clear();
                SQLLogic.Run();
                break;
            case 2:
                Console.Clear();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Choose a valid option...");
                ChooseTask();
                break;
        }
    }
}