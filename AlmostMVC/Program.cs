using System;
using System.Collections.Generic;

class Program
{
    private static int GetNumberOfMonsters()
    {
        return 1000;
    }

    static void Main(string[] args)
    {
        //PREPARE PLAYERS
        List<Character> characters = new List<Character>();
        int idsForCharacters = 1;
        characters.Add(new Character(100, 20, 20, 1){ Id = idsForCharacters++ });
        characters.Add(new Character(100, 20, 20, 1){ Id = idsForCharacters++ });
        characters.Add(new Character(200, 20, 20, 1){ Id = idsForCharacters++ });

        //PREPARE MONSTERS
        List<Monster> monsters = new List<Monster>();
        int idsForMonsters = 1;
        for (int i = 0; i < GetNumberOfMonsters(); i++)
        {
            monsters.Add(new Monster(i + 1, i + 1, i + 1, i + 1, i + 1){ Id = idsForMonsters++ });
        }

        GameManager manager = new GameManager(monsters, characters);

        Console.WriteLine("What action do you want to take?");
        while (true)
        {
            var parameter = Console.ReadLine();
            parameter = parameter.Trim();
            if(parameter == "quit")
            {
                break;
            }
            if (parameter == "BeginFight")
            {
                var result = manager.BeginFight();
                foreach (var fight in result)
                {
                    Console.WriteLine(fight);
                }
            }
            if (parameter.StartsWith("BeginFightFor"))
            {
                string parameterPart = parameter.Substring("BeginFightFor".Length);

                string[] parameters = parameterPart.Split('&');

                int? playerId = new Nullable<int>();
                int? monsterId = new Nullable<int>();

                foreach (string keyValueParameter in parameters)
                {
                    if (keyValueParameter.Trim().StartsWith("playerId"))
                    {
                        int startIndex = keyValueParameter.IndexOf('=');
                        string rawValue = keyValueParameter.Substring(startIndex + 1);

                        playerId = int.Parse(rawValue);
                        continue;
                    }
                    if (keyValueParameter.Trim().StartsWith("monsterId"))
                    {
                        int startIndex = keyValueParameter.IndexOf('=');
                        string rawValue = keyValueParameter.Substring(startIndex + 1);
                        monsterId = int.Parse(rawValue);
                        continue;
                    }
                }
                if (playerId.HasValue
                && playerId.Value > -1
                && playerId.Value < manager.Characters.Count
                && monsterId.HasValue
                && monsterId.Value > -1
                && monsterId.Value < manager.Monsters.Count)
                {
                    var result = manager.BeginFightFor(playerId.Value, monsterId.Value);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Not all parameters were sent");
                }
            }
            if (parameter.StartsWith("GetAllEntities"))
            {
                var allMonsters = manager.GetAllMonsters();
                var allPlayers = manager.GetAllPlayers();
                foreach (var monster in allMonsters)
                {
                    Console.WriteLine(monster);
                }
                foreach (var player in allPlayers)
                {
                    Console.WriteLine(player);
                }
            }
        }
    }
}