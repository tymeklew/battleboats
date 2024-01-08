namespace battleboats
{
   public enum Tile { Empty, Miss , Hit , Boat , Sunk }

   public struct Coordinate
   {
	  public int x = 0;
	  public int y = 0;

	  public Coordinate(int x = 0, int y = 0)
	  {
		  this.x = x;
		  this.y = y;
	  }
	  

	  public int GetIndex() => this.x + this.y * Constants.GridWidth;
	  public bool InBounds() => this.x is >= 0 and < Constants.GridWidth && 
	                            this.y is >= 0 and < Constants.GridHeight;
	  public override string ToString() => $"{Constants.Alphabet[this.x]}{this.y + 1}";
   }

   internal static class Program
   {
	  public static void Main()
	  {
		  var game = new Game();
		  game.Start();
	  }
   }
}
