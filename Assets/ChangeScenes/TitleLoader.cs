using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoader : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
    }
}