using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource music;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Volume()
    {
        AudioListener.volume = soundSlider.value;   
    }
    public void MusicVolume()
    {
        music.volume = musicSlider.value;   
    }

    public void LoadData(GameData data)
    {
        musicSlider.value = data.musicVolume;
        soundSlider.value = data.soundVolume;
    }

    public void SaveData(GameData data)
    {
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
    }
}
