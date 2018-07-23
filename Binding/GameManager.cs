using System;
using System.Collections.Generic;

public class GameManager
{
    public List<Character> Characters { get; private set; }
    public List<Monster> Monsters { get; private set; }

    public GameManager(List<Monster> monsters, List<Character> characters)
    {
        this.Monsters = monsters;
        this.Characters = characters;
    }

    public List<string> BeginFight()
    {
        //FIGHT!
        List<string> result = new List<string>();
        bool fightShouldContinue = true;
        while (fightShouldContinue)
        {
            fightShouldContinue = false;
            List<int> indexesOfDeadCharacters = new List<int>();
            for (int i = 0; i < Characters.Count; i++)
            {
                Character character = Characters[i];
                List<int> indexesOfDeadMonsters = new List<int>();
                foreach (Monster monster in Monsters)
                {
                    //NO MATTER HOW YOU RESIZE THE ARRAY, THE WHILE CONDITION MUST BE THE SAME!!!!!
                    fightShouldContinue = true;
                    character.Attack(monster);
                    monster.Attack(character);
                    var indexOfMonster = Monsters.IndexOf(monster);
                    if (monster.Health <= 0)
                    {
                        result.Add(string.Format("Player {0} killed monster {1}", character.Id, monster.Id));
                        indexesOfDeadMonsters.Add(indexOfMonster);
                    }
                    if (character.Health <= 0)
                    {
                        result.Add(string.Format("Player {0} was killed by monster {1}", character.Id, monster.Id));
                        break;
                    }
                }
                int deadMonsterCounter = 0;
                foreach (var indexOfDeadMonster in indexesOfDeadMonsters)
                {
                    Monsters.RemoveAt(indexOfDeadMonster - deadMonsterCounter);
                    deadMonsterCounter++;
                }
                if (character.Health <= 0)
                {
                    indexesOfDeadCharacters.Add(i);
                }
            }
            int deadPlayerCounter = 0;
            foreach (var indexOfDeadCharacters in indexesOfDeadCharacters)
            {
                Characters.RemoveAt(indexOfDeadCharacters - deadPlayerCounter);
                deadPlayerCounter++;
            }
        }
        return result;
    }

    public string BeginFightFor(int playerId, int monsterId)
    {
        return string.Format("id of player is {0}, id of monster is {1}", playerId, monsterId);
        //TODO
    }

    public List<MonsterViewModel> GetAllMonsters()
    {
        List<MonsterViewModel> result = new List<MonsterViewModel>();
        foreach (var monster in Monsters)
        {
            result.Add(new MonsterViewModel
            {
                Id = monster.Id,
                Armor = monster.Armor,
                Health = monster.Health,
                Damage = monster.Damage
            });
        }
        return result;
    }

    public List<CharacterViewModel> GetAllPlayers()
    {
        List<CharacterViewModel> result = new List<CharacterViewModel>();
        foreach (var player in Characters)
        {
            result.Add(new CharacterViewModel
            {
                Id = player.Id,
                Health = player.Health,
                Armor = player.Armor,
                Damage = player.Damage
            });
        }
        return result;
    }

    public void CreateCharacter(Character character)
    {
        character.Id = 1;
        if(Characters.Count > 0)
        {
            character.Id += Characters[Characters.Count - 1].Id;
        }
        Characters.Add(character);
    }

    public void UpdateCharacter(CharacterUpdateViewModel character)
    {
        foreach(var existingCharacter in Characters)
        {
            if(existingCharacter.Id == character.Id)
            {
                if(character.Armor.HasValue)
                    existingCharacter.Armor = character.Armor.Value;
                if(character.Health.HasValue)
                    existingCharacter.Health = character.Health.Value;
                if(character.Experience.HasValue)
                    existingCharacter.Experience = character.Experience.Value;
                if(character.Damage.HasValue)
                    existingCharacter.Damage = character.Damage.Value;
                break;
            }
        }
    }
}