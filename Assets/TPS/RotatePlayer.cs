using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 20f;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Update()
    {
        // 旧Input Systemを使用して入力取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 入力ベクトルを作成
        m_Movement.Set(horizontal, 0f, vertical);

        // 入力がある場合のみ回転を更新
        if (m_Movement != Vector3.zero)
        {
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
            transform.rotation = m_Rotation;
        }

        // 前進方向への移動
        Vector3 forwardMovement = transform.forward * m_Movement.magnitude * speed * Time.deltaTime;
        transform.Translate(forwardMovement, Space.World);
    }
}
