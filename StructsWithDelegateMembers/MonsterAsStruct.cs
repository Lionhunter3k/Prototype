using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void MonsterAttackDelegate(ref Character character, ref Monster monster);

public struct Monster
{
    public int Health;
    public int Damage;
    public int Armor;
    public int Experience;
    public int ExperienceReward;
    public MonsterAttackDelegate Attack;

    public Monster(int health, int damage, int armor, int experience, int experienceReward)
    {
        this.Health = health;
        this.Damage = damage;
        this.Armor = armor;
        this.Experience = experience;
        this.ExperienceReward = experienceReward;
        this.Attack = MonsterAttack;
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
}

public delegate void MonsterDefendDelegate(ref Character character, ref Troll troll);

public struct Troll
{
    public Monster Monster;
    public int Bonus;
    public MonsterDefendDelegate Defend;

    public Troll(int health, int damage, int armor, int experience, int experienceReward, int bonus)
    {
        Monster = new Monster(health, damage, armor, experience, experienceReward);
        Bonus = bonus;
        Monster.Attack = TrollAttack;
        Defend = TrollDefend;
    }

    static void TrollAttack(ref Character character, ref Monster monster)
    {
        //TODO 
    }

    static void TrollDefend(ref Character character, ref Troll troll)
    {
        //TODO 
    }
}

