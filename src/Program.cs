namespace battleboats
{
    public enum Tile { Empty, Miss, Hit, Boat }

    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public int GetIndex() => this.x + this.y * Constants.GridWidth;
    }

    internal class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}
