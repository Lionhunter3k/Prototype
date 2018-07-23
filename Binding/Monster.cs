public class Monster
{
    public int Id { get; set; }
    public virtual int Health { get; set ; }
    public virtual int Damage { get; set ; }
    public virtual int Armor { get; set ; }
    public virtual int Experience { get; set ; }
    public virtual int ExperienceReward { get; set ; }

    public Monster(int health, int damage, int armor, int experience, int experienceReward)
    {
        this.Health = health;
        this.Damage = damage;
        this.Armor = armor;
        this.Experience = experience;
        this.ExperienceReward = experienceReward;
    }

    public virtual void Attack(Character character)
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
