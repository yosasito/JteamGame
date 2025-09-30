using UnityEngine;

public class DeadCheck : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();   
    }
    void Update()
    {
        if (playerController.dead == true)
        {
            Debug.Log("GameOver");
        }
    }
}
