
#if !UseStructs

public class Monster
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

    public virtual void Attack(ref Character character)
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

public class Troll : Monster
{
    public int Bonus;

    public Troll(int health, int damage, int armor, int experience, int experienceReward, int bonus)
        : base(health, damage, armor, experience, experienceReward)
    {
        Bonus = bonus;
    }

    public virtual void Defend(ref Character character)
    {
        //TODO 
    }

    public override void Attack(ref Character p)
    {
        //ALTA LOGICA DE ATAC
        //SI PUTEM FOLOSI MEMBRUL Bonus
        int doSomethingWithBonus = Bonus;
        //ETC
    }
}

#endif
