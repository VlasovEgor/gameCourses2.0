using Sirenix.OdinInspector;
using UnityEngine;

public class ProductShower : MonoBehaviour,IConstructListener
{   
    private PopupManager _popupManager;
    private ProductPresentationModelFactory _presenerFactory;

    public void Construct(GameContext context)
    {
       // _presenerFactory = context.GetService<ProductPresentationModelFactory>();
       // _popupManager = context.GetService<PopupManager>();
    }

    [Button]
    public void ShowProduct(ProductInfo product)
    {
        var presentationModel = _presenerFactory.CreatePresenter(product);
        _popupManager.ShowPopup(PopupName.PRODUCT, presentationModel);
        
    }
}