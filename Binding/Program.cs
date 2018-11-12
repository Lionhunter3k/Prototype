using System;
using System.Collections.Generic;

class Program
{
    private static int GetNumberOfMonsters()
    {
        return 1000;
    }

    static bool BindParameter(object parameter, IRequestParameterCollection request, List<string> optionalParameters)
    {
        var properties = parameter.GetType().GetProperties();
        bool allPropertiesSet = true;
        foreach (var property in properties)
        {
            if (request.ContainsKey(property.Name))
            {
                string rawValue = request.GetValue(property.Name);
                object convertedValue = Convert.ChangeType(rawValue, 
                    property.PropertyType.GetGenericArguments().Length == 1 
                    ? 
                    property.PropertyType.GetGenericArguments()[0] 
                    : 
                    property.PropertyType);
                property.SetValue(parameter, convertedValue);
            }
            else
            {
                if (optionalParameters.IndexOf(property.Name) == -1)
                    allPropertiesSet = false;
            }
        }
        return allPropertiesSet;
    }

    static IRequestParameterCollection GetRequest(string parameterPart)
    {
        int indexOfFormat = parameterPart.IndexOf('-');
        string format = "urlformencoded";
        if (indexOfFormat > -1)
        {
            string formatWithParameters = parameterPart.Substring(indexOfFormat + 1);
            //urlformencoded playerId=2&monsterId=3
            indexOfFormat = formatWithParameters.IndexOf(' ');
            if (indexOfFormat > -1)
            {
                format = formatWithParameters.Substring(0, indexOfFormat);
                parameterPart = formatWithParameters.Substring(format.Length);
            }
        }
        IRequestParameterCollection request = null;
        if (format == "urlformencoded")
            request = new RequestParameterCollection(parameterPart);
        if (format == "json")
            request = new JsonRequestParameterCollection(parameterPart);
        return request;
    }

    static void Main(string[] args)
    {
        //PREPARE PLAYERS
        List<Character> characters = new List<Character>();
        int idsForCharacters = 1;
        characters.Add(new Character(100, 20, 20, 1) { Id = idsForCharacters++ });
        characters.Add(new Character(100, 20, 20, 1) { Id = idsForCharacters++ });
        characters.Add(new Character(200, 20, 20, 1) { Id = idsForCharacters++ });

        //PREPARE MONSTERS
        List<Monster> monsters = new List<Monster>();
        int idsForMonsters = 1;
        for (int i = 0; i < GetNumberOfMonsters(); i++)
        {
            monsters.Add(new Monster(i + 1, i + 1, i + 1, i + 1, i + 1) { Id = idsForMonsters++ });
        }

        GameManager manager = new GameManager(monsters, characters);

        Console.WriteLine("What action do you want to take?");
        while (true)
        {
            var parameter = Console.ReadLine();
            parameter = parameter.Trim();
            if (parameter == "quit")
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
            if (parameter.StartsWith("CreateCharacter"))
            {
                string parameterPart = parameter.Substring("CreateCharacter".Length);
                var request = GetRequest(parameterPart);
                Character character = new Character();
                List<string> optionalParameters = new List<string>();
                optionalParameters.Add("Id");
                bool allPropertiesSet = BindParameter(character, request, optionalParameters);
                if (allPropertiesSet)
                {
                    manager.CreateCharacter(character);
                }
                else
                {
                    Console.WriteLine("Not all parameters were sent");
                }
            }
            if (parameter.StartsWith("UpdateCharacter"))
            {
                string parameterPart = parameter.Substring("UpdateCharacter".Length);
                var request = GetRequest(parameterPart);
                CharacterUpdateViewModel character = new CharacterUpdateViewModel();
                List<string> optionalParameters = new List<string>();
                optionalParameters.Add("Health");
                optionalParameters.Add("Armor");
                optionalParameters.Add("Experience");
                optionalParameters.Add("Damage");
                bool allPropertiesSet = BindParameter(character, request, optionalParameters);
                if (allPropertiesSet)
                {
                    manager.UpdateCharacter(character);
                }
                else
                {
                    Console.WriteLine("Not all parameters were sent");
                }
            }
            if (parameter.StartsWith("BeginFightFor"))
            {
                //BeginFightFor -urlformencoded playerId=2&monsterId=3
                string parameterPart = parameter.Substring("BeginFightFor".Length);
                var request = GetRequest(parameterPart);

                int? playerId = null;
                int? monsterId = new Nullable<int>();
                if (request.ContainsKey("playerId"))
                {
                    string rawValue = request.GetValue("playerId");
                    playerId = int.Parse(rawValue);
                }
                if (request.ContainsKey("monsterId"))
                {
                    string rawValue = request.GetValue("monsterId");
                    monsterId = int.Parse(rawValue);
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
                    Console.WriteLine(string.Format("Monster id {0}: health={1}&armor={2}&damage={3}",
                     monster.Id,
                     monster.Health,
                     monster.Armor,
                     monster.Damage));
                }
                foreach (var player in allPlayers)
                {
                    Console.WriteLine(string.Format("Player id {0}: health={1}&armor={2}&damage={3}",
                    player.Id,
                    player.Health,
                    player.Armor,
                    player.Damage));
                }
            }
        }
    }
}