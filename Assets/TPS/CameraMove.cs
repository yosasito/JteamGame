using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float height = 2f;
    [SerializeField] float distance = 5f;
    [SerializeField] float mouseSens = 120f;
    [SerializeField] float minY = -20f;
    [SerializeField] float maxY = 40f;

    float angle = 0f;
    float angleY = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        angle += mouseX;
        angleY -= mouseY;
        angleY = Mathf.Clamp(angleY, minY, maxY);

        //Vector3 offset = new Vector3(
        //    Mathf.Sin(angle) * distance,
        //    height,
        //    Mathf.Cos(angle) * distance
        //);

        Quaternion rot = Quaternion.Euler(angleY, angle, 0);

        Vector3 offset = rot * new Vector3(0, 0, -distance);
        offset.y += height;

        transform.position = player.position + offset;

        transform.LookAt(player.position + Vector3.up * 1.2f);
    }
}
