using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                resume();
            }else{
                stopMenu();
            }
        }
    }

    public void resume(){
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void stopMenu(){
        menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void goMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
