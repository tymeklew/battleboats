namespace battleboats
{
    public class Game
    {
        public int turn = 0;
        private PlayerBase[]? players;

        public Game() { }

        public void Start()
        {
            this.players = new PlayerBase[2];
            this.players[0] = new Human();
            this.players[0].Setup();
            this.players[1] = new Human();
            this.players[1].Setup();


            while (true)
            {

                var attacker = this.players[this.turn % 2];
                var defender = this.players[(this.turn + 1) % 2];

                Ui.Grid(attacker.Render());



                var coords = attacker.Target();

                var hit = defender.Attack(coords);
                attacker.history.Add(new Attack(attacker.id, coords, hit));

                this.turn++;
            }
        }
    }
}
