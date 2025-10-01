using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject player;

  
    void LateUpdate()
    {
        if (player)
        {
            transform.position = player.transform.position + new Vector3(0.0f, 15f + player.transform.localScale.x * 5f, 0.0f);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}

