using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが "Test2" なら削除
        if (collision.gameObject.CompareTag("Test2"))
        {
            Destroy(this.gameObject);
            Debug.Log("Test2を削除しました！");
        }
    }
}
