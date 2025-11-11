using System.Drawing;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int point = 1;

    Got_Item getKey;
    [SerializeField] float floatHeight = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getKey = FindFirstObjectByType<Got_Item>();
    }

    // Update is called once per frame
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

     void Update()
    {
        Quaternion a = Quaternion.AngleAxis(15 * Time.deltaTime, Vector3.up);
        Quaternion b = transform.rotation;

        transform.rotation = a * b;

        float y = Mathf.Sin(Time.time * 2f) * floatHeight;
        transform.position = new Vector3(transform.position.x, transform.position.y + (y * Time.deltaTime), transform.position.z);

    }
}
