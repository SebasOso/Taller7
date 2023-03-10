using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] private float retreat_distance;
    [SerializeField] private float stop_distance;
    [SerializeField] private float speed;
    [SerializeField] private float limitY;
    private Transform player;      
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stop_distance )
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stop_distance && Vector3.Distance(transform.position, player.position) > retreat_distance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) <= retreat_distance)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, -speed * Time.deltaTime);
        }
    }
}
