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

    public LayerMask playerMask;

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChaserOff();   // äJñãÇÕúpúj
    }

    void Update()
    {
        // ÉvÉåÉCÉÑÅ[Ç∆ãóó£
        float distance = Vector3.Distance(player.position, transform.position);
        Chasing = distance <= searchLength;

        speedUp += 0.001f;

        // ï˚å¸ïœâª
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

        // à⁄ìÆ
        rb.linearVelocity = moveDirection * (speed * speedUp);

        // âÒì]
        if (moveDirection != Vector3.zero)
            rb.MoveRotation(Quaternion.LookRotation(moveDirection));
    }

    // ï«ÇÃëOÇ‹Ç≈çsÇ¡ÇΩÇ©
    bool TouchWall()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        return Physics.Raycast(origin, moveDirection, rayLength, LayerMask.GetMask("Wall"));
    }

    void ChaserOn()
    {
        Vector3 origin = transform.position + Vector3.up * 0.2f;

        // 4ï˚å¸
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

            if (Physics.SphereCast(origin, 5f, dir, out RaycastHit hit, playerCheckDistance * rayLength, playerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    moveDirection = dir;
                    Debug.Log("í«ê’ï˚å¸ÅF" + dir);
                    return;
                }
            }
        }
    }


    void ChaserOff()//úpúj
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
