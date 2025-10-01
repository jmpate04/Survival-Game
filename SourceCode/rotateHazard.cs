using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateHazard : MonoBehaviour
{
   
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime);
    }
}
