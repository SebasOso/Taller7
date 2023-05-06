using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingObject : MonoBehaviour
{
    public float timekeeper;
    [SerializeField] private float velocity;

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
        timekeeper += 1 * Time.deltaTime;
        if (timekeeper > 3)
        {
            gameObject.SetActive(false);
            timekeeper = 0;
        }
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
