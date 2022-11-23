using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision colission)
    {
        if (colission.gameObject.name == "Ball")
        {
            colission.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision colission)
    {
        if (colission.gameObject.name == "Ball")
        {
            colission.gameObject.transform.SetParent(null);
        }
    }
}
