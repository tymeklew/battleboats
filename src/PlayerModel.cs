namespace Battleboats
{
   public enum Tile
   {
      Empty,
      Ship,
      Hit,
      Targeting,
      Sunk,
      Miss
   }

   public enum Orientation { Horizontal, Vertical }

   public abstract class PlayerModel
   {
      // Name of the player
      public string Name;
      // Grid where they place the ships
      public Tile[,] FleetGrid;
      // Grid where they attack
      public Tile[,] AttackGrid;
      // Config for game
      protected readonly Config config;

      // Constructor for players
      protected PlayerModel(string name, Config config)
      {
         this.Name = name;
         this.FleetGrid = new Tile[config.GridHeight, config.GridWidth];
         this.AttackGrid = new Tile[config.GridHeight, config.GridWidth];
         this.config = config;
      }

      // Function to place ships onto the grid
      public abstract void PlaceBoats();
      // Function to where they want to attack 
      public abstract Coords Attack();

      protected void DrawShip(Coords coords, int length, Orientation orientation, Tile tile)
      {
         for (int i = 0; i < length; i++)
         {
            if (orientation == Orientation.Horizontal) { this.FleetGrid[coords.y, coords.x + i] = tile; }
            else { this.FleetGrid[coords.y + i, coords.x] = tile; }
         }
      }

      public bool HasLost()
      {
         return false;
      }

      protected bool IsShipValid(Coords coords, int length, Orientation orientation)
      {
         Coords init = coords;
         for (int i = 0; i < length; i++)
         {
            if (orientation == Orientation.Horizontal) coords.x = init.x + i;
            else { coords.y = init.y + i; }

            if (!this.IsInBounds(new Coords(coords.x, coords.y))) return false;
            if (this.FleetGrid[coords.y, coords.x] != Tile.Empty) return false;
         }
         return true;
      }

      protected bool IsInBounds(Coords coords) => coords.x >= 0 && coords.x < this.config.GridWidth && coords.y >= 0 && coords.y < this.config.GridHeight;
   }

}
