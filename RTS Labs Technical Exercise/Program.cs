namespace RTS_Labs_Technical_Exercise
{
    internal class Program
    {
        public string AboveBelow(int[] inputArray, int inputInt)
        {
            int above, below;
            above = below = 0;
            foreach (int number in inputArray)
            {
                if (number > inputInt)
                    below++;
                else if (number < inputInt)
                    above++;
            }
            return $"Above: {above}, Below: {below}";
        }

        public string RotateString(string inputString, int inputInt)
        {
            if (inputInt <= inputString.Length && inputInt > 0)
            {
                return inputString.Substring(inputString.Length - inputInt) + inputString.Remove(inputString.Length - inputInt);
            }
            else if (inputInt > inputString.Length)
            {
                return inputString.Substring(inputString.Length - (inputInt % inputString.Length)) + inputString.Remove(inputString.Length - (inputInt % inputString.Length));
            }
            else
            {
                return inputString;
            }
        }

        private static void Main(string[] args)
        {
            //Program program = new Program();
            //int[] testArray = new int[] { 1, 5, 2, 1, 10 };
            //System.Console.WriteLine(program.AboveBelow(testArray, 6));
            //testArray = new int[] { 2, 3, 5, 12, 51, 23, 21 };
            //System.Console.WriteLine(program.AboveBelow(testArray, 5));
            //System.Console.WriteLine();

            //for (int i = 0; i < 10; i++)
            //{
            //    System.Console.WriteLine(program.RotateString("MyString", i));
            //}

            //System.Console.WriteLine("\nI don't have a lot of extensive experience with languages to the point where I know something I really dislike off the top of my head. I will say I do wish Visual Studio had line-item reverts and local git history like IntelliJ does. Currently your only option is to revert entire files and if you do, you cannot get the files your revert back if you decide against your initial revert.");

            LiveInterview.main(args);
        }
    }
}