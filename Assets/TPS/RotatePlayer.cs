using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 20f;

    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);//ï˚å¸

        if (m_Movement != Vector3.zero)
        {
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
            transform.rotation = m_Rotation;
        }

        // ëOêiï˚å¸Ç÷ÇÃà⁄ìÆ
        Vector3 forwardMovement = transform.forward * m_Movement.magnitude * speed * Time.deltaTime;
        transform.Translate(forwardMovement, Space.World);
    }
}
