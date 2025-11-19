using UnityEngine;
using System.Collections.Generic;

public class ChaserScript : MonoBehaviour
{
    public Transform player;

    public float speed = 5f;
    public float speedUp = 1f;
    public float searchLength = 15f;

    public float rayLength = 2f;
    public float rayLengthforPlayer = 10f;

    public bool Chasing = false;

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChaserOff();   // 開幕は徘徊
    }

    void Update()
    {
        // プレイヤーと距離
        float distance = Vector3.Distance(player.position, transform.position);
        Chasing = distance <= searchLength;

        speedUp += 0.001f;

        // 方向変化
        if (TouchWall())
        {
            speedUp = 1f;

            if (Chasing)
            {
                ChaserOn();
            }
            else 
                ChaserOff();
        }

        // 移動
        rb.linearVelocity = moveDirection * (speed * speedUp);

        // 回転
        if (moveDirection != Vector3.zero)
            rb.MoveRotation(Quaternion.LookRotation(moveDirection));
    }

    // 壁の前まで行ったか
    bool TouchWall()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        return Physics.Raycast(origin, moveDirection, rayLength, LayerMask.GetMask("Wall"));
    }

    void ChaserOn()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;

        // 4方向
        Vector3[] dirs =
        {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right
        };

        foreach (var dir in dirs)
        {
            // 4方向にレイを飛ばす（壁判定とは別）
            if (Physics.Raycast(origin, dir, out RaycastHit hit, rayLength * rayLengthforPlayer))
            {
                if (hit.collider.CompareTag("Player")) // プレイヤーに当たった方向へ移動
                {
                    moveDirection = dir;
                    Debug.Log("追跡方向：" + dir);
                    return;
                }
            }
        }
    }


    void ChaserOff()//徘徊
    {
        Vector3[] dirs =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        List<Vector3> validDir = new List<Vector3>();

        foreach (var dir in dirs)
        {
            Vector3 origin = transform.position + Vector3.up * 0.5f;
            if (!Physics.Raycast(origin, dir, rayLength, LayerMask.GetMask("Wall")))
            {
                validDir.Add(dir);
            }
        }

        if (validDir.Count > 0)
            moveDirection = validDir[Random.Range(0, validDir.Count)];
        else
            moveDirection = -moveDirection;

        speed *= 0.6f;
    }
}
