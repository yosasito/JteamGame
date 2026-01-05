using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform cam;

    [SerializeField] float speed = 5f;
    [SerializeField] float dash = 10f;
    [SerializeField] public float sutamina = 25f;
    [SerializeField] float mutekiTime = 1.0f; // 無敵時間

    public float Hp = 10;
    public bool dead = false;
    bool healed = false;
    bool muteki = false;

    Rigidbody rb;
    Vector3 move;
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // カメラ基準の前後左右
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 camMove = forward * v + right * h;

        if (camMove.sqrMagnitude > 0.001f)
        {
            m_Rotation = Quaternion.LookRotation(camMove);
        }

        move = camMove.normalized;

        // ダッシュ
        if (Input.GetKey(KeyCode.Space))
        {
            if (sutamina > 0)
            {
                move *= dash;
                sutamina -= 0.015f;
            }
            else move *= speed;
        }
        else
        {
            move *= speed;
            sutamina += 0.001f;
            if (sutamina > 25f) sutamina = 25f;
        }
    }

    void FixedUpdate()
    {
        rb.MoveRotation(m_Rotation);
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (muteki) 
                return;

            Hp -= 1;
           // Debug.Log("体力= " + Hp);

            if (Hp == 0)
                dead = true;

            StartCoroutine(MutekiMode());
        }
    }
    public void Heal(int healP)
    {
        Hp += healP;
        //Debug.Log("体力 = " + Hp);
    }
    IEnumerator MutekiMode()
    {
        muteki = true;
        yield return new WaitForSeconds(mutekiTime);
        muteki = false;
    }
}
