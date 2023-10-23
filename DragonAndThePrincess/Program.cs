namespace DragonAndThePrincess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ADVENTURE TIME(not the kids show)\n");
            Game game = new Game();
            
            
            
            Console.WriteLine();
            Console.WriteLine(game.TheLocation.Description);
            Console.WriteLine();


            while (!game.GameOver)
            {
                game.Options();
                string input = Console.ReadLine().ToLower();
                game.MenuInput(input);
            }
            
        }
    }
}