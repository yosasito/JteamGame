using UnityEngine;

public class GetTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O�� "Test2" �Ȃ�폜
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Key���폜���܂����I");
        }
    }
}