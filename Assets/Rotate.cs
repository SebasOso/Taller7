using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Velocidad de rotación, puedes ajustarla en el Inspector
    public GameObject objectTo;
    void Update()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        objectTo.GetComponent<Transform>().Rotate(Vector3.up, rotationAngle);
    }
}
