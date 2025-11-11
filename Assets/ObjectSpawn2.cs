using UnityEngine;

public class ObjectSpawn2 : MonoBehaviour
{
    public GameObject prefab;
    public float offset = 0.1f; // ← めり込み防止の距離
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollided) return;

        if (collision.gameObject.CompareTag("Test1"))
        {
            // 衝突情報を取得
            ContactPoint contact = collision.contacts[0];

            // 衝突位置＋法線方向に少しずらす
            Vector3 spawnPos = contact.point + contact.normal * offset;

            // プレハブ生成
            Instantiate(prefab, spawnPos, Quaternion.identity);

            hasCollided = true;
        }
    }
}

