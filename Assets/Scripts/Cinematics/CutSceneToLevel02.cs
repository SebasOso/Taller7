using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneToLevel02 : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    void Start()
    {
        player.loopPointReached += EndReached;
        player.Play();
    }
    private void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("LVL 2");
    }
    public void Skip()
    {
        SceneManager.LoadScene("LVL 2");
    }
}
