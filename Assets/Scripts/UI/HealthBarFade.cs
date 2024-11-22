using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFade : MonoBehaviour
{
    [SerializeField, Range(0.5f,2f)] private float fadeTime = 1f;
    /*public void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    private void OnDisable()
    {
        StopCoroutine(FadeOut());
    }*/
    public IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            canvasGroup.alpha = ft;
            yield return new WaitForSeconds(fadeTime * 0.025f);
            if (ft <= 0) 
                StopCoroutine(FadeOut());
                
        }
    }
    public IEnumerator FadeIn()
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        for (float ft = 0; ft <= 1; ft += 0.1f)
        {
            canvasGroup.alpha = ft;
            yield return new WaitForSeconds(fadeTime * 0.025f);
            if (ft >= 1)
                StopCoroutine(FadeIn());
        }
    }
}
