using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutSceneToLevel01 : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    void Start()
    {
        player.loopPointReached += EndReached;
        player.Play();
    }
    private void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("Level01");
    }
    public void Skip()
    {
        SceneManager.LoadScene("Level01");
    }
}
