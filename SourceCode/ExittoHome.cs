using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExittoHome : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene(2);
    }

    public void restartgame()
    {
        SceneManager.LoadScene(1);
    }
}
