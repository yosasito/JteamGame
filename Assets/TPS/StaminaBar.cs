using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image image;

    [SerializeField] GameObject player;
    PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = this.GetComponent<Image>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("‚ "+playerController.sutamina);
        image.fillAmount = playerController.sutamina / 25.0f;
    }
}
