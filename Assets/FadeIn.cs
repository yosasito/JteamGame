using System.Collections;
using UnityEngine;

public class ImageFadeIn : MonoBehaviour
{
    [SerializeField] private float fadeTime = 4f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        gameObject.SetActive(true);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeTime);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}