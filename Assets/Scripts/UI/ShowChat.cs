
using UnityEngine;
using System.Collections;

using TMPro;
using System;

public class ShowChat : MonoBehaviour
{
    [SerializeField] public TMP_Text textUI;
    public Transform forrot;
    public Transform cameraa;
    OrbitCamera cam;

    void OnEnable()
    {
        PlayerMovement.SetCamera += SetCameraa;
    }

    void OnDisable()
    {
        PlayerMovement.SetCamera -= SetCameraa;
    } 

    void Update()
    {
        if(cam != null)
        {
            Vector3 dir = cam.transform.position - forrot.position;
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

    public void SetCameraa(OrbitCamera cmm)
    {
        cam = cmm;
    }

}
