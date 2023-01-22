using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float minPower;
    public float maxPower;
    private float power;
    public float minSpeed;
    private float speed;
   
    public bool hit;
    public bool loading;
    private int countH;
    public TextMeshProUGUI hitCounter;
    public Transform cameraVector;

    public LineRenderer line;
    public float maxLineLength;
    private float lineLength;
    private Vector3 lineParameters;
    private float lineLengthPrc;

    public float powerIncrement;
    public Vector3 ballPosition;
    public Vector3 speedBoostDirection;
    public float speedBoostPower;
    public static int totalScore;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hit = false;
        countH = 0;
        HitsCounter();
        line.gameObject.SetActive(false);
        power = minPower;
        lineLength = 1;
        ballPosition = rb.position;
    }
    public void HitsCounter()
    {
        totalScore += 1;
        hitCounter.text = "Hits: " + countH.ToString();
    }
    private void FixedUpdate()
    {
        if (hit == true)
        {
            StopTheBall();
        }
        Hitting();
    }

    private void StopTheBall()
    {
        speed = rb.velocity.magnitude;

        if (speed < minSpeed)
        {
            rb.AddForce(-rb.velocity);
            rb.velocity = Vector3.zero;
            hit = false;
            ballPosition = rb.position;
        }
    }

    private void Hitting()
    {
        if (Input.GetKey(KeyCode.Space) && hit == false)
        {
            line.gameObject.SetActive(true);
            lineParameters = new Vector3(0, 0, lineLength);
            line.SetPosition(1, lineParameters);
            loading = true;
            if (power < maxPower)
            {
                power += powerIncrement;
            }
            lineLengthPrc = power / maxPower;
            lineLength = lineLengthPrc * maxLineLength;
            
        }
        else if (!Input.GetKey(KeyCode.Space) && loading == true)
        { 

            loading = false;
            rb.AddForce(cameraVector.forward * power);
            hit = true;
            countH++;
            HitsCounter();
            line.gameObject.SetActive(false);
            power = minPower;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            //rb.position = ballPosition;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.constraints = RigidbodyConstraints.None;
            rb.position = ballPosition;
        }
        if (other.tag == "SpeedBoost")
        {
            speedBoostDirection = other.transform.forward;
            rb.AddForce(speedBoostDirection * speedBoostPower);
        }
        if (other.tag == ("Hole")){
            StartCoroutine(finishedHole());
        }
    }

    IEnumerator finishedHole(){ 
        yield return new WaitForSeconds(3);
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextScene>=5) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(nextScene);
    }
}

   