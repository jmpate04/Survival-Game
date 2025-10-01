using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BotSpawn : MonoBehaviour
{
    public GameObject prefab;
    public static int maxBots;
    public TextMeshProUGUI playercountText;

    // Start is called before the first frame update
    void Start()
    {
        maxBots = 25;
        SetbotcountText();
        int i;
        for (i = 0; i<maxBots; i++)
        {

            Instantiate(prefab, new Vector3((float) Random.Range(-34, 34), (float)0.5, (float) Random.Range(-34, 34)), Quaternion.identity);
        }
       
    }

    void Update()
    {
        if(maxBots == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void SetbotcountText()
    {
        playercountText.text = "Enemies Alive: " + maxBots.ToString();
    }
}
