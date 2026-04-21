
using UnityEngine;
using UnityEngine.UI;

public class CosmeticUI : MonoBehaviour
{
    [Header("SHOP UI")]
    [SerializeField] GameObject shopScreen;
    [SerializeField] Button shopButton;

    [Header("Inventory UI")]
    [SerializeField] GameObject inventoryScreen;
    [SerializeField] Button inventoryButton;

    [Header("BACK BUTTON")]
    [SerializeField] GameObject BackButtonScreen;
    [SerializeField] Button backButton;

    void Awake()
    {
        shopButton.onClick.AddListener(() =>
        {
            shopScreen.SetActive(true);
            BackButtonScreen.SetActive(true);
        });
        inventoryButton.onClick.AddListener(() =>
        {
            inventoryScreen.SetActive(true);
            BackButtonScreen.SetActive(true);
        });
        backButton.onClick.AddListener(() =>
        {
            shopScreen.SetActive(false);
            inventoryScreen.SetActive(false);
            BackButtonScreen.SetActive(false);    
        });
    } 
}
