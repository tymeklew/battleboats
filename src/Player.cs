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
               Orientation orientation = Orientation.Horizontal;

               do
               {
                  // Indent 
                  Console.Clear();
                  // Other ui bits
                  Ui.Title().Draw(new Coords(Console.BufferWidth / 2 - 7, 0));
                  Ui.Controls().Draw(new Coords(49, 6));
                  Ui.Key().Draw(new Coords(49, 12));

                  Paragraph paragraph = new Paragraph();
                  paragraph.WriteLine($"Placing {boat.name}");
                  paragraph.Draw(new Coords(1, 3));

                  // Updating the grid and displaying it
                  this.DrawShip(coords, boat.length, orientation, Tile.Ship);
                  Ui.Grid(this.FleetGrid).Draw(new Coords(1, 4));
                  this.DrawShip(coords, boat.length, orientation, Tile.Empty);

                  switch (Console.ReadKey(true).Key)
                  {
                     // Up
                     case ConsoleKey.W:
                     case ConsoleKey.UpArrow:
                        if (this.IsShipValid(new Coords(coords.x, coords.y - 1), boat.length, orientation)) coords.y--;
                        break;
                     // Left
                     case ConsoleKey.A:
                     case ConsoleKey.LeftArrow:
                        if (this.IsShipValid(new Coords(coords.x - 1, coords.y), boat.length, orientation)) coords.x--;
                        break;
                     // Down
                     case ConsoleKey.S:
                     case ConsoleKey.DownArrow:
                        if (this.IsShipValid(new Coords(coords.x, coords.y + 1), boat.length, orientation)) coords.y++;
                        break;
                     // Right
                     case ConsoleKey.D:
                     case ConsoleKey.RightArrow:
                        if (this.IsShipValid(new Coords(coords.x + 1, coords.y), boat.length, orientation)) coords.x++;
                        break;
                     case ConsoleKey.R:
                        var temp = (Orientation)(((int)orientation + 1) % 2);
                        if (this.IsShipValid(coords, boat.length, temp)) orientation = temp;
                        break;
                     case ConsoleKey.Enter:
                        finished = true;
                        break;
                  };

               } while (!finished);

               this.DrawShip(coords, boat.length, orientation, Tile.Ship);
            }
         }
      }

      public override Coords Attack()
      {
         Coords coords = new Coords();
         bool finished = false;
         do
         {
            Console.Clear();

            Ui.Title().Draw(new Coords(Console.BufferWidth / 2 - 7, 0));
            Ui.Key().Draw(new Coords(96, 3));

            this.AttackGrid[coords.y, coords.x] = Tile.Targeting;
            Ui.Grid(this.FleetGrid).Draw(new Coords(1, 3));
            Ui.Grid(this.AttackGrid).Draw(new Coords(49, 3));
            this.AttackGrid[coords.y, coords.x] = Tile.Empty;

            switch (Console.ReadKey(true).Key)
            {
               // Up
               case ConsoleKey.W:
               case ConsoleKey.UpArrow:
                  if (this.IsInBounds(new Coords(coords.x, coords.y - 1))) coords.y--;
                  break;
               // Left
               case ConsoleKey.A:
               case ConsoleKey.LeftArrow:
                  if (this.IsInBounds(new Coords(coords.x - 1, coords.y))) coords.x--;
                  break;
               // Down
               case ConsoleKey.S:
               case ConsoleKey.DownArrow:
                  if (this.IsInBounds(new Coords(coords.x, coords.y + 1))) coords.y++;
                  break;
               // Right
               case ConsoleKey.D:
               case ConsoleKey.RightArrow:
                  if (this.IsInBounds(new Coords(coords.x + 1, coords.y))) coords.x++;
                  break;
               case ConsoleKey.Enter:
                  finished = true;
                  break;
            }

         } while (!finished);
         return coords;
      }
   }
}
