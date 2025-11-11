using UnityEngine;

public class PlayerSample : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            this.tag = "KeyHave";
        }
    }
}