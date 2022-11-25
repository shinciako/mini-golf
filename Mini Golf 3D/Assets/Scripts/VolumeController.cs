using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume")){
            PlayerPrefs.SetFloat("volume",1);
            load();
        }else load();
    }

    public void changeVolume(){
        AudioListener.volume = volumeSlider.value;
    }

    //Saving volume level from last activity
    private void save(){
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    private void load(){
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
}
