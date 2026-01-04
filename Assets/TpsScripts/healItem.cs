using System.Drawing;
using UnityEngine;

public class healItem : MonoBehaviour
{
    [SerializeField] float Height = 0.2f;
    Vector3 Pos;
    bool used = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion a = Quaternion.AngleAxis(30 * Time.deltaTime, Vector3.up);
        Quaternion b = transform.rotation;

        transform.rotation = a * b;

        transform.Rotate(Vector3.up, 30f * Time.deltaTime);

        float y = Mathf.Sin(Time.time * 2f) * Height;
        transform.position = Pos + Vector3.up * y;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;

        used = true;

        PlayerController playerHeal = other.GetComponent<PlayerController>();
        if (playerHeal != null)
        {
            playerHeal.Heal(3);
        }

        Destroy(gameObject);
    }
}
