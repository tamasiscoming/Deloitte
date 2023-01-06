using Deloitte_Interview.Logic;

public class ConsoleAppLogic
{
    public static void Run()
    {
        Console.WriteLine("Deliotte Console App Interview Task");
        List<string> input = InputHandler.GetInputFromUser();
        ProcessInputs(input);
        Console.WriteLine(string.Join("\n", input));
    }

    static void ProcessInputs(List<string> inputs)
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (int.TryParse(inputs[i], out int number))
            {
                if (IsPrime(number))
                {
                    inputs[i] = number + " - THIS IS A PRIME NUMBER";
                }
            }
            else
            {
                int length = inputs[i].Length;
                inputs[i] = inputs[i] + " - " + "Making an impact that matters –Deloitte".Substring(0, length);
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}