using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLoader : MonoBehaviour
{
    public float waitTime = 1.5f;

    public void OnClickStartButton()
    {
        Debug.Log("Button clicked");
        Invoke(nameof(LoadScene), waitTime);
    }

    void LoadScene()
    {
        Debug.Log("LoadScene called");
        SceneManager.LoadScene("SampleScene");
    }
}