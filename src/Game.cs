using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace battleboats
{
   public class Game
   {
	  [JsonPropertyName("turn")]
	  public int _turn { get; set; } = 0;
	  [JsonPropertyName("players")]
	  public PlayerBase[]? _players { get; set; }

	  public Game()
	  {
		 this._players = new PlayerBase[2];
	  }

	  public void Start()
	  {
		 if (this._players == null || this._players.Count() < 2) return;

		 foreach (var player in this._players)
		 {
			if (player.boats.Count == 0)
			{
			   player.Setup();
			}
		 }

		 while (this._players.All(player => !player.HasLost()))
		 {
			this.Save();
			var attacker = this._players[this._turn % 2];
			var defender = this._players[(this._turn + 1) % 2];

			var coords = attacker.Target();

			var hit = defender.Attack(coords, attacker.id);
			// Allows the player to play another turn after getting a hit
			if (hit) this._turn++;

			attacker.history.Add(new Attack(attacker.id, coords, hit));

			this._turn++;
		 }

		 Console.WriteLine(this._players[0].HasLost() ? "You Loose" : "You win");
	  }


	  public void Save()
	  {
		 File.Create("./save.json").Close();
		 var json = JsonConvert.SerializeObject(this, new JsonSerializerSettings
		 {
			TypeNameHandling = TypeNameHandling.All
		 });
		 File.WriteAllText("./save.json", string.Empty);
		 File.WriteAllText("./save.json", json);
	  }

	  public static Game? Load()
	  {
		 string json = File.ReadAllText("./save.json");
		 return JsonConvert.DeserializeObject(json, new JsonSerializerSettings()
		 {
			TypeNameHandling = TypeNameHandling.All
		 }) as Game;
	  }
   }
}
