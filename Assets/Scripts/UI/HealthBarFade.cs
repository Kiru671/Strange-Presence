using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFade : MonoBehaviour
{
    [SerializeField, Range(0.125f,2f)] private float fadeInTime = 0.25f;
    [SerializeField, Range(0.125f,2f)] private float fadeOutTime = 0.5f;
    private bool hasFadedIn = false;
    public IEnumerator FadeOut()
    {
        Debug.Log("Fading out");
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / fadeOutTime;
            canvasGroup.alpha = Mathf.Clamp01(1f - normalizedTime);
            yield return null;
        }

        // Ensure we reach exactly 0
        canvasGroup.alpha = 0f; 
    }
    public IEnumerator FadeIn()
    {
        Debug.Log("Fading in");
        if (hasFadedIn) yield break;

        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / fadeInTime;
            canvasGroup.alpha = Mathf.Clamp01(normalizedTime);
            yield return null;
        }

        // Ensure we reach exactly 1
        canvasGroup.alpha = 1f;
        hasFadedIn = true;
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
    }
}
