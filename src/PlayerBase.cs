using System.Text.Json.Serialization;
namespace battleboats
{

   public abstract class PlayerBase
   {
	  [JsonPropertyName("id")]
	  public Guid id = Guid.NewGuid();
	  [JsonPropertyName("boats")]
	  public List<Boat> boats = new List<Boat>();
	  [JsonPropertyName("boats")]
	  public List<Attack> history = new List<Attack>();

	  // Make the player place their ships on the grid
	  public abstract void Setup();
	  // Where the player wants to attack
	  public abstract Coordinate Target();



	  // Method this class implements given the coordinates of where the opposing player wants to attack returns wether or not it was a hit
	  public bool Attack(Coordinate coordinate, Guid playerId)
	  {
		 var hit = false;
		 foreach (var boat in this.boats)
			if (boat.IsHit(coordinate))
			{
			   hit = true;

			   boat.hits++;
			   if (boat.hits == boat.length) boat.sunk = true;

			   break;
			}

		 history.Add(new Attack(playerId, coordinate, hit));
		 return hit;
	  }

	  // Function to render the fleet grid onto a 2d array
	  protected Tile[,] Fleet()
	  {
		 var grid = new Tile[Constants.GridHeight, Constants.GridWidth];
		 // Get all attacks onto this player from the history filtering by id
		 var defences = history.Where(attack => attack.playerId != this.id).ToList();

		 foreach (var defence in defences)
		 {
			grid[defence.coordinate.y, defence.coordinate.x] = defence.hit ? Tile.Hit : Tile.Miss;
		 }

		 foreach (var boat in this.boats)
		 {
			for (int i = 0; i < boat.length; i++)
			{
			   var stride = boat.coordinate.GetIndex() + i * (int)boat.orientation;

			   if (grid[stride / Constants.GridHeight, stride % Constants.GridWidth] != Tile.Empty && !boat.sunk) continue;
			   grid[stride / Constants.GridHeight, stride % Constants.GridWidth] = boat.sunk ? Tile.Sunk : Tile.Boat;
			}
		 }

		 return grid;
	  }

	  // Function to render the attacking grid onto a 2d array
	  protected Tile[,] Attacking()
	  {
		 var grid = new Tile[Constants.GridHeight, Constants.GridWidth];

		 var attacks = history.Where(attack => attack.playerId == this.id);

		 foreach (var attack in attacks)
			grid[attack.coordinate.y, attack.coordinate.x] = attack.hit ? Tile.Hit : Tile.Miss;

		 return grid;
	  }

	  // Function to check if passed in boat coflicts with any other boats
	  protected bool ConflictsWithAny(Boat boat)
	  {
		 foreach (var other in boats)
			if (boat.ConflictsWith(other)) return true;

		 return false;
	  }

	  // Checks if the player has any ships left
	  public bool HasLost() => boats.All(boat => boat.sunk);
   }
}
