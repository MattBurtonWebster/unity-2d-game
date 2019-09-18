using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpinner : MonoBehaviour
{
    public float speed;
    public bool isClockwise;
    public Transform pivot;

    private void Update()
    {
        if (isClockwise)
        {
            pivot.Rotate(Vector3.back * speed);
        }
        else
        {
            pivot.Rotate(Vector3.forward * speed);
        }
    }
}
