using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("ぶつかった相手: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("KeyHave"))
        {
            Debug.Log("KeyHaveタグを検出！");
            SceneManager.LoadScene("Finish");
        }
    }
}
