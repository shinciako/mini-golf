using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetInHole : MonoBehaviour
{
     private void OnTriggerEnter(Collider other){
        
        if (other.enabled && other.CompareTag("Player")){
            Debug.Log("Test");
            finishedHole();
        }
     }

    IEnumerator finishedHole(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
