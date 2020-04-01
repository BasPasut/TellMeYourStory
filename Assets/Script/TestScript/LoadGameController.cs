using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadToGameplay());
    }

    IEnumerator LoadToGameplay()
    {
        AsyncOperation gameplay = SceneManager.LoadSceneAsync(3);
        yield return new WaitForEndOfFrame();
    }
}
