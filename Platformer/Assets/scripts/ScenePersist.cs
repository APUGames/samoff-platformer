using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{

    int startSceneIndex;

    private void Awake()
    {
        // Will find the number of occurrence of this Game Object
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;

        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // GameSession object persists if there is less than 1
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        startSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex != startSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
