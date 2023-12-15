namespace Battleboats
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
      White = 37,
      Default = 39,
      Reset = 0,
   }

   public static class StringExtension
   {
      // Helper function usage : "test".Colour(Colour) will make test colour of input do not nest them 
      public static string Colour(this string str, Colour colour) => $"\x1b[{(int)colour}m{str}\x1b[0m";
   }

   public class Paragraph
   {
      string content = string.Empty;

      public void Write(string add) => this.content += add;
      public void WriteLine(string add = "") => this.content += add + "\n";


      public void Draw(Coords coords)
      {
         foreach (string line in this.content.Split("\n"))
         {
            Console.SetCursorPosition(coords.x, coords.y++);
            Console.Write(line);
         }
      }
   }
}
