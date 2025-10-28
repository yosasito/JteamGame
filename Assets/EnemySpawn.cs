using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手のタグを確認
        if (collision.gameObject.CompareTag("Test2"))
        {
            // 衝突地点を取得
            Vector3 hitPos = collision.contacts[0].point;

            // プレハブを生成
            Instantiate(prefab, hitPos, Quaternion.identity);

            // 自分自身を削除
            Destroy(this.gameObject);
        }
    }
}

