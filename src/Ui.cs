namespace Battleboats
{
   public class Ui
   {
      public static Paragraph Title()
      {
         Paragraph paragraph = new Paragraph();
         paragraph.WriteLine("┏━━━━━━━━━━━━━━┓");
         paragraph.WriteLine("┃  Battleboats ┃");
         paragraph.WriteLine("┗━━━━━━━━━━━━━━┛");
         return paragraph;
      }

      public static Paragraph Controls()
      {
         Paragraph paragraph = new Paragraph();
         paragraph.WriteLine("Controls :");
         paragraph.WriteLine("Use [WASD] OR Arrow keys to move ship");
         paragraph.WriteLine("Press [Enter] to confirm");
         paragraph.WriteLine("Press [R] to rotate");
         paragraph.WriteLine("Press [Space] to rotate");
         return paragraph;
      }

      public static Paragraph Key()
      {
         Paragraph paragraph = new Paragraph();
         // Ship
         paragraph.WriteLine("┏━━━┓");
         paragraph.WriteLine($"┃ {"S".Colour(Colour.Green)} ┃  Ship");
         paragraph.WriteLine("┗━━━┛");
         // Hit 
         paragraph.WriteLine("┏━━━┓");
         paragraph.WriteLine($"┃ {"X".Colour(Colour.Red)} ┃  Hit");
         paragraph.WriteLine("┗━━━┛");
         // Miss 
         paragraph.WriteLine("┏━━━┓");
         paragraph.WriteLine($"┃ {"O".Colour(Colour.Yellow)} ┃  Miss");
         paragraph.WriteLine("┗━━━┛");
         // Empty 
         paragraph.WriteLine("┏━━━┓");
         paragraph.WriteLine("┃   ┃  Empty");
         paragraph.WriteLine("┗━━━┛");
         return paragraph;
      }

      // Function to nicley display the grid
      public static Paragraph Grid(Tile[,] grid)
      {
         Paragraph paragraph = new Paragraph();

         paragraph.WriteLine("┏" + string.Join("", Enumerable.Repeat("━━━┳", grid.GetLength(0))) + "━━━┓");

         for (int i = 0; i < grid.GetLength(0) + 1; i++)
         {
            paragraph.Write($"┃ {" ABCDEFGHIJKLMNOPQRSTUVWXYZ"[i]} ");
         }
         paragraph.WriteLine("┃");


         for (int i = 0; i < grid.GetLength(0); i++)
         {
            paragraph.Write("┣━━━" + string.Join("", Enumerable.Repeat("╋━━━", grid.GetLength(0))));
            paragraph.WriteLine("┫");
            paragraph.Write($"┃ {grid.GetLength(0) - i - 1} ");

            for (int j = 0; j < grid.GetLength(1); j++)
            {
               paragraph.Write($"┃ {grid[i, j] switch
               {
                  Tile.Empty => " ",
                  Tile.Ship => "S".Colour(Colour.Green),
                  Tile.Hit => "X".Colour(Colour.Red),
                  Tile.Miss => "O".Colour(Colour.Yellow),
               }} ");
            }
            paragraph.Write("┃\n");
         }
         paragraph.WriteLine("┗" + string.Join("", Enumerable.Repeat("━━━┻", grid.GetLength(0))) + "━━━┛");
         return paragraph;
      }

   }
}
