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
}