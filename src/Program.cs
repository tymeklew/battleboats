namespace battleboats
{
   public enum Tile { Empty, Miss, Hit, Boat, Sunk }

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
		 Menu();
	  }
	  private static void Menu()
	  {
		 Ui.Menu();
		 Console.Write("Input your choice > ");
		 Game game;
		 switch (Console.ReadLine())
		 {
			case "1":
			   game = new Game();
			   game._players = new PlayerBase[2];
			   game._players[0] = new Human();
			   game._players[1] = new Bot();
			   game.Start();
			   break;
			case "2":
			   game = Game.Load()!;
			   game.Start();
			   break;
			case "3":
			   Console.WriteLine(Constants.Instructions);
			   Console.ReadKey();
			   break;
			case "4":
			   Console.WriteLine("Goodbye");
			   Environment.Exit(0);
			   break;
			case null:
			case "":
			   break;
		 }
	  }
   }
}
