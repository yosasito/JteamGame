using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] Transform player;
    public float hight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.position;
        position.y = hight;

        transform.position = position;
    }
}
