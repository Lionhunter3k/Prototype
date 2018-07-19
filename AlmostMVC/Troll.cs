
public class Troll : Monster
{
    public int Bonus;

    public Troll(int health, int damage, int armor, int experience, int experienceReward, int bonus)
        : base(health, damage, armor, experience, experienceReward)
    {
        Bonus = bonus;
    }

    public virtual void Defend(Character character)
    {
        //TODO 
    }

    public override void Attack(Character p)
    {
        //ALTA LOGICA DE ATAC
        //SI PUTEM FOLOSI MEMBRUL Bonus
        int doSomethingWithBonus = Bonus;
        //ETC
        base.Attack(p);
    }
}