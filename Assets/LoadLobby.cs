using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLobby : MonoBehaviour
{
    public void LoadLoby()
    {
        SceneManager.LoadScene("IntroCinematic");
    }
}
