using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Character
{
    public int Id { get; set;}
    private int health;
    public int Experience { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public int Health
    {
        get { return health; }
        set
        {
            if (value < 0)
                health = 0;
            else
                health = value;
        }
    }
    
    public Character(int health, int damage, int armor, int experience)
    {
        this.Health = health;
        this.Damage = damage;
        this.Armor = armor;
        this.Experience = experience;
    }

    public Character()
    {
        
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