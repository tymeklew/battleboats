namespace Battleboats
{
   public static class Ui
   {
	  public static void Grid(Tile[,] grid)
	  {
		 for (int i = 0; i < grid.GetLength(0); i++)
		 {
			for (int j = 0; j < grid.GetLength(1); j++)
			{
			   Console.Write($"[{grid[i, j] switch
			   {
				  Tile.Boat => "B",
				  Tile.Targeting => "T",
				  Tile.Hit => "H",
				  Tile.Miss => "M",
				  Tile => " "
			   }}]");
			}

			Console.WriteLine();
		 }
	  }
   }
}
