using System.Drawing;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int point = 1;

    Got_Item getKey;

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
}
