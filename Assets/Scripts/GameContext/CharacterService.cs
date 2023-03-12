using UnityEngine;

public class CharacterService : MonoBehaviour
{
    [SerializeField] private Entity _character;

    public Entity GetCharacter()
    {
        return _character;
    }
}
