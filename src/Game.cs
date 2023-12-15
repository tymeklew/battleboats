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
         PlayerModel attacker = this.players[turn % 2];
         PlayerModel defender = this.players[(turn + 1) % 2];

         Coords coords = attacker.Attack();

         switch (defender.FleetGrid[coords.y, coords.x])
         {
            case Tile.Empty:
               attacker.AttackGrid[coords.y, coords.x] = Tile.Miss;
               defender.FleetGrid[coords.y, coords.x] = Tile.Miss;
               break;
            case Tile.Ship:
               // Allow a second turn after a hit
               this.turn--;
               attacker.AttackGrid[coords.y, coords.x] = Tile.Hit;
               defender.FleetGrid[coords.y, coords.x] = Tile.Hit;
               break;
         }


         // Incramenting turn
         this.turn++;
      }

      public void Start()
      {
         while (true) this.Cycle();
      }
   }
}
