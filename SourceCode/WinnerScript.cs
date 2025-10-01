using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScript : MonoBehaviour
{
    public void pA()
    {
        SceneManager.LoadScene(1);
    }

    public void qG()
    {

        Application.Quit();
    }
}
