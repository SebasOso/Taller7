using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerobjetoscaibles : MonoBehaviour
{
    public GameObject objetoPrefab;
    public int cantidadMaxima = 1;
    public float radioAparicion = 10;
    private List<GameObject> objetosCreados = new List<GameObject>();
    private float anchoArea;
    private float altoArea;
    public float rangodeteccion = 2;
    Collider[] objetosDentro;
    Vector3 tamano;
    Vector3 centro;
    public float tiemposalida = 1;
    bool boolcambio=false;
    bool boolsalida=false;
    private GameObject[] objetosactivos;


    private void Start()
    {
        anchoArea = this.transform.localScale.x;
        altoArea = this.transform.localScale.z;
    }
    void Update()
    {
        centro = this.transform.position;
        tamano = new Vector3(anchoArea * rangodeteccion, 200, altoArea * rangodeteccion);
        objetosDentro = Physics.OverlapBox(centro, tamano, Quaternion.identity);

        if (boolsalida == false)
        {
            StartCoroutine(tiempoEntreSalida());
            boolsalida = true;
        }
        if (boolcambio == false)
        {
            StartCoroutine(tiempocambio());
            boolcambio = true;
        }

    }

    public IEnumerator tiempoEntreSalida()
    {
        yield return new WaitForSeconds(4);

        foreach (Collider objeto in objetosDentro)

            if (objeto != null)
            {

                if (objeto.gameObject.tag == "Player")
                {


                    if (objetosCreados.Count < cantidadMaxima)
                    {
                        yield return new WaitForSeconds(tiemposalida);
                        Debug.Log("trigger");
                        Vector3 posicion = transform.position + Random.insideUnitSphere * radioAparicion;


                        GameObject nuevoObjeto = Instantiate(objetoPrefab, posicion, Quaternion.identity);


                        objetosCreados.Add(nuevoObjeto);
                       
                    }
                    
                }
                
            }
        boolsalida = false;
        }

    
    public IEnumerator tiempocambio()
    {
        objetosactivos = GameObject.FindGameObjectsWithTag("caido");
        if (objetosactivos.Length == 0)
        {
            objetosCreados.Clear();
        }
        boolcambio = false;
        yield return new WaitForSeconds(1);
    }
}



