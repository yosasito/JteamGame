using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ChaserScript : MonoBehaviour
{
    public Transform player;
    public float speed = 20f;
    public float speedUp = 1.1f;
    public float searchLength = 20f;

    public float bouncePower = 20f;

    private Vector3 moveDirection;
    public bool Chasing = false;

    private Rigidbody rb;

    public float rayLength = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChaserOff();  // �����_���ړ�
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //Debug.Log(distanceToPlayer);

        if (distance <= searchLength)//�߂Â�����
        {
            //Debug.Log("�Փ�");
            Chasing = true;
        }
        else
        {
            //Debug.Log("�Փ�");
            Chasing = false;
        }
        speedUp += 0.005f;
        rb.linearVelocity = moveDirection * (speed*speedUp);
    }
    private void OnCollisionEnter(Collision collision)//�Ǔ���������
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // �ǂ̖@���i�ŏ��ɓ��������ڐG�ʁj���擾
            Vector3 normal = collision.contacts[0].normal;

            // ���݂̈ړ�������ǂ̖@���Ŕ���
            moveDirection = Vector3.Reflect(moveDirection, normal).normalized;

            // ���ˌ�̕����ֈ�u�o�E���h������
            rb.MoveRotation(Quaternion.LookRotation(moveDirection));

            rb.AddForce(moveDirection * bouncePower, ForceMode.Impulse);

            if (Chasing)
            {
                ChaserOn(); // �ǐՃ��[�h
                Debug.Log("�ǐՃ��[�h");
                speedUp = 0f;//
            }
            else
            {
                ChaserOff(); // �p�j���[�h
                Debug.Log("�p�j���[�h");
                speedUp = 0f;//
            }
        }
    }
    void ChaserOn()//�ǐՃ��[�h
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
    void ChaserOff()// �p�j���[�h
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
            Vector3 rayOrigin = transform.position + Vector3.up * 0.5f;
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
            moveDirection = Quaternion.Euler(0, 90, 0) * moveDirection;//U�^�[��
            Debug.Log("trun");
        }

        rb.MoveRotation(Quaternion.LookRotation(moveDirection));
    
    }
}
