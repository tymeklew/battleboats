namespace Battleboats
{
   internal class Program
   {
      public static void Main(string[] args)
      {
         Config config = new Config();
         Player p1 = new Player("Player1", config);
         Player p2 = new Player("Player2", config);
         Game game = new Game(p1, p2);
      }
   }
}
