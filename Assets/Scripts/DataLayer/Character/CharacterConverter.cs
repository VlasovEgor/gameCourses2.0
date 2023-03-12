
public class CharacterConverter 
{
   public void SetupStats(IEntity character,CharacterData data)
   {
        character.Get<SetDamageComponent>().SetDamage(data.Damage);
        character.Get<SetHealthPointComponent>().SetHealthPoint(data.CurrentHealthPoints);
        character.Get<SetLevelComponent>().SetLevel(data.Level);
        character.Get<SetSpeedComponent>().SetSpedd(data.MoveSpeed);
   }

    public CharacterData ConvertToData(IEntity character)
    {
        var data = new CharacterData
        {
            CurrentHealthPoints = character.Get<HealthPointComponent>().Value(),
            Level = character.Get<LevelComponent>().Value(),
            Damage = character.Get<PlayerDamageComponent>().Value(),
            MoveSpeed = character.Get<GetSpeedComponent>().Value()
        };

        return data;
    }
}
