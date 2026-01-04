using System.Drawing;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int point = 1;

    Got_Item getKey;
    [SerializeField] float Height = 0.2f;
    Vector3 Pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getKey = FindFirstObjectByType<Got_Item>();
        Pos = transform.position;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            getKey.AddScore(point);
            Destroy(this.gameObject);
            //point++;
            //Debug.Log("score=" + point);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion a = Quaternion.AngleAxis(15 * Time.deltaTime, Vector3.up);
        Quaternion b = transform.rotation;

        transform.rotation = a * b;

        float y = Mathf.Sin(Time.time * 2f) * Height;
        transform.position = Pos + Vector3.up * y;

    }
}
