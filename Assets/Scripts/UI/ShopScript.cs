

using System;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject rowPrefab;
    [SerializeField] GameObject shopItemPrefab;

    

    void Start()
    {

        AddShirts();

    }


    public void AddShirts()
    {
        int itemsPerRow = 2;
        GameObject currentRow = null;

        for(int i = 0; i < GameManager.instance.allShirtList.Count;i++)
        {
            if(i % itemsPerRow == 0)
            {

                currentRow = Instantiate(rowPrefab,content);

            }


            GameObject obj = Instantiate(shopItemPrefab,currentRow.transform);
            obj.GetComponent<CosmeticScript>().SetUp(GameManager.instance.allShirtList[i]);
        
        
        }
    }

}

