using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hit = false;
        countH = 0;
        HitsCounter();
        line.gameObject.SetActive(false);
        power = minPower;
        lineLength = 1;
    }
    public void HitsCounter()
    {
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
            rb.velocity = new Vector3(0, 0, 0);
            hit = false;
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
                power += 5;
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
}

   