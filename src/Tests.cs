using System.Diagnostics;

namespace battleboats
{
   public class Tests
   {
	  public static void Run()
	  {
		 BoatConflictTest();
	  }

	  // Tests for the Boat.ConflictsWith method
	  private static void BoatConflictTest()
	  {
		 Boat boat1 = new Boat(new Coordinate(0, 0), 4 ,Orientation.Horizontal );
		 Boat boat2 = new Boat(new Coordinate(0, 0), 4,Orientation.Horizontal) ;
		 Debug.Assert(boat1.ConflictsWith(boat2) == true, "Boat conflict test failed (1)");

		 boat1 = new Boat(new Coordinate(4, 0), 4, Orientation.Horizontal);
		 boat2 = new Boat(new Coordinate(9, 0), 4, Orientation.Vertical);
		 Debug.Assert(boat1.ConflictsWith(boat2) == false, "Boat conflict test failed (2)");

		 boat1 = new Boat(new Coordinate(4, 0), 4, Orientation.Horizontal);
		 boat2 = new Boat(new Coordinate(3, 0), 4, Orientation.Horizontal);
		 Debug.Assert(boat1.ConflictsWith(boat2) == true, "Boat conflict test failed (3)");

		 boat1 = new Boat(new Coordinate(4, 0), 4, Orientation.Vertical);
		 boat2 = new Boat(new Coordinate(4, 3), 4, Orientation.Vertical);
		 Debug.Assert(boat1.ConflictsWith(boat2) == true, "Boat conflict test failed (4)");

		 boat1 = new Boat(new Coordinate(4, 0), 4, Orientation.Vertical);
		 boat2 = new Boat(new Coordinate(4, 6), 4 , Orientation.Vertical);
		 Debug.Assert(boat1.ConflictsWith(boat2) == false, "Boat conflict test failed (5)");
	  }
   }

}
