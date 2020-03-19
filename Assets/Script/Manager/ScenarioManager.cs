using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioManager : MonoBehaviour
{
    public string sceneToLoad;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Loaded");
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}
