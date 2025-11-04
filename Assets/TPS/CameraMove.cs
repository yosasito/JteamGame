using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] float hight;
    [SerializeField] float back;

    PlayerController playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = player.GetComponent<PlayerController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.transform.position + new Vector3(0, hight, back); 
        //transform.position = playerPos.transform.position + new Vector3(0, 0, back);
    }
}
