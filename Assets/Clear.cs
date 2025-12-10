using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ぶつかった相手: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goalタグを検出！");
            SceneManager.LoadScene("Finish");
        }
    }
}
