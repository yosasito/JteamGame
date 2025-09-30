using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed=15.0f;
    [SerializeField] float dash = 25f;
    [SerializeField] public float sutamina = 25f;

    Rigidbody rb;
    Vector3 move;

    public bool dead = false;

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

        if (Input.GetKey(KeyCode.Space))
        {
            if (sutamina > 0)
            {
                move = new Vector3(h, 0, v) * dash;
                Debug.Log("dash");
                sutamina -= 0.01f;
            }        
            else if (sutamina <= 0)
            {
                move = new Vector3(h, 0, v) * speed;
            }
        }

        else
        {
            move = new Vector3(h, 0, v) * speed;
            Debug.Log("walk");
            sutamina += 0.003f;
            if (sutamina >= 25f)
            {
                sutamina = 25f;
            }
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dead = true;
        }
    }
}
