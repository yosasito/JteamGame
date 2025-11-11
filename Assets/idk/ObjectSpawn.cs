using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject prefab;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollided) return;
        // 衝突した相手のタグを確認
        if (collision.gameObject.tag == "Test1")
        {
            // 衝突地点を取得
            Vector3 hitPos = collision.contacts[0].point;

            // プレハブを生成
            Instantiate(prefab, hitPos, Quaternion.identity);
            hasCollided = true;
        }
    }
}
