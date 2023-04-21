using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    private bool hasShownLoock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasShownLoock)
        {
            ShowLoock();
        }
    }
    private void ShowLoock()
    {
        if(UITutorialManager.Instance.welcomeHint.activeSelf == false)
        {
            UITutorialManager.Instance.LoockAround();   
            hasShownLoock = true;
        }
    }
}
