using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject prefab;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollided) return;
        // �Փ˂�������̃^�O���m�F
        if (collision.gameObject.tag == "Test1")
        {
            // �Փ˒n�_���擾
            Vector3 hitPos = collision.contacts[0].point;

            // �v���n�u�𐶐�
            Instantiate(prefab, hitPos, Quaternion.identity);
            hasCollided = true;
        }
    }
}
