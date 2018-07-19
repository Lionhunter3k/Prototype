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
        characters.Add(new Character(100, 20, 20, 1));
        characters.Add(new Character(100, 20, 20, 1));
        characters.Add(new Character(200, 20, 20, 1));

        //PREPARE MONSTERS
        List<Monster> monsters = new List<Monster>();

        for(int i = 0; i < GetNumberOfMonsters(); i++)
        {
            monsters.Add(new Monster(i + 1, i + 1, i + 1, i + 1, i + 1));
        }      

        GameManager manager = new GameManager(monsters, characters);
       
        Console.WriteLine("What action do you want to take?");
        var parameter = Console.ReadLine();
        parameter = parameter.Trim();
        if(parameter == "BeginFight")
        {
            manager.BeginFight();
        }
        if(parameter.StartsWith("BeginFightFor"))
        {
            string parameterPart = parameter.Substring("BeginFightFor".Length);
            
            string[] parameters = parameterPart.Split('&');
            
            int indexOfPlayer = -1;
            int indexOfMonster = -1;

            foreach(string keyValueParameter in parameters)
            {
                if(keyValueParameter.Trim().StartsWith("indexOfPlayer"))
                {
                    int startIndex = keyValueParameter.IndexOf('=');
                    string rawValue = keyValueParameter.Substring(startIndex);

                    indexOfPlayer = int.Parse(rawValue);
                    continue;
                }
                if(keyValueParameter.Trim().StartsWith("indexOfMonster"))
                {
                    int startIndex = keyValueParameter.IndexOf('=');
                    string rawValue = keyValueParameter.Substring(startIndex);
                    indexOfMonster = int.Parse(rawValue);
                    continue;
                }
            }
        }
    }
}