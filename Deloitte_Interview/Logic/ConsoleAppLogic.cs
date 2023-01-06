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
                else
                {
                    inputs[i] = DoMaths(number).ToString();
                }
            }
            else
            {
                int length = inputs[i].Length;
                inputs[i] = inputs[i] + " - " + "Making an impact that matters –Deloitte".Substring(0, length);
            }
        }
    }

    //1.      A bekért számok esetén a páros számokat ossza el 2-vel a páratlanokat szorozza kettővel. Extra: jelölje a prímszámokat
    static int DoMaths(int number)
    {
        if (number % 2 == 0) 
            return number / 2;
        else 
            return number * 2;
    }

    //Extra: jelölje a prímszámokat
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