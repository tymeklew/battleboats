namespace battleboats
{
    public class Human : PlayerBase
    {

        public override void Setup()
        {
            Console.Write("Input your coordinates in the format X,Y : ");
            string[] input = Console.ReadLine().Split(",");

            var coords = new Coordinate(int.Parse(input.First().ToString()), int.Parse(input.Last().ToString()));

            var boat = new Boat(coords);
        }

        public override Coordinate Target()
        {
            Console.Write("X : ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Y : ");
            int y = int.Parse(Console.ReadLine());

            return new Coordinate(x, y);
        }
    }
}
