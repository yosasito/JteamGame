using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Test2")
        {
            Destroy(this.gameObject);
        }
    }
}

