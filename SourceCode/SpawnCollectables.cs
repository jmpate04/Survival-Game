using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectables : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public int maxCollictible = 500;
    public static int currentCount;
    public bool respawn = true;

    void Start()
    {

        int i;
        for (i = 0; i < maxCollictible; i++)
        {
            Instantiate(prefab, new Vector3((float)Random.Range(-34, 34), (float)0.5, (float)Random.Range(-34, 34)), Quaternion.identity);
        }
        currentCount = maxCollictible;
    }

   
    void addCurrentCount()
    {
        currentCount = currentCount + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            if (currentCount < maxCollictible)
            {
                Instantiate(prefab, new Vector3((float)Random.Range(-34, 34), (float)0.5, (float)Random.Range(-34, 34)), Quaternion.identity);
                addCurrentCount();
            }
        }
    }
}
