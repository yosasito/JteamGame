using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using Unity.VisualScripting;

public class ChaserScript : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 5f;
    public float chaseSpeed = 5f;
    public float speedUp = 1f;
    public float searchLength = 15f;

    public float rayLength = 2f;
    public float rayLengthPlayer = 10f;

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
        PickRandomDirection();   // 開幕は徘徊
    }

    // Update is called once per frame
    void Update()
    {
        SearchPlayer();

        //if (warning != null)
            warning.SetActive(Chasing);
    }

    void FixedUpdate()
    {
        speedUp += Time.fixedDeltaTime * 0.2f;

        bool hitWall = TouchWall();

        // ★ 壁に当たった瞬間だけ方向決定
        if (hitWall)
        {
            speedUp = 1f;

            if (Chasing)
                DecideChaseDirection();
            else
                PickRandomDirection();
        }

        float speed = Chasing ? chaseSpeed : moveSpeed;

        rb.linearVelocity = moveDirection * speed * speedUp;
        rb.MoveRotation(Quaternion.LookRotation(moveDirection));
    }

    // =============================

    void SearchPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) > searchLength)
            return;

        Vector3 origin = transform.position + Vector3.up * 0.5f;

        Vector3[] dirs =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        foreach (var dir in dirs)
        {
            if (Physics.SphereCast(origin, 1.5f, dir,
                out RaycastHit hit, rayLengthPlayer, playerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Chasing = true;
                    return;
                }
            }
        }
    }

    bool TouchWall()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        return Physics.SphereCast(origin, 0.4f, moveDirection,
            out _, rayLength, LayerMask.GetMask("Wall"));
    }

    // =============================

    void DecideChaseDirection()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;

        Vector3[] dirs =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        foreach (var dir in dirs)
        {
            // 壁方向は除外
            if (Physics.Raycast(origin, dir, rayLength, LayerMask.GetMask("Wall")))
                continue;

            if (Physics.SphereCast(origin, 1.5f, dir,
                out RaycastHit hit, rayLengthPlayer, playerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    if (Chasing)
                    {
                        Debug.Log("追跡開始！");
                    }

                    moveDirection = dir;
                    return;
                }
            }
        }

        // 見失ったら追跡解除
        Chasing = false;
        PickRandomDirection();
    }

    void PickRandomDirection()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;

        Vector3[] dirs =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        List<Vector3> valid = new();

        foreach (var dir in dirs)
        {
            if (!Physics.Raycast(origin, dir, rayLength, LayerMask.GetMask("Wall")))
                valid.Add(dir);
        }

        moveDirection = valid.Count > 0
            ? valid[Random.Range(0, valid.Count)]
            : transform.forward;
    }
}