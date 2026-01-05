using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMOver : MonoBehaviour
{
    private static BGMOver instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene" || scene.name == "Title" || scene.name == "map" || scene.name == "map2" || scene.name == "Finish" || scene.name == "Select")
        {
            audioSource.Stop();
        }
        else
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
