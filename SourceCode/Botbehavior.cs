using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Botbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public int score;
    public TextMesh scoreview;
    public float forcevalue;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreview();

    }
    void SetScoreview()
    {
        scoreview.text = score.ToString();
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Random.Range(-forcevalue, forcevalue), 0.0f, Random.Range(-forcevalue, forcevalue));

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 10;
            SetScoreview();
            SpawnCollectables.currentCount--;
            
          
            transform.localScale += new Vector3(0.020f, 0.020f, 0.020f);
            rb.mass = rb.mass + 0.015f;

        }
    }
    
    private void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
           
            GameObject opponent = other.gameObject;
            PlayerController playerScript = opponent.GetComponent<PlayerController>();
            int opponentScore = playerScript.score;


            if (opponentScore < score)
            {
                score = score + opponentScore;
                SetScoreview();
                transform.localScale += new Vector3(opponentScore * 0.020f / 10f, opponentScore * 0.020f / 10f, opponentScore * 0.020f / 10f);
                rb.mass = rb.mass + 0.015f * opponentScore / 10f;
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
        }

        else if(other.gameObject.CompareTag("Bot"))
        {
            GameObject opponent = other.gameObject;
            Botbehavior playerScript = opponent.GetComponent<Botbehavior>();
            int opponentScore = playerScript.score;


            if (opponentScore < score)
            {
                score = score + opponentScore;
                SetScoreview();
                transform.localScale += new Vector3(opponentScore * 0.020f / 10f, opponentScore * 0.020f / 10f, opponentScore * 0.020f / 10f);
                rb.mass = rb.mass + 0.015f * opponentScore / 10f;
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);

                BotSpawn.maxBots = BotSpawn.maxBots - 1;
                FindObjectOfType<BotSpawn>().SetbotcountText();
                
            }
        }
    }
    
}
