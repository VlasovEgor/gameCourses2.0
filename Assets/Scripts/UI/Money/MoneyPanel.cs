using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    public void SetupMoney(string money)
    {
        _moneyText.text = money;
    }

    public void UpdateMoney(string money)
    {
        _moneyText.text = money;
    }

}
