using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 20f;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Update()
    {
        // ��Input System���g�p���ē��͎擾
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ���̓x�N�g�����쐬
        m_Movement.Set(horizontal, 0f, vertical);

        // ���͂�����ꍇ�̂݉�]���X�V
        if (m_Movement != Vector3.zero)
        {
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
            transform.rotation = m_Rotation;
        }

        // �O�i�����ւ̈ړ�
        Vector3 forwardMovement = transform.forward * m_Movement.magnitude * speed * Time.deltaTime;
        transform.Translate(forwardMovement, Space.World);
    }
}
