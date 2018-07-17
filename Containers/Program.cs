using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //PREPARE PLAYERS
        List<Character> characters = new List<Character>();
        characters.Add(new Character(100, 20, 20, 1));

        //PREPARE MONSTERS
        List<Monster> monsters = new List<Monster>();

        for(int i = 0; i < GetNumberOfMonsters(); i++)
        {
            monsters.Add(new Monster(1, 1, 1, 1, 1));
        }

        //SWAP ELEMENT AT INDEX 2 WITH ELEMENT AT INDEX 3
        Monster temporaryMonster = monsters[3];
        monsters[3] = monsters[2];
        monsters[2] = temporaryMonster;

        //SET THE DEFAULT VALUE OF MONSTER
        monsters[1] = default(Monster);
        //WHICH IS THE SAME AS BELOW
        monsters[1] = null;
      

        //FIGHT!
        bool fightShouldContinue = true;
        while(fightShouldContinue)
        {
            fightShouldContinue = false;
            List<int> indexesOfDeadCharacters = new List<int>();
            for (int i = 0; i < characters.Count; i++)
            {
                Character character = characters[i];
                List<int> indexesOfDeadMonsters = new List<int>();
                foreach (Monster monster in monsters)
                {
                    //NO MATTER HOW YOU RESIZE THE ARRAY, THE WHILE CONDITION MUST BE THE SAME!!!!!
                    fightShouldContinue = true;
                    if (character.Health <= 0)
                    {
                        break;
                    }
                    character.Attack(monster);
                    monster.Attack(ref character);
                    if (monster.Health == 0)
                        indexesOfDeadMonsters.Add(monsters.IndexOf(monster));
                }
                foreach(var indexOfDeadMonster in indexesOfDeadMonsters)
                {
                    monsters.RemoveAt(indexOfDeadMonster);
                }
                if(character.Health == 0)
                {
                    indexesOfDeadCharacters.Add(i);
                }
            }
            foreach (var indexOfDeadCharacters in indexesOfDeadCharacters)
            {
                characters.RemoveAt(indexOfDeadCharacters);
            }
        }
    }

    static int RemoveDeadElements(Monster[] elements)
    {
        return -1;
    }

    static int RemoveDeadElements(Character[] elements)
    {
        return -1;
    }

    static int RemoveDeadElementsByRef(ref Monster[] elements)
    {
        return -1;
    }

    static int RemoveDeadElementsByRef(ref Character[] elements)
    {
        return -1;
    }

    private static int GetNumberOfMonsters()
    {
        return (int)DateTime.Now.Ticks;
    }
}