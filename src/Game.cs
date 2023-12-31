namespace Battleboats
{
   public class Game
   {
	  // Players can be nullable if there is no  game going on
	  private PlayerBase[]? players;
	  int turn = 0;

	  public Game() { }

	  public void NewGame()
	  {
		 Human human = new Human("Player");
		 Bot bot = new Bot();

		 this.players = new PlayerBase[2] { human, bot };
		 foreach (var player in this.players) player.PlaceBoats();

		 while (true)
		 {
			var attacker = this.players[this.turn % 2];
			var defender = this.players[(this.turn + 1) % 2];

			// Coordinates of where the person whos attacking wants to attack on their opponents grid
			var coords = attacker.Target();

			switch (defender.fleet[coords.y, coords.x])
			{
			   case Tile.Empty:
				  attacker.attacking[coords.y, coords.x] = Tile.Miss;
				  defender.fleet[coords.y, coords.x] = Tile.Miss;
				  break;
			   case Tile.Boat:
				  attacker.attacking[coords.y, coords.x] = Tile.Hit;
				  defender.fleet[coords.y, coords.x] = Tile.Hit;
				  break;
			}

			turn++;
		 }

	  }
   }
}
