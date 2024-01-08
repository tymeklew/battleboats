namespace battleboats
{
   public class Attack
   {
	  public Guid playerId;
	  public Coordinate coordinate;
	  public readonly bool hit;

	  public Attack(Guid playerId, Coordinate coordinate, bool hit = false)
	  {
		 this.playerId = playerId;
		 this.coordinate = coordinate;
		 this.hit = hit;
	  }
   }
}
