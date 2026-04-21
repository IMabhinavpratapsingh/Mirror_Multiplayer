
using System.Collections.Generic;

using TMPro;
using UnityEngine;


public class ChatBubble : MonoBehaviour
{
    public static ChatBubble instance;
    [SerializeField] List<GameObject> bubblePool;
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] Transform content;

    
    void Awake()
    {
        bubblePool = new List<GameObject>();

    }
    GameObject GetBubble()
    {
        
        foreach(var bubble in bubblePool)
        {
            if (!bubble.activeInHierarchy)
            {
                bubble.SetActive(true);
                
                bubble.transform.SetAsLastSibling();
                return bubble;
            }
        }
        GameObject newBubble = Instantiate(bubblePrefab, content);
        bubblePool.Add(newBubble);
        return newBubble;
    }
    
   public void ShowMessage(string words)
    {
        GameObject obj = GetBubble();
        obj.GetComponent<ShowChat>().SetText(words);
    }
    
    
}
