namespace Battleboats
{
   public class Player : PlayerModel
   {
      // Constructor that inherits the PlayerModel
      public Player(string name, Config config) : base(name, config) { }

      public override void PlaceBoats()
      {
         foreach (Boat boat in this.config.Boats)
         {
            for (int i = 0; i < boat.quantity; i++)
            {
               // Something
               bool finished = false;
               Coords coords = new Coords(0, 0);

               do
               {
                  // Indent 
                  Console.Clear();
                  Ui.Title().Draw(new Coords(Console.BufferWidth / 2 - 8, 0));
                  Ui.Key().Draw(new Coords(48, 10));

                  Paragraph para = new Paragraph();
                  para.WriteLine($"Placing {boat.name}");
                  para.Draw(new Coords(0, 3));

                  Ui.Grid(this.FleetGrid).Draw(new Coords(0, 4));
                  Console.ReadKey(true);

               } while (!finished);
            }

         }

      }
   }
}
