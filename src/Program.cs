namespace Battleboats
{
    public enum Tile { Empty, Boat }

    public enum Orientation { Horizontal, Vertical }

    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
        }
    }
}
