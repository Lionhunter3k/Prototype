using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Character
{
    public int Health;
    public int Damage;
    public int Armor;
    public int Experience;

    public Character(int health, int damage, int armor, int experience)
    {
        this.Health = health;
        this.Damage = damage;
        this.Armor = armor;
        this.Experience = experience;
    }

    public void Attack(Monster monster)
    {
        if (monster.Armor > this.Damage)
        {
            monster.Armor = monster.Armor - this.Damage;
        }
        else
        {
            int leftOverMonsterDamage = this.Damage - monster.Armor;
            monster.Armor = 0;
            monster.Health = monster.Health - leftOverMonsterDamage;
        }
    }
}