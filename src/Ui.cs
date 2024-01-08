namespace battleboats
{
	public enum Colour
	{
		Black = 30,
		Red = 31,
		Green = 32,
		Yellow = 33,
		Blue = 34,
		Magenta = 35,
		Cyan = 36,
		White = 37
	}
	public static class StringExtension
	{
		public static string Colour(this string str, Colour colour) => $"\x1b[{(int)colour}m{str}\x1b[0m";
	}
   public static class Ui
   {
	  public static void Grid(Tile[,] grid)
	  {
		 Console.Write("   ");
		 for (int i = 0; i < grid.GetLength(0); i++)
		 {
			Console.Write($" {Constants.Alphabet[i]} ");
		 }
		 Console.WriteLine();


		 for (int i = 0; i < grid.GetLength(0); i++)
		 {
			Console.Write($" {i + 1} ");
			for (int j = 0; j < grid.GetLength(1); j++)
			{
			   Console.Write($" {grid[i, j] switch
			   {
				  Tile.Empty => "~",
				  Tile.Hit => "X".Colour(Colour.Red),
				  Tile.Miss => "M".Colour(Colour.Yellow),
				  Tile.Boat => "B".Colour(Colour.Green),
				  Tile.Sunk => "S".Colour(Colour.Magenta),
			   }} ");
			}
			Console.WriteLine();
		 }

	  }

   }
}
