using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void MonsterAttackDelegate(ref Character character, ref Monster monster);

public delegate void MonsterDefendDelegate(ref Character character, ref Troll troll);

public struct Monster
{
    public int Health;
    public int Damage;
    public int Armor;
    public int Experience;
    public int ExperienceReward;

    public Monster(int health, int damage, int armor, int experience, int experienceReward)
    {
        this.Health = health;
        this.Damage = damage;
        this.Armor = armor;
        this.Experience = experience;
        this.ExperienceReward = experienceReward;
    }

    public void Attack(ref Character character)
    {
        if (character.Armor > this.Damage)
        {
            character.Armor = character.Armor - this.Damage;
        }
        else
        {
            int leftOverMonsterDamage = this.Damage - character.Armor;
            character.Armor = 0;
            character.Health = character.Health - leftOverMonsterDamage;
        }
    }
}

public struct Troll 
{
    public Monster Monster;

    public int Bonus;

    public Troll(int health, int damage, int armor, int experience, int experienceReward, int bonus)
    {
        Monster = new Monster(health, damage, armor, experience, experienceReward);
        Bonus = bonus;
    }

    public void Defend(ref Character character)
    {
        //TODO 
    }
}

