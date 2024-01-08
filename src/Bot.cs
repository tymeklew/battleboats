namespace battleboats
{
   public class Bot : PlayerBase
   {
	  public override void Setup()
	  {
		 foreach (var b in Constants.Boats)
		 {
			for (var i = 0; i < b.Item2; i++)
			{
			   var boat = new Boat(new Coordinate(), b.Item1);
			   var random = new Random();
			   do
			   {
				  boat.coordinate.x = random.Next(Constants.GridWidth - 1);
				  boat.coordinate.y = random.Next(Constants.GridHeight - 1);
				  boat.orientation = random.Next(2) == 0 ? Orientation.Vertical : Orientation.Horizontal;
			   } while (this.ConflictsWithAny(boat) || !boat.IsInBounds());
			   this.boats.Add(boat);

			}

		 }
	  }

	  // Overide on the PlayerBase Target method to generate a random set of coordiantes that have not been attacked before
	  public override Coordinate Target()
	  {
		 var attacks = this.history.Where(attack => attack.playerId == this.id).ToList();
		 var random = new Random();
		 var coords = new Coordinate();

		 // Loop to keep generating random coordinates until there is no conflict with any previous attacks
		 do
		 {
			coords.x = random.Next(Constants.GridWidth);
			coords.y = random.Next(Constants.GridHeight);
		 } while (attacks.Any(attack => attack.coordinate.x == coords.x && attack.coordinate.y == coords.y));

		 return coords;
	  }
   }
}
