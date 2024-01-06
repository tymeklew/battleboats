namespace battleboats
{
    public abstract class PlayerBase
    {
        public Guid id = Guid.NewGuid();
        public List<Boat> boats = new List<Boat>();
        public List<Attack> history = new List<Attack>();

        // Make the player place their ships on the grid
        public abstract void Setup();
        // Where the player wants to attack
        public abstract Coordinate Target();

        // Method this class implements given the coordiantes of where the opposing player wants to attack returns wether or not it was a hit
        public bool Attack(Coordinate coordinate)
        {
            foreach (var boat in this.boats)
                if (boat.IsHit(coordinate)) return true;
            return false;
        }

        public Tile[,] Render()
        {
            var grid = new Tile[Constants.GridWidth, Constants.GridHeight];

            foreach (var boat in this.boats)
            {
                for (int i = 0; i < boat.length; i++)
                {
                    var index = boat.coordinate.GetIndex() + i * (int)boat.orientation;

                    grid[index / Constants.GridWidth, index % Constants.GridWidth] = Tile.Boat;

                }
            }

            foreach (var attack in this.history)
                grid[attack.coordinate.x, attack.coordinate.y] = attack.hit ? Tile.Hit : Tile.Miss;


            return grid;
        }
    }
}
