using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoader : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Select");
    }
}

