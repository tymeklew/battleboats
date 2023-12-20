namespace Battleboats
{
    public class Game
    {
        private PlayerBase[]? players;

        public Game()
        {
            this.NewGame();
        }

        public void NewGame()
        {
            Human human = new Human("Player");
            Bot bot = new Bot();

            this.players = new PlayerBase[2] { human, bot };
            foreach (var player in this.players) player.PlaceBoats();

        }

    }

}
