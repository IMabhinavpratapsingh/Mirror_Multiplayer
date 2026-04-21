using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public List<ShirtData> allShirtList;


    void Awake()
    {
        instance = this;
    }
}
