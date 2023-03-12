
using TMPro;
using UnityEngine;

    public sealed class BuyButton : CustomButton
    {

        [Space]
        [SerializeField]
        private TextMeshProUGUI priceText;


        public void SetPrice(string price)
        {
            priceText.text = price;
        }
    }

