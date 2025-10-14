using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ChaserScript : MonoBehaviour
{
    public Transform player;
    public float speed = 6f;
    public float speedUp = 1.1f;
    public float searchLength = 10f;

    private Vector3 moveDirection;
    public bool Chasing = false;

    private Rigidbody rb;

    public float rayLength = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChaserOff();  // ランダム移動
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //Debug.Log(distanceToPlayer);

        if (distance <= searchLength)//近づいたら
        {
            //Debug.Log("衝突");
            Chasing = true;
        }
        else
        {
            //Debug.Log("衝突");
            Chasing = false;
        }
        speedUp += 0.005f;
        rb.linearVelocity = moveDirection * (speed*speedUp);
    }
    private void OnCollisionEnter(Collision collision)//壁当たったら
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Chasing)
            {
                ChaserOn(); // 追跡モード
                Debug.Log("追跡モード");
                speedUp = 0f;//
            }
            else
            {
                ChaserOff(); // 徘徊モード
                Debug.Log("徘徊モード");
                speedUp = 0f;//
            }
        }
    }
    void ChaserOn()//追跡モード
    {
        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0;

        Vector3[] direction = {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        Vector3 bestMove = direction[0];
        float maxDot = Vector3.Dot(toPlayer.normalized, bestMove);

        foreach (var dir in direction)
        {
            float dot = Vector3.Dot(toPlayer.normalized, dir);
            if (dot > maxDot)
            {
                maxDot = dot;
                bestMove = dir;
            }
        }
        moveDirection = bestMove.normalized;
        //transform.forward = moveDirection;

        rb.MoveRotation(Quaternion.LookRotation(moveDirection));
    }
    void ChaserOff()// 徘徊モード
    {
        Vector3[] direction = {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };
        //moveDirection = direction[Random.Range(0, direction.Length)];

        //transform.forward = moveDirection;

        List<Vector3> DirectionList = new List<Vector3>();

        foreach(var dir in direction)
        {
            Ray ray = new Ray(transform.position, dir);
            if (!Physics.Raycast(ray, rayLength, LayerMask.GetMask("Wall")))
            {
                DirectionList.Add(dir);
            }
            Debug.DrawRay(transform.position, dir, Color.blue, rayLength);
        }
        if (DirectionList.Count > 0)
        {
            moveDirection = DirectionList[Random.Range(0, DirectionList.Count)];
           // Debug.Log(moveDirection);
        }
        else
        {
            moveDirection = -moveDirection;//Uターン
            Debug.Log("trun");
        }

        rb.MoveRotation(Quaternion.LookRotation(moveDirection));
    
    }
}
