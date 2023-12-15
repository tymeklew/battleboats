namespace Battleboats
{
   public enum Tile
   {
      Empty,
      Ship,
      Hit,
      Miss
   }

   public abstract class PlayerModel
   {
      // Name of the player
      public string Name;
      // Grid where they place the ships
      public Tile[,] FleetGrid;
      // Grid where they attac:w
      // w;k
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

      protected void DrawShip(Coords coords, Boat boat) { }


   }

}
