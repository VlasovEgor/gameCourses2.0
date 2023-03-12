using UnityEngine;
using Zenject;

public class SceneContextFromGameScene : MonoBehaviour
{
    [SerializeField] private SceneContext _sceneContext;  
    
    public SceneContext GetSceneContext()
    {   
        return _sceneContext;
    }
}
