using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private Vector2 angle = new Vector2 (90 * Mathf.Deg2Rad, 0);
    private new CameraOrbit camera;
    private Vector2 nearPlaneSize;

    public Transform follow;
    public float Maxdistance;
    public Vector2 sensitivity;
    [SerializeField] private float limitNegative;
    [SerializeField] private float limitPositive;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    void Update()
    {
        float hor = Input.GetAxis("Mouse X");

        if (hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * sensitivity.x;
        }

        float ver = Input.GetAxis("Mouse Y");

        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad * sensitivity.y;
            angle.y = Mathf.Clamp(angle.y, limitNegative * Mathf.Deg2Rad, limitPositive * Mathf.Deg2Rad);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = new Vector3(Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
           -Mathf.Sin(angle.x) * Mathf.Cos(angle.y));


        RaycastHit hit;
        float distance = Maxdistance;
        

       
            if (Physics.Raycast(follow.position, direction, out hit, Maxdistance))
            {
                distance = Mathf.Min ((hit.point - follow.position).magnitude, distance);
            }
        

        transform.position = follow.position + direction * Maxdistance;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }
}
