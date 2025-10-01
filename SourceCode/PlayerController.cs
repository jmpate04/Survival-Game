using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //public GameObject MainCamera;
    public float speed;
  
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreDisp;
    private Rigidbody rb;
    public int score;
    private float movementX;
    private float movementY;
    
    //private Vector3 increase;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        SetScoreDisp();
        //increase = transform.localScale;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetScoreDisp()
    {
        scoreDisp.text = score.ToString();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            score = score + 10;
            SetScoreText();
            SetScoreDisp();
            SpawnCollectables.currentCount--;
            //increase += new Vector3(0.025f, 0.025f, 0.025f); 
           // Vector3 desiredsize = transform.localScale + new Vector3(0.025f, 0.025f, 0.025f);
           // Vector3 smoothsize = Vector3.Lerp(transform.localScale, increase, 0.005f);
            //transform.localScale = smoothsize;
            transform.localScale += new Vector3(0.020f, 0.020f, 0.020f);
            rb.mass = rb.mass + 0.015f;

        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            GameObject opponent = other.gameObject;
            Botbehavior playerScript = opponent.GetComponent<Botbehavior>();
            int opponentScore = playerScript.score;

            if (opponentScore < score)
            {
                score = score + opponentScore;
                SetScoreText();
                SetScoreDisp();
                transform.localScale += new Vector3(opponentScore * 0.020f / 10f, opponentScore * 0.020f / 10f, opponentScore * 0.020f / 10f);
                rb.mass = rb.mass + 0.015f * opponentScore / 10f;
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
                BotSpawn.maxBots = BotSpawn.maxBots - 1;
                FindObjectOfType<BotSpawn>().SetbotcountText();

            }
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }

}

