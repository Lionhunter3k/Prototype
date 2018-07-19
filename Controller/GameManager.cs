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

    public void BeginFight()
    {
        //FIGHT!
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
                        Console.WriteLine("Player {0} killed monster {1}", i, indexOfMonster);
                        indexesOfDeadMonsters.Add(indexOfMonster);
                    }
                    if (character.Health <= 0)
                    {
                        Console.WriteLine("Player {0} was killed by monster {1}", i, indexOfMonster);
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
    }

    public void BeginFightFor(int indexOfPlayer, int indexOfMonster)
    {
        //TODO
    }
}