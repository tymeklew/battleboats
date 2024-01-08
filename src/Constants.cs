namespace battleboats
{
   public static class Constants
   {
	  public const int GridWidth = 8;
	  public const int GridHeight = 8;
	  public const string Alphabet = "ABCDEFGHIJKLMNOPQ";
	  // Represents the list of available boats mapping (length , quantity)
	  public static readonly List<(int, int)> Boats = new List<(int, int)>()
	  {
		  (1 , 2),
		  (2 , 2),
		  (3 , 1),
	  };

	  public const string Instructions = @"
    1. Setup: Each player arranges their ships on their own grid. These grids is divided into a 8x8 square, with each cell labeled with letters (A-H) and numbers (1-8). Ships are placed horizontally or vertically and can't overlap. There are 3 types of ships: Destroyer(1 Cell) , Submarine(2 Cell) and Carrier(3 Cell)

    2. Turns: Players take turns firing shots at each other's grids. To fire a shot, a player writes when prompted the coordinates such as A7

    4. Sinking Ships: When a ship has been hit and all of its cells have been marked with red pegs, the ship is considered sunk

    5. Winning the Game: The first player to sink all of their opponent's ships wins the game.

Remember, the key to winning Battleship is not just luck, but also strategy. Try to remember where you've seen hits before and avoid those locations in future shots. Good luck!
";
   }
}
