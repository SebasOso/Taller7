using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportxxxx : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            player.transform.position = new Vector3(21, 16.52f, -46);
        }
    }
}
