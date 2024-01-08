namespace battleboats
{
   public class Game
   {
	  public int turn = 0;
	  private PlayerBase[]? players;

	  public Game()
	  {
		  this.players = new PlayerBase[2];
		  this.players[0] = new Human();
		  this.players[0].Setup();
		  this.players[1] = new Bot();
		  this.players[1].Setup();
	  }

	  public void Start()
	  {
		  if (this.players == null) return; 
		  
		 while (true)
		 {
			var attacker = this.players[this.turn % 2];
			var defender = this.players[(this.turn + 1) % 2];
			
			var coords = attacker.Target();

			var hit = defender.Attack(coords , attacker.id);
			// Allows the player to play another turn after getting a hit
			if (hit) this.turn++;
			
			attacker.history.Add(new Attack(attacker.id, coords, hit));
			
			this.turn++;
		 }
	  }
   }
}
