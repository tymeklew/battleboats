namespace battleboats
{
   public class Human : PlayerBase
   {
	  public Coordinate ParseCoordinate(string input)
	  {
		 var chars = input.ToUpper().ToCharArray();
		 var x = Constants.Alphabet.IndexOf(chars.First());
		 var y = int.Parse(chars.Last().ToString()) - 1;
		 
		 return new Coordinate(x, y);
	  }

	  public override void Setup()
	  {
		  foreach (var b in Constants.Boats) {
			  for (int i = 0; i < b.Item2; i++)
			  {
				  var boat = new Boat(new Coordinate() ,b.Item1);
				  Console.Clear();
				  Ui.Grid(this.Fleet());
				  do
				  {
					  Console.WriteLine($"Placing ship of length {b.Item1}");
					  Console.Write("Input your coordinates in the format [column][row] E.G A5 : ");
					  
					  try{ boat.coordinate = ParseCoordinate(Console.ReadLine()!); }
					  catch { Console.WriteLine("Failed to parse coordinates".Colour(Colour.Red)); }


					  if (this.ConflictsWithAny(boat))
						Console.WriteLine("Conflicts with another boat".Colour(Colour.Red));
					  
					  if (!boat.IsInBounds())
						  Console.WriteLine("Boat is out of bounds".Colour(Colour.Red));
					  
				  } while (this.ConflictsWithAny(boat) || !boat.IsInBounds());
				  this.boats.Add(boat);
			  }
		  }
		  
	  }

	  public override Coordinate Target()
	  {
		  Coordinate coords;
		  do
		  {
			  Console.Clear();
			  Ui.Grid(this.Attacking());
			  Console.WriteLine();
			  Ui.Grid(this.Fleet());
			  Console.Write("Input your coordinates in the format A2 : ");
			  coords = ParseCoordinate(Console.ReadLine()!);
		  } while (!coords.InBounds());
		  

		  return coords;
	  }
   }
}
