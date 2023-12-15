namespace Battleboats
{
   internal class Program
   {
      public static void Main(string[] args)
      {
         Config config = new Config();
         Player p1 = new Player("Player1", config);
         Bot p2 = new Bot(config);
         Game game = new Game(p1, p2);

         Console.Clear();
         game.Start();
      }
   }
}
