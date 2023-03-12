using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerShower : MonoBehaviour, IConstructListener
{
    private PopupManager _popupManager;
    private PlayerPresentationModelFactory _presenerFactory;

    public void Construct(GameContext context)
    {
        //_presenerFactory = context.GetService<PlayerPresentationModelFactory>();
        //_popupManager = context.GetService<PopupManager>();
    }

    [Button]
    public void ShowPLayer(PlayerInfo player)
    {
        var presentationModel = _presenerFactory.CreatePresenter(player);
        _popupManager.ShowPopup(PopupName.PLAYER, presentationModel);
    }
}
