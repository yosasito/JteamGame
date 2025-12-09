using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeDelay : MonoBehaviour
{
    public float delay = 1.5f;
    void Start()
    {
        Invoke("Select", delay);
    }
    void Select()
    {
        SceneManager.LoadScene("Title");
    }
}