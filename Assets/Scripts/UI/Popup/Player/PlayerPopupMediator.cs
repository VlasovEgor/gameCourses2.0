using UnityEngine;

public class PlayerPopupMediator : MonoBehaviour,IStartGameListener,IFinishGameListener
{
    [SerializeField] private PlayerPopup _playerPopup;
   // [SerializeField] private SaveLoadUpgrade _saveLoadUpgrade;

    private void LevelUpdate()
    {
        _playerPopup.UpdatingStatsAfterLoading();
    }

    public void OnStartGame()
    {
       // _saveLoadUpgrade.OnLoadUpgrade += LevelUpdate;
    }

    public void OnFinishGame()
    {
       // _saveLoadUpgrade.OnLoadUpgrade -= LevelUpdate;
    }
}