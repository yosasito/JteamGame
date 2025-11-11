using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLoader : MonoBehaviour
{ 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}


