using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O�� "Test2" �Ȃ�폜
        if (collision.gameObject.CompareTag("Test2"))
        {
            Destroy(this.gameObject);
            Debug.Log("Test2���폜���܂����I");
        }
    }
}
