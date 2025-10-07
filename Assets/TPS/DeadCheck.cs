using TMPro;
using UnityEngine;

public class DeadCheck : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController playerController;

    TextMeshProUGUI uiText;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        uiText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (playerController.dead == true)
        {
            //Debug.Log("GameOver");
            uiText.text = "GameOver";
        }
        if (playerController.dead == false)
        {
            //Debug.Log("GameOver");
            uiText.text = "";
        }
    }
}
