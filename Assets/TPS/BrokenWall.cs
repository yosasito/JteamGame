using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public int hit = 0;
    public int hitCount=3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hit);

        if (hit == hitCount)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hit += 1;
        }
    }
}
