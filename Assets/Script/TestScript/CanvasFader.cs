using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFader : MonoBehaviour
{
    public CanvasGroup UIFade;

    public void FadeOut()
    {
        StartCoroutine(FadeCanvas(UIFade, UIFade.alpha, 0));
    }
    public void FadeIn()
    {
        StartCoroutine(FadeCanvas(UIFade, UIFade.alpha, 1));
    }

    public IEnumerator FadeCanvas(CanvasGroup canvasGroup, float start, float end, float lerpTime = 2f)
    {
        float timeStartLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartLerping;
        float percentgeComplete = timeSinceStarted / lerpTime;

        while (percentgeComplete < 1)
        {
            timeSinceStarted = Time.time - timeStartLerping;
            percentgeComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentgeComplete);

            canvasGroup.alpha = currentValue;

            //if (percentgeComplete >= 1) break;

            yield return new WaitForEndOfFrame(); 
        }
    }
}
