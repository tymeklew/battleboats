namespace battleboats
{
    public static class Ui
    {
        public static void Grid(Tile[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write($" {grid[i, j] switch
                    {
                        Tile.Empty => "~",
                        Tile.Hit => "X",
                        Tile.Miss => "M",
                        Tile.Boat => "B"
                    }} ");
                }
                Console.WriteLine();
            }

        }

    }
}
