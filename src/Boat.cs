namespace battleboats
{
    public enum Orientation { Horizontal = 1, Vertical = Constants.GridWidth }

    public class Boat
    {
        public Coordinate coordinate;
        public Orientation orientation;
        public int length = 4;


        public Boat(Coordinate coordinate, Orientation orientation = Orientation.Horizontal)
        {
            this.coordinate = coordinate;
            this.orientation = orientation;
        }

        // Detects wether this specific boat has been hit given the coordinates
        public bool IsHit(Coordinate coordinate)
        {
            var stride = (int)this.orientation;
            var boat_index = this.coordinate.GetIndex();
            var bomb_index = coordinate.GetIndex();

            for (int i = 0; i < this.length; i++)
                if (bomb_index == boat_index + stride * i) return true;
            return false;
        }

        public bool HasSunk()
        {
            return false;
        }
    }
}
