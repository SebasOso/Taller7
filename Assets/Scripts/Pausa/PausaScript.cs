using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PausaScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject JuegoUI;
    public Button resumen;

    public Button volumen;

    public Button salir;

    public Button atras;

    public Image Menu;
    public Image volumenTitulo;
    [SerializeField] private Slider barra=null;
   
    bool change;

    // Start is called before the first frame update
    void Start()
    {
        change = false;
        pauseMenu.SetActive(false);
        volumenTitulo.gameObject.SetActive(false);
        atras.gameObject.SetActive(false);
     barra.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(change==false)
            {
                pauseGame();
                
            }
            else
            {
                resumeGame();
               
            }
        }

        resumen.onClick.AddListener(resumeGame);
        volumen.onClick.AddListener(volumenEvent);
        atras.onClick.AddListener(atrasEvent);
        salir.onClick.AddListener(salirEvent);
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        change = true;
        JuegoUI.gameObject.SetActive(false);
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        change = false;
        JuegoUI.gameObject.SetActive(true);
    }

 public void volumenEvent()
    {
        Menu.gameObject.SetActive(false);
        atras.gameObject.SetActive(true);
        volumen.gameObject.SetActive(false);
        resumen.gameObject.SetActive(false);
        salir.gameObject.SetActive(false);
        volumenTitulo.gameObject.SetActive(true);
        barra.gameObject.SetActive(true);
       
    }

    public void atrasEvent()
    {
        Menu.gameObject.SetActive(true);
        atras.gameObject.SetActive(false);
        volumen.gameObject.SetActive(true);
        resumen.gameObject.SetActive(true);
        salir.gameObject.SetActive(true);
        volumenTitulo.gameObject.SetActive(false);
        barra.gameObject.SetActive(false);
     
    }


    public void salirEvent()
    {
        Application.Quit();
    }

  public void changeVolume()
    {
        AudioListener.volume = barra.value;
    }

    private void Load()
    {
        barra.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", barra.value);
    }
}
