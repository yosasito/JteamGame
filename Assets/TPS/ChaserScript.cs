using UnityEngine;
using System.Collections.Generic;

public class ChaserScript : MonoBehaviour
{
    public Transform player;

    public float speed = 5f;
    public float speedUp = 1f;
    public float searchLength = 15f;

    public float rayLength = 2f;

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
        // 鬼とプレイヤーの距離
        float distance = Vector3.Distance(player.position, transform.position);
        Chasing = distance <= searchLength;

        speedUp += 0.001f;

        // ★ 正面が壁なら方向転換
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

    // ★ プレイヤー方向へ向く
    void ChaserOn()
    {
        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0;

        Vector3 bestDir = Vector3.zero;
        float bestDot = -999f;

        Vector3[] dirs =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        foreach (var dir in dirs)
        {
            // チェック
            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, rayLength, LayerMask.GetMask("Wall")))
                continue;

            float dot = Vector3.Dot(dir, toPlayer.normalized);
            if (dot > bestDot)
            {
                bestDot = dot;
                bestDir = dir;
            }
        }

        if (bestDir != Vector3.zero)
            moveDirection = bestDir;
        else
            moveDirection = -moveDirection; // 反射
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
    }
}
