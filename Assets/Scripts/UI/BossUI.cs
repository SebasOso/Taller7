using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    [SerializeField] private GameObject bossUI;   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Configurations.Instance.isPaused == true)
        {
            bossUI.SetActive(false);
        }
        else
        {
            bossUI.SetActive(true);
        }
    }
}
