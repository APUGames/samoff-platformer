using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;

    [SerializeField] Text lives;
    [SerializeField] Text score;

    private void Start()
    {
        lives.text = playerLives.ToString();
        score.text = playerScore.ToString();
    }

    private void Awake()
    {
        // Will find the number of occurrence of this Game Object
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // GameSession object persists if there is less than 1
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            SubtractLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);

        Destroy(gameObject);
    }

    private void SubtractLife()
    {
        playerLives--;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lives.text = playerLives.ToString();
    }

    public void ProcessPlayerScore(int points)
    {
        playerScore += points;
        score.text = playerScore.ToString();
    }
}
