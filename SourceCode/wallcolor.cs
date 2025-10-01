using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcolor : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    // Start is called before the first frame update
    void Start()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        wall1.GetComponent<Renderer>().material.color = new Color(r, g, b);
        wall2.GetComponent<Renderer>().material.color = new Color(r, g, b);
        wall3.GetComponent<Renderer>().material.color = new Color(r, g, b);
        wall4.GetComponent<Renderer>().material.color = new Color(r, g, b);
    }


}
