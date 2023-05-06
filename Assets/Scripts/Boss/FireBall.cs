using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float timekeeper;
    [SerializeField] private float velocity = 6.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        transform.localScale += new Vector3(3, 3, 3) * Time.deltaTime;
        timekeeper += 1 * Time.deltaTime;
        if (timekeeper > 1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            timekeeper = 0; 
        }
    }
}
