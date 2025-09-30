using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public GameObject player;
    float hight = 70f;

    PlayerController playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = player.GetComponent<PlayerController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.transform.position + new Vector3(0, hight, 0); ;
    }
}
