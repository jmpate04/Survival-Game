using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockchild : MonoBehaviour
{
    Quaternion iniRot;
    
    
    void Start()
    {
     
        
        iniRot = transform.rotation;
        
    }

    
    void Update()
    {
       
        transform.rotation = iniRot;
        //transform.rotation = Quaternion.Euler(rotationVector);
    }
}
