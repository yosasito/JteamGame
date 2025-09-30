using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseSens = 6f;
    [SerializeField] Transform cameraF;

    private Rigidbody rb;
    private float pitch = 0f; // 上下回転用（カメラ）

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // Cursor.lockState = CursorLockMode.Locked;//マウスカーソルの有無
    }

    void Update()
    {
        RotateView(); // マウスでの視点回転
    }

    void FixedUpdate()
    {
        Move(); // 前後左右の移動
    }

    void RotateView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

        // プレイヤー（左右）を回転
        transform.Rotate(Vector3.up * mouseX);

        // カメラの上下回転（ピッチ）
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // 視点が真上・真下に行きすぎないよう制限

        cameraF.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Move()
    {
        // 入力取得
        float h = Input.GetAxis("Horizontal"); // A/D または ←/→
        float v = Input.GetAxis("Vertical");   // W/S または ↑/↓

        // カメラの向きに基づいた移動方向
        Vector3 moveDir = (transform.forward * v + transform.right * h).normalized;

        // Rigidbodyで移動（Y速度は維持）
        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = rb.linearVelocity.y; // 重力を無視しない

        rb.linearVelocity = velocity;
    }
}
