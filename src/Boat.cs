namespace battleboats
{
   public enum Orientation { Horizontal = 1, Vertical = Constants.GridWidth }

   public class Boat
   {
	  public Coordinate coordinate;
	  public Orientation orientation;
	  public bool sunk;
	  public int length;
	  // Keeps track of how many time ship has been hit to detcet wether or not it is sunk
	  public int hits = 0;


	  public Boat(Coordinate coordinate, int length ,Orientation orientation = Orientation.Horizontal)
	  {
		 this.coordinate = coordinate;
		 this.orientation = orientation;
		 this.length = length;
	  }

	  // Detects wether this specific boat has been hit given the coordinates
	  public bool IsHit(Coordinate coords)
	  {
		  var stride = (int)this.orientation;
		  var boatIndex = this.coordinate.GetIndex();
		  var bombIndex = coords.GetIndex();

		  for (int i = 0; i < this.length; i++)
			  if (bombIndex == boatIndex + stride * i)
				  return true;
		  
		  return false;
   }

	  public bool ConflictsWith(Boat other)
	  {
		var coords = this.coordinate;
		 for (int i = 0; i < this.length; i++)
		 {
			var index = this.coordinate.GetIndex() + i * (int)(this.orientation);
			coords.x = index % Constants.GridWidth;
			coords.y = index / Constants.GridHeight;

			if (other.IsHit(coords)) return true;

		 }
		 return false;
	  }

	  public bool IsInBounds()
	  {
		  var coords = this.coordinate;
		  
		  if (this.coordinate.x + this.length > Constants.GridWidth) return false;
		  for (int i = 0; i < this.length; i++)
		  {
			  var index = coords.GetIndex() + i * (int)this.orientation;
			  if (index is > Constants.GridHeight * Constants.GridWidth or < 0) return false;
		  }

		  return true;
	  }
   }
}
