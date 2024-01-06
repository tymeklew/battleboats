namespace battleboats
{
    public class Attack
    {
        public Guid PlayerId;
        public Coordinate coordinate;
        public bool hit;

        public Attack(Guid playerId, Coordinate coordinate, bool hit = false)
        {
            this.PlayerId = playerId;
            this.coordinate = coordinate;
            this.hit = hit;
        }
    }
}
