namespace Battleboats
{
   public struct Boat
   {
      public string name;
      public int quantity;
      public int length;
   }

   public class Config
   {
      public int GridHeight = 10;
      public int GridWidth = 10;
      public List<Boat> Boats = new List<Boat>() {
         new Boat() {name = "Carrier" , quantity = 1, length = 5},
         new Boat() {name = "Destroyer" , quantity = 1, length = 4},
         new Boat() {name = "Submarine" , quantity = 2, length = 3}
      };
   }
}
