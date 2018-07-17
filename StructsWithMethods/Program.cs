using System;
using static System.Convert;

public struct Program
{
    static void Main(string[] args)
    {
        //player
        int playerHealth = new int();
        playerHealth = 100;
        int playerDamage = new int();
        playerDamage = 20;
        int playerArmor = new int();
        playerArmor = 40;
        int playerExperience = new int();
        playerExperience = 0;
        //monster
        int monsterHealth = 30;
        int monsterDamage = 10;
        int monsterArmor = 10;
        int monsterExperience = 20;
        int monsterExperienceReward = 1;

        MonsterAttack(ref playerHealth, ref playerArmor, monsterDamage);

        //player as a struct
        int experience = 0;
        if (args.Length > 0)
            experience = ToInt32(args[0]);
        Character player = new Character(100, 20, 40, experience);

        Troll troll = new Troll(30, 10, 10, 20, 1, 2);

        troll.Monster.Attack(ref player);
        troll.Defend(ref player);

        Monster[] monsters = new Monster[player.Experience];

        for (int i = 0; i < monsters.Length; i++)
        {
            if (i % 5 == 0)
            {
                Monster monster = new Monster();
                MonsterInitialize(ref monster, 30, 10, 10, 20, 1);
                monsters[i] = monster;
            }
            if (i % 4 == 0)
            {
                monsters[i] = MonsterInitialize(30, 10, 10, 20, 1);
            }
            if (i % 3 == 0)
            {
                monsters[i] = new Monster(30, 10, 10, 20, 1);
            }
            if (i % 2 == 0)
            {
                Troll specializedMonster = new Troll(30, 10, 10, 20, 1, 3);
                monsters[i] = specializedMonster.Monster;
            }
          
        }

        for (int i = 0; i < monsters.Length; i++)
        {
            Monster monster = monsters[i];
            MonsterAttack(ref player, ref monster);
        }

        MonsterAttackDelegate monsterAttackDelegate = (ref Character p, ref Monster m) =>
        {
            if (p.Armor > m.Damage)
            {
                p.Armor = p.Armor - m.Damage;
            }
            else
            {
                int leftOverMonsterDamage = m.Damage - p.Armor;
                p.Armor = 0;
                p.Health = p.Health - leftOverMonsterDamage;
            }
        };

        AllMonstersAttackCharacter(ref player, monsters, monsterAttackDelegate);
    }

    static void MonsterAttack(ref Character character, ref Monster monster)
    {
        if (character.Armor > monster.Damage)
        {
            character.Armor = character.Armor - monster.Damage;
        }
        else
        {
            int leftOverMonsterDamage = monster.Damage - character.Armor;
            character.Armor = 0;
            character.Health = character.Health - leftOverMonsterDamage;
        }
    }

    static void AllMonstersAttackCharacter(ref Character player, Monster[] monsters)
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            Monster monster = monsters[i];

            monster.Attack(ref player);
        }
    }

    static void AllMonstersAttackCharacter(ref Character player, Monster[] monsters, MonsterAttackDelegate monsterAttackDelegate)
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            monsterAttackDelegate(ref player, ref monsters[i]);
        }
    }


    static Character CharacterInitialize(int health, int damage, int armor, int experience)
    {
        Character character = new Character();
        character.Health = health;
        character.Damage = damage;
        character.Armor = armor;
        character.Experience = experience;
        return character;
    }

    static Monster MonsterInitialize(int health, int damage, int armor, int experience, int experienceReward)
    {
        Monster monster = new Monster();
        monster.Health = health;
        monster.Damage = damage;
        monster.Armor = armor;
        monster.Experience = experience;
        monster.ExperienceReward = experienceReward;
        return monster;
    }

    static void CharacterInitialize(ref Character character, int health, int damage, int armor, int experience)
    {
        character.Health = health;
        character.Damage = damage;
        character.Armor = armor;
        character.Experience = experience;
    }

    static void MonsterInitialize(ref Monster monster, int health, int damage, int armor, int experience, int experienceReward)
    {
        monster.Health = health;
        monster.Damage = damage;
        monster.Armor = armor;
        monster.Experience = experience;
        monster.ExperienceReward = experienceReward;
    }

    static void MonsterAttack(ref int playerHealth, ref int playerArmor, int monsterDamage)
    {
        if (playerArmor > monsterDamage)
        {
            playerArmor = playerArmor - monsterDamage;
        }
        else
        {
            int leftOverMonsterDamage = monsterDamage - playerArmor;
            playerArmor = 0;
            playerHealth = playerHealth - leftOverMonsterDamage;
        }
    }
}
