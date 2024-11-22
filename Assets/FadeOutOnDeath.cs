using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOnDeath : MonoBehaviour
{
    [SerializeField, Range(0.5f,2f)] private float fadeTime = 1f;
    public void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    private void OnDisable()
    {
        StopCoroutine(FadeOut());
    }
    public IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            canvasGroup.alpha = ft;
            yield return new WaitForSeconds(fadeTime * 0.025f);
            if (ft <= 0)
                this.enabled = false;
        }
    }
}
