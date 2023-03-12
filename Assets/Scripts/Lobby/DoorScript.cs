using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform door;
    public Transform opendoor;
    public Transform closedoor;
    public float DoorSpeed = 1f;
    Vector3 targetPosition;
    float time;
    public bool desbloqueada = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = closedoor.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (desbloqueada && door.position != targetPosition)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, time);
            time += Time.deltaTime * DoorSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetPosition = opendoor.position;
            time = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetPosition = closedoor.position;
            time = 0;
        }
    }
}
