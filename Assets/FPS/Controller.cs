using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseSens = 6f;
    [SerializeField] Transform cameraF;

    private Rigidbody rb;
    private float pitch = 0f; // �㉺��]�p�i�J�����j

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // Cursor.lockState = CursorLockMode.Locked;//�}�E�X�J�[�\���̗L��
    }

    void Update()
    {
        RotateView(); // �}�E�X�ł̎��_��]
    }

    void FixedUpdate()
    {
        Move(); // �O�㍶�E�̈ړ�
    }

    void RotateView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

        // �v���C���[�i���E�j����]
        transform.Rotate(Vector3.up * mouseX);

        // �J�����̏㉺��]�i�s�b�`�j
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // ���_���^��E�^���ɍs�������Ȃ��悤����

        cameraF.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Move()
    {
        // ���͎擾
        float h = Input.GetAxis("Horizontal"); // A/D �܂��� ��/��
        float v = Input.GetAxis("Vertical");   // W/S �܂��� ��/��

        // �J�����̌����Ɋ�Â����ړ�����
        Vector3 moveDir = (transform.forward * v + transform.right * h).normalized;

        // Rigidbody�ňړ��iY���x�͈ێ��j
        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = rb.linearVelocity.y; // �d�͂𖳎����Ȃ�

        rb.linearVelocity = velocity;
    }
}
