using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformavaria : MonoBehaviour
{
    [SerializeField] private float caidaen = 1f;
    [SerializeField] private float destruccion = 2f;
    [SerializeField] private float reaparicion = 2f;
    private Rigidbody rb;
    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        posicion = this.gameObject.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida());
        }
    }
    private IEnumerator Caida()
    {
        yield return new WaitForSeconds(caidaen);
        rb.useGravity = enabled;
        rb.isKinematic = false;
        yield return new WaitForSeconds(destruccion);
        this.gameObject.SetActive(false);
        Invoke("Regeneracion", reaparicion);
    }

    private void Regeneracion()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = posicion;
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
