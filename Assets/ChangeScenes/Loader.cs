using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private string loadScene;
    [SerializeField] private GameObject FedeIn;
    [SerializeField] private float fadeTime = 4f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = FedeIn.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        FedeIn.SetActive(true);
    }

    // Åö É{É^ÉìÇ©ÇÁåƒÇ‘ÇÃÇÕÇ±ÇÍÇæÇØ
    public void StartLoad()
    {
        StartCoroutine(FadeInAndLoad());
    }

    IEnumerator FadeInAndLoad()
    {
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeTime);
            yield return null;
        }

        SceneManager.LoadScene(loadScene);
    }
}