using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using Unity.VisualScripting;

public class ChaserScript : MonoBehaviour
{
    public Transform player;

    public float speed = 5f;
    public float speedUp = 1f;
    public float searchLength = 15f;

    public float rayLength = 2f;
    public float rayLengthforPlayer = 10f;

    public bool Chasing = false;

    public LayerMask playerMask;

    Rigidbody rb;
    Vector3 moveDirection;

    public float stuckTimer = 0f;
    [SerializeField] float stuckLimit = 0.5f; //スタック時間
    [SerializeField] GameObject warning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChaserOff();   // 開幕は徘徊
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);// プレイヤーと距離
        Chasing = distance <= searchLength;

        speedUp += 0.001f;

        bool hitWall = TouchWall();

        if (Chasing)
        {
            if (hitWall)
            {
                stuckTimer += Time.deltaTime; // スタックしたら徘徊モード
                if (stuckTimer >= stuckLimit)
                {
                    Debug.Log("スタック→追跡OFF");
                    Chasing = false;
                    ChaserOff();
                    stuckTimer = 0f;
                }
            }
            else
            {
                stuckTimer = 0f;
            }
        }

        // 壁前で方向転換
        if (hitWall)
        {
            speedUp = 1f;

            if (Chasing)
                ChaserOn();
            else
                ChaserOff();
        }

        rb.linearVelocity = moveDirection * (speed * speedUp);// 移動

        if (moveDirection != Vector3.zero)// 回転
            rb.MoveRotation(Quaternion.LookRotation(moveDirection));

        if (warning != null)
            warning.SetActive(Chasing);
    }

    bool TouchWall()// 壁の前まで行ったか
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        return Physics.Raycast(origin, moveDirection, rayLength, LayerMask.GetMask("Wall"));
    }

    void ChaserOn()
    {
        Vector3 origin = transform.position + Vector3.up * 0.2f;

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
            float playerCheckDistance = rayLengthforPlayer;

            Debug.DrawRay(origin, dir * playerCheckDistance * rayLength, Color.red, 0.1f);

            if (Physics.SphereCast(origin, 5f, dir, out RaycastHit hit, playerCheckDistance, playerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    moveDirection = dir;
                    Debug.Log("追跡方向：" + dir);
                    return;
                }
            }
        }
        speed = 25f;
    }

    void ChaserOff()//徘徊
    {
        speed = 18f;
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
