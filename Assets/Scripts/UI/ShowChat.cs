
using UnityEngine;
using System.Collections;

using TMPro;
using System;

public class ShowChat : MonoBehaviour
{
    [SerializeField] public TMP_Text textUI;
    public Transform forrot;
    public OrbitCamera cam;
    public static Transform mainCamTransform;
    void Start()
    {
        // 1. Agar pehli baar koi message spawn hua, toh camera dhoondo
        if (mainCamTransform == null)
        {
            // Pehle scene mein OrbitCamera dhoondo (jo tumhara main camera script hai)
            OrbitCamera orbit = FindAnyObjectByType<OrbitCamera>(FindObjectsInactive.Include);
            if (orbit != null)
            {
                mainCamTransform = orbit.transform;
            }
            else if (Camera.main != null)
            {
                mainCamTransform = Camera.main.transform;
            }
        }
        
        StartCoroutine(StartTimer());
    }

    void Update()
    {
        if (mainCamTransform == null)
        {
            Debug.Log("yes camera null");
        }
        if(mainCamTransform != null)
        {
            Vector3 dir = mainCamTransform.transform.position - forrot.position;
            // dir.y = 0;
            forrot.forward = -dir;
        }
     
    }

    public void SetText(string message)
    {
        textUI.text = message;
        StartCoroutine(StartTimer());
        
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSecondsRealtime(7f);
        gameObject.SetActive(false);
    }

    
}
