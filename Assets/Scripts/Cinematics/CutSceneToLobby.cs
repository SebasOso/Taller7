using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutSceneToLobby : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    void Start()
    {
        player.loopPointReached += EndReached;
        player.Play();
    }
    private void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("Lobby");
    }
}
