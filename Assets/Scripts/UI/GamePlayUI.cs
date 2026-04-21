using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI instance;
    [SerializeField] public Slider HealthBar;
    [SerializeField] Button throwButton;
    [SerializeField] TMP_InputField input;
    [SerializeField] Button submitButton;

    public static event Action shoot;
    public static event Action<string> message;

    void Awake()
    {
        instance = this;
        throwButton.onClick.AddListener(() =>
        {
           shoot?.Invoke(); 
        });

        submitButton.onClick.AddListener(() =>
        {
            
            message?.Invoke(input.text);
            input.text = "";
        });
    }
}
