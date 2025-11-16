using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 15.0f;
    [SerializeField] float dash = 25f;
    [SerializeField] public float sutamina = 25f;

    public bool dead = false;

    Rigidbody rb;
    Vector3 move;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        move = new Vector3(h, 0, v);

        // 回転
        if (move.sqrMagnitude > 0.001f)
        {
            m_Rotation = Quaternion.LookRotation(move);
        }
        // ダッシュ
        if (Input.GetKey(KeyCode.Space))
        {
            if (sutamina > 0)
            {
                move *= dash;
                sutamina -= 0.015f;
            }
            else
            {
                move *= speed;
            }
        }
        else
        {
            move *= speed;
            sutamina += 0.003f;
            if (sutamina >= 25f)
            {
                sutamina = 25f;
            }
        }
    }
    void FixedUpdate()
    {
        // 回転を適用
        rb.MoveRotation(m_Rotation);
        // 速度を直接適用
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dead = true;
        }
    }
}