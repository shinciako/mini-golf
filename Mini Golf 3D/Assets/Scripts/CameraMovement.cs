using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedX;
    public float speedY;
    private float Yrotation;
    private float Xrotation;
    public float maxRotationX;
    public float minRotationX;
    public float maxZoom;
    public float minZoom;
    public Transform ball;
    public float distance;
    public float smoothTime;
    private Vector3 currentMove;
    private Vector3 camVeloviety = Vector3.zero;
   
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * speedX;
        float mouseY = Input.GetAxis("Mouse Y") * speedY;


        

        Yrotation = Yrotation + mouseX;
        Xrotation = Xrotation + mouseY;
        //calmp jest jak if ¿eby kamera nie wchodzi³a pod mapê (ogranicza mo¿liwe wartoœci)
        Xrotation = Mathf.Clamp(Xrotation, minRotationX, maxRotationX);
        distance = Mathf.Clamp(distance, minZoom, maxZoom);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            distance -= 0.1f;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            distance += 0.1f;
        }
        Vector3 nextMove = new Vector3(Xrotation, Yrotation);
        currentMove = Vector3.SmoothDamp(currentMove, nextMove,ref camVeloviety,smoothTime);
        
        
        transform.localEulerAngles = currentMove;

        transform.position = ball.position - transform.forward * distance;
        
    }
}