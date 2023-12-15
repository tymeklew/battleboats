namespace Battleboats
{
   public class Ui
   {
      public static Paragraph Title()
      {
         Paragraph para = new Paragraph();
         para.WriteLine("┏━━━━━━━━━━━━━━┓");
         para.WriteLine("┃  Battleboats ┃");
         para.WriteLine("┗━━━━━━━━━━━━━━┛");
         return para;
      }

      public static Paragraph Key()
      {
         Paragraph para = new Paragraph();
         // Ship
         para.WriteLine("┏━━━┓");
         para.WriteLine($"┃ {"S".Colour(Colour.Cyan)} ┃  Ship");
         para.WriteLine("┗━━━┛");
         // Hit 
         para.WriteLine("┏━━━┓");
         para.WriteLine($"┃ {"X".Colour(Colour.Red)} ┃  Hit");
         para.WriteLine("┗━━━┛");
         // Miss 
         para.WriteLine("┏━━━┓");
         para.WriteLine($"┃ {"O".Colour(Colour.Yellow)} ┃  Miss");
         para.WriteLine("┗━━━┛");
         // Empty 
         para.WriteLine("┏━━━┓");
         para.WriteLine("┃   ┃  Empty");
         para.WriteLine("┗━━━┛");
         return para;
      }

      // Function to nicley display the grid
      public static Paragraph Grid(Tile[,] grid)
      {
         Paragraph para = new Paragraph();

         para.WriteLine("┏" + string.Join("", Enumerable.Repeat("━━━┳", grid.GetLength(0))) + "━━━┓");

         for (int i = 0; i < grid.GetLength(0) + 1; i++)
         {
            para.Write($"┃ {" ABCDEFGHIJKLMNOPQRSTUVWXYZ"[i]} ");
         }
         para.WriteLine("┃");


         for (int i = 0; i < grid.GetLength(0); i++)
         {
            para.Write("┣━━━" + string.Join("", Enumerable.Repeat("╋━━━", grid.GetLength(0))));
            para.WriteLine("┫");
            para.Write($"┃ {grid.GetLength(0) - i - 1} ");

            for (int j = 0; j < grid.GetLength(1) + 1; j++)
            {
               para.Write("┃   ");
            }
            para.Write("\n");
         }
         para.WriteLine("┗" + string.Join("", Enumerable.Repeat("━━━┻", grid.GetLength(0))) + "━━━┛");
         return para;
      }

   }
}
