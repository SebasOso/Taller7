using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{

    public Image image;
    public float max_time=7.0f;
    float time_remining;

    // Start is called before the first frame update
    void Start()
    {
        time_remining = max_time;
    }

    // Update is called once per frame
    void Update()
    {
        if(time_remining>0)
        {
            time_remining -= Time.deltaTime;
            image.fillAmount = time_remining / max_time;
        }
    }
}
