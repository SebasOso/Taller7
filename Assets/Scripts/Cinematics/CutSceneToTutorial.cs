using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneToTutorial : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    void Start()
    {
        player.loopPointReached += EndReached;
        player.Play();
    }
    private void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Skip()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
