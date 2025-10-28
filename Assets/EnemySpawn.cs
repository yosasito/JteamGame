using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂�������̃^�O���m�F
        if (collision.gameObject.CompareTag("Test2"))
        {
            // �Փ˒n�_���擾
            Vector3 hitPos = collision.contacts[0].point;

            // �v���n�u�𐶐�
            Instantiate(prefab, hitPos, Quaternion.identity);

            // �������g���폜
            Destroy(this.gameObject);
        }
    }
}

