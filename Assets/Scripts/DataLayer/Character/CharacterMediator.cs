
public class CharacterMediator
{
    private CharacterRepository _characterRepository;
    private CharacterConverter _characterConverter= new CharacterConverter();

    public void Construct(CharacterRepository repository)
    {
        _characterRepository= repository;
    }

    public void LoadData(IGameContext context, int id)
    {
        _characterRepository.TryLoadStats(out CharacterData data, id);
        
       // IEntity character = context.GetService<PlayersGroup>().FindPlayer(id).GetEntity();

       // _characterConverter.SetupStats(character, data);
        
    }


    public void SaveData(IGameContext context, int id)
    {
        //IEntity character = context.GetService<PlayersGroup>().FindPlayer(id).GetEntity();
       // var data = _characterConverter.ConvertToData(character);
       
        //_characterRepository.SaveStats(data,id);
    }
} 