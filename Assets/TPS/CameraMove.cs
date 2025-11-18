using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float height = 2f;
    [SerializeField] float distance = 5f;
    [SerializeField] float mouseSens = 120f;

    float angle = 0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

        angle += mouseX;

        Vector3 offset = new Vector3(
            Mathf.Sin(angle) * distance,
            height,
            Mathf.Cos(angle) * distance
        );

        transform.position = player.position + offset;

        transform.LookAt(player.position + Vector3.up * 1.2f);
    }
}
