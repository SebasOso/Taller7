using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void LoadTutorial()
    {
        SceneManager.LoadScene("IntroCinematic");
    }
}
