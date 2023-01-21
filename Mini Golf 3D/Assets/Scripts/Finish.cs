using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
    public TextMeshProUGUI totalPoints;

    void Start(){
        int receivedPoints = BallMovement.totalScore;
        totalPoints.text = receivedPoints.ToString();
    }
    public void GoToStartMenu(){
        SceneManager.LoadScene(0);
    }
}
