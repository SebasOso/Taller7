using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerobjetoscaibles : MonoBehaviour
{
    public GameObject objetoPrefab;
    public int cantidadMaxima = 3;
    public float radioAparicion = 10;
    private List<GameObject> objetosCreados = new List<GameObject>();
    private float anchoArea;
    private float altoArea;
    public float rangodeteccion = 40;
    Collider[] objetosDentro;
    Vector3 tamano;
    Vector3 centro;
    public float tiemposalida = 1;
    bool boolcambio = false;
    bool boolsalida = false;
    private GameObject[] objetosactivos;
    public float tiempoDerecarga=1;


    private void Start()
    {
        anchoArea = this.transform.localScale.x;
        altoArea = this.transform.localScale.z;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(objetosCreados.Count.ToString());
            Debug.Log(objetosactivos.Length.ToString());
        }
        centro = this.transform.position;
        tamano = new Vector3(anchoArea * rangodeteccion, 100, altoArea * rangodeteccion);
        objetosDentro = Physics.OverlapBox(centro, tamano, Quaternion.identity);

        if (boolsalida == false)
        {
            StartCoroutine(tiempoEntreSalida());
            boolsalida = true;
        }
        StartCoroutine(recarga());





    }

    public IEnumerator tiempoEntreSalida()
    {
        yield return new WaitForSeconds(tiemposalida);

        foreach (Collider objeto in objetosDentro)
        {

            if (objeto != null)
            {

                if (objeto.gameObject.tag == "Player")
                {
                    //LifeSystem.Instance.HurtPlayer(1);

                    if (objetosCreados.Count < cantidadMaxima)
                    {
                        yield return new WaitForSeconds(tiemposalida);

                        Vector3 posicion = this.transform.position;


                        GameObject nuevoObjeto = Instantiate(objetoPrefab, posicion, Quaternion.identity);


                        objetosCreados.Add(nuevoObjeto);

                    }

                }


            }

        }
      
        boolsalida = false;
    }


    public IEnumerator recarga()
    {
        yield return new WaitForSeconds(tiempoDerecarga);
        objetosCreados.Clear();
    }
}



