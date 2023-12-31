namespace Battleboats
{
   public abstract class PlayerBase
   {
	  // Name of player
	  public string name;
	  // Board where the player has placed their boats
	  public Tile[,] fleet;
	  // Board where the player has fired their shots
	  public Tile[,] attacking;

	  // Function so that the player must place their boats
	  public abstract void PlaceBoats();
	  // Function to descide where they attack
	  public abstract Coordinate Target();

	  public PlayerBase(string name)
	  {
		 this.name = name;
		 this.fleet = new Tile[10, 10];
		 this.attacking = new Tile[10, 10];
	  }

	  public bool IsBoatValid(Coordinate coordinate, int length, Orientation orientation)
	  {
		 for (int i = 0; i < length; i++)
		 {
			// Check orientation and account  for that
			Coordinate check = orientation switch
			{
			   Orientation.Horizontal => new Coordinate(coordinate.x + i, coordinate.y),
			   Orientation => new Coordinate(coordinate.x, coordinate.y + i)
			};

			// Validate that coords are in the bounds of the grid
			if (check.x < 0
				  || check.x >= this.fleet.GetLength(0)
				  || check.y < 0
				  || check.y >= this.fleet.GetLength(1))
			{
			   return false;
			}
		 }
		 return true;
	  }

	  public void PlaceBoat(Coordinate coordinate, int length, Orientation orientation, Tile tile)
	  {
		 for (int i = 0; i < length; i++)
		 {
			if (orientation == Orientation.Horizontal)
			   this.fleet[coordinate.y, coordinate.x + i] = tile;
			else
			   this.fleet[coordinate.y + i, coordinate.x] = tile;
		 }
	  }


   }
}
