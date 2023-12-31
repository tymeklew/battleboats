namespace Battleboats
{
   public class Human : PlayerBase
   {
	  public Human(string name) : base(name) { }

	  public override void PlaceBoats()
	  {
		 for (int i = 0; i < 2; i++)
		 {
			int length = 4;
			var placed = false;

			(Coordinate, Orientation) prev = (new Coordinate(), Orientation.Horizontal);
			(Coordinate, Orientation) current = new(new Coordinate(), Orientation.Horizontal);

			while (!placed)
			{
			   Console.Clear();

			   // If its valid then we can continue normally othewise
			   if (this.IsBoatValid(current.Item1, length, current.Item2)) prev = current;
			   else current = prev;

			   this.PlaceBoat(current.Item1, length, current.Item2, Tile.Boat);
			   Ui.Grid(this.fleet);
			   this.PlaceBoat(current.Item1, length, current.Item2, Tile.Empty);

			   switch (Console.ReadKey(true).Key)
			   {
				  // Up
				  case ConsoleKey.UpArrow:
				  case ConsoleKey.W: current.Item1.y--; break;
				  // Left 
				  case ConsoleKey.LeftArrow:
				  case ConsoleKey.A: current.Item1.x--; break;
				  // Down 
				  case ConsoleKey.DownArrow:
				  case ConsoleKey.S: current.Item1.y++; break;
				  // Right 
				  case ConsoleKey.RightArrow:
				  case ConsoleKey.D: current.Item1.x++; break;
				  // Rotate
				  case ConsoleKey.Spacebar:
					 current.Item2 = (Orientation)(((int)current.Item2 + 1) % 2);
					 break;
				  // Place
				  case ConsoleKey.Enter: placed = true; break;
			   }

			   Console.SetCursorPosition(1, 1);
			}

			// Place boats because they were deleted after displaying the grid
			this.PlaceBoat(current.Item1, length, current.Item2, Tile.Boat);

		 }
	  }

	  public override Coordinate Target()
	  {
		 Coordinate coordinate = new Coordinate();
		 var chosen = false;

		 while (!chosen)
		 {
			Console.Clear();
			this.attacking[coordinate.y, coordinate.x] = Tile.Targeting;
			Ui.Grid(this.attacking);
			this.attacking[coordinate.y, coordinate.x] = Tile.Empty;

			var key = Console.ReadKey(true).Key;

			if (key == ConsoleKey.Enter) chosen = true;
			else if (char.IsDigit((char)key))
			{
			   int col = int.Parse(((char)key).ToString()) - 1;
			   if (0 <= col && col < this.attacking.GetLength(1)) coordinate.x = col;
			}
			else if (char.IsLetter((char)key))
			{
			   int row = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf((char)key);
			   if (0 <= row && row < this.attacking.GetLength(0)) coordinate.y = row;
			}
		 }

		 return coordinate;
	  }
   }
}
