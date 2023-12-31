namespace Battleboats
{
   public enum Tile { Empty = 0, Boat = 1, Targeting = 2, Miss = 3, Hit = 4 }
   public enum Orientation { Horizontal, Vertical }

   public struct Coordinate
   {
	  public int x;
	  public int y;

	  public Coordinate(int x = 0, int y = 0) { this.x = x; this.y = y; }
   }

   internal class Program
   {
	  public static void Main(string[] args)
	  {
		 Game game = new Game();
		 game.NewGame();
	  }
   }
}
