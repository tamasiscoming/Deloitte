namespace Deloitte_Interview.Logic
{
    internal static class InputHandler
    {
        internal static List<string> GetInputFromUser()
        {
            List<string> inputs = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"================{i + 1}.Input================");
                Console.WriteLine("Enter a word or number (w/n):");
                string inputType = Console.ReadLine();

                while (inputType != "w" && inputType != "n")
                {
                    Console.WriteLine("Invalid input. Please enter either 'w' for word or 'n' for number:");
                    inputType = Console.ReadLine();
                }

                if (inputType == "w")
                {
                    Console.WriteLine("Enter a word (10-45 characters):");
                    string word = Console.ReadLine();

                    while (word.Length < 10 || word.Length > 45)
                    {
                        Console.WriteLine("Invalid input. Please enter a word with 10-45 characters:");
                        word = Console.ReadLine();
                    }

                    inputs.Add(word);
                }
                else if (inputType == "n")
                {
                    Console.WriteLine("Enter a number (10-9999):");
                    string numberString = Console.ReadLine();
                    int number;

                    while (!int.TryParse(numberString, out number) || number < 10 || number > 9999)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 10 and 9999:");
                        numberString = Console.ReadLine();
                    }

                    inputs.Add(numberString);
                }
            }

            Console.WriteLine("Inputs: " + string.Join(", ", inputs));

            return inputs;
        }
    }
}
