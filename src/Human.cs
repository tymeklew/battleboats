namespace Battleboats
{
    public class Human : PlayerBase
    {
        public Human(string name) : base(name) { }

        public override void PlaceBoats()
        {
            for (int i = 0; i < 2; i++)
            {
                int length = 4;
                var placed = false;

                (Coordinate, Orientation) prev = (new Coordinate(), Orientation.Horizontal);
                (Coordinate, Orientation) current = new(new Coordinate(), Orientation.Horizontal);

                while (!placed)
                {
                    Console.Clear();

                    if (this.IsBoatValid(current.Item1, length, current.Item2)) prev = current;
                    else current = prev;

                    this.PlaceBoat(current.Item1, length, current.Item2, Tile.Boat);
                    Ui.Grid(this.fleet);
                    this.PlaceBoat(current.Item1, length, current.Item2, Tile.Empty);

                    switch (Console.ReadKey(true).Key)
                    {
                        // Up
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W: current.Item1.y--; break;
                        // Left 
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A: current.Item1.x--; break;
                        // Down 
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S: current.Item1.y++; break;
                        // Right 
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D: current.Item1.x++; break;
                        // Rotate
                        case ConsoleKey.Spacebar:
                            current.Item2 = (Orientation)(((int)current.Item2 + 1) % 2);
                            break;
                        // Place
                        case ConsoleKey.Enter: placed = true; break;
                    }

                    Console.SetCursorPosition(0, 1);
                }

                this.PlaceBoat(current.Item1, length, current.Item2, Tile.Boat);

            }

        }
    }
}
