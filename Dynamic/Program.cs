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
        Character[] characters = new Character[1];
        characters[0] = default(Character);
        //characters[0] = null;
        characters[0] = new Character(100, 20, 20, 1);

        //PREPARE MONSTERS
        Monster[] monsters = new Monster[GetNumberOfMonsters()];

        for(int i = 0; i < monsters.Length; i++)
        {
            monsters[i] = new Monster(1, 1, 1, 1, 1);
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
            for (int i = 0; i < characters.Length; i++)
            {
                Character character = characters[i];
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
                }
                int numberOfKilledMonsters = RemoveDeadElementsByRef(ref monsters);
            }
            RemoveDeadElementsByRef(ref characters);
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