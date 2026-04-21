using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CosmeticScript : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text price;
    [SerializeField] TMP_Text namee;
    [SerializeField] Button buyButton;

    public void SetUp(ShirtData data)
    {

        icon.sprite = data.shirtIcon;
        namee.text = data.namee;
        price.text = data.price.ToString();

        buyButton.onClick.AddListener(() =>
        {
            BuyItem(data.shirtId);
        });

    }


    void BuyItem(int id)
    {
        
    }

}
