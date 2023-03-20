using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // We need to make this method public because the Button needs to access it.
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }

}
