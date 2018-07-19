using System;
using System.Collections.Generic;

public class GameManager
{
    public List<Character> Characters { get; private set; }
    public List<Monster> Monsters { get; private set; }

    public GameManager(List<Monster> monsters, List<Character> characters)
    {
        this.Monsters = monsters;
        this.Characters = characters;
    }

    public List<string> BeginFight()
    {
        //FIGHT!
        List<string> result = new List<string>();
        bool fightShouldContinue = true;
        while (fightShouldContinue)
        {
            fightShouldContinue = false;
            List<int> indexesOfDeadCharacters = new List<int>();
            for (int i = 0; i < Characters.Count; i++)
            {
                Character character = Characters[i];
                List<int> indexesOfDeadMonsters = new List<int>();
                foreach (Monster monster in Monsters)
                {
                    //NO MATTER HOW YOU RESIZE THE ARRAY, THE WHILE CONDITION MUST BE THE SAME!!!!!
                    fightShouldContinue = true;
                    character.Attack(monster);
                    monster.Attack(character);
                    var indexOfMonster = Monsters.IndexOf(monster);
                    if (monster.Health <= 0)
                    {
                        result.Add(string.Format("Player {0} killed monster {1}", character.Id, monster.Id));
                        indexesOfDeadMonsters.Add(indexOfMonster);
                    }
                    if (character.Health <= 0)
                    {
                        result.Add(string.Format("Player {0} was killed by monster {1}", character.Id, monster.Id));
                        break;
                    }
                }
                int deadMonsterCounter = 0;
                foreach (var indexOfDeadMonster in indexesOfDeadMonsters)
                {
                    Monsters.RemoveAt(indexOfDeadMonster - deadMonsterCounter);
                    deadMonsterCounter++;
                }
                if (character.Health <= 0)
                {
                    indexesOfDeadCharacters.Add(i);
                }
            }
            int deadPlayerCounter = 0;
            foreach (var indexOfDeadCharacters in indexesOfDeadCharacters)
            {
                Characters.RemoveAt(indexOfDeadCharacters - deadPlayerCounter);
                deadPlayerCounter++;
            }
        }
        return result;
    }

    public string BeginFightFor(int playerId, int monsterId)
    {
        return string.Format("id of player is {0}, id of monster is {1}", playerId, monsterId);
        //TODO
    }

    public List<string> GetAllMonsters()
    {
        List<string> result = new List<string>();
        foreach(var monster in Monsters)
        {
            result.Add(string.Format("Monster id {0}: health={1}&armor={2}&damage={3}", 
            monster.Id, 
            monster.Health,
            monster.Armor,
            monster.Damage));
        }
        return result;
    }

    public List<string> GetAllPlayers()
    {
        List<string> result = new List<string>();
        foreach(var player in Characters)
        {
            result.Add(string.Format("Player id {0}: health={1}&armor={2}&damage={3}",
            player.Id, player.Health, player.Armor, player.Damage));
        }
        return result;
    }
}