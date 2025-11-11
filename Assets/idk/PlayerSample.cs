using UnityEngine;

public class PlayerSample : MonoBehaviour
{
    [SerializeField] private int targetCount = 3; // 必要なキー数
    private int currentCount = 0; // 現在の取得数

    private void OnCollisionEnter(Collision collision)
    {
        // Keyタグのオブジェクトにぶつかったら
        if (collision.gameObject.CompareTag("Key"))
        {
            CollectItem(collision.gameObject);
        }
    }

    private void CollectItem(GameObject item)
    {
        currentCount++;

        // アイテムを消す（触ったキーを削除）
        Destroy(item);

        Debug.Log("キーを" + currentCount + "個集めた！");

        // 必要数に達したらタグを変更
        if (currentCount >= targetCount)
        {
            this.tag = "KeyHave";
            Debug.Log("タグがKeyHaveに変わった！");
        }
    }
}

