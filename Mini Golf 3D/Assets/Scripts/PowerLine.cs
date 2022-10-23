using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    public float speedX;
    public float speedY;
    private float Yrotation;
    private float Xrotation;
    public float maxRotationX;
    public float minRotationX;
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
        
        Xrotation = Mathf.Clamp(Xrotation, minRotationX, maxRotationX);
        Vector3 nextMove = new Vector3(Xrotation, Yrotation);
        currentMove = Vector3.SmoothDamp(currentMove, nextMove, ref camVeloviety, smoothTime);


        transform.localEulerAngles = currentMove;

        transform.position = ball.position - transform.forward * distance;

    }
}
