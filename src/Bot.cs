namespace Battleboats
{
   public class Bot : PlayerModel
   {
      public Bot(Config config) : base("Bot", config) { }

      public override void PlaceBoats()
      {
         Coords coords = new Coords(0, 0);
         Orientation orientation = Orientation.Horizontal;
         Random random = new Random();

         foreach (var boat in this.config.Boats)
         {
            for (int i = 0; i < boat.quantity; i++)
            {
               do
               {
                  coords.x = random.Next(10);
                  coords.y = random.Next(10);
                  orientation = (Orientation)(((int)orientation + random.Next(2)) % 2);
               } while (!this.IsShipValid(coords, boat.length, orientation));

               this.DrawShip(coords, boat.length, orientation, Tile.Ship);
            }
         }
      }

      public override Coords Attack()
      {
         Random random = new Random();
         return new Coords(random.Next(10), random.Next(10));
      }
   }
}
