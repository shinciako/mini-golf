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
        BallMovement.totalScore = 0;
    }
    public void GoToStartMenu(){
        SceneManager.LoadScene(0);
    }
}
