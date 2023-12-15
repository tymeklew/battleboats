namespace Battleboats
{
   public struct Coords
   {
      public int x;
      public int y;

      public Coords(int x, int y)
      {
         this.x = x;
         this.y = y;
      }
   }

   public class Game
   {
      // What turn in the game it is
      private int turn = 0;
      // Players
      private PlayerModel[] players;

      public Game(PlayerModel p1, PlayerModel p2)
      {
         this.players = new PlayerModel[2] { p1, p2 };

         // Make all players put ships in the water
         foreach (var player in this.players) player.PlaceBoats();
      }

      public void Cycle()
      {
         // The players who's turn it is
         PlayerModel player = this.players[turn % 2];

         // Incramenting turn
         turn++;
      }
   }
}
