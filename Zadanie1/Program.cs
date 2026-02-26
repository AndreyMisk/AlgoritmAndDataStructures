namespace second_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            int count = 0;
            int countGame = 0;

            Random rnd = new Random();
            char answer = 'y';

            do
            {
                PlaySingl(rnd, ref min, ref max, ref count, ref countGame);
                answer = UserContinue();
            } while (answer == 'y');

            GameStats(min, max, count, countGame);
        }

        static void PlaySingl(Random rnd, ref int min, ref int max, ref int count, ref int countGame)
        {
            int counter = 0;
            int number = rnd.Next(1, 100);
            Console.WriteLine("Try guess number?");

            while (true)
            {
                counter++;
                int userNumber = GetUserNumber();

                if (userNumber > number)
                    Console.WriteLine("Your number is greater");
                else if (userNumber < number)
                    Console.WriteLine("Your number is less");
                else
                {
                    Console.WriteLine("You are win!!!");
                    UpdateStats(counter, ref min, ref max, ref count, ref countGame);
                    break;
                }
            }
        }

        static int GetUserNumber()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input number at from [1;100]");
                if (int.TryParse(Console.ReadLine(), out int userNumber)
                    && userNumber >= 1 && userNumber <= 100)
                {
                    return userNumber;
                }
                else
                {
                    Console.WriteLine("Input number at from [1;100]");
                }

                if (i == 2)
                {
                    Console.WriteLine("You is stupid");
                    Environment.Exit(0);
                }
            }
            // Этот return никогда не будет достигнут из‑за Environment.Exit(0)
            return 0;
        }

        static char UserContinue()
        {
            Console.WriteLine("Do you want play game?");
            return Convert.ToChar(Console.Read());
        }

        static void UpdateStats(int attempts, ref int min, ref int max, ref int count, ref int countGame)
        {
            if (min == 0 || min > attempts) min = attempts;
            max = max < attempts ? attempts : max;
            count += attempts;
            countGame++;
        }

        static void GameStats(int min, int max, int totalAttempts, int gameCount)
        {
            Console.WriteLine($"min = {min} max = {max} avg = {(double)totalAttempts / gameCount}");
        }
    }
}
