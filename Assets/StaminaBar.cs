using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image image;

    [SerializeField] GameObject player;
    PlayerController playerController;

    void Start()
    {
        image = this.GetComponent<Image>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        Debug.Log("‚ "+playerController.sutamina);
        image.fillAmount = playerController.sutamina / 25.0f;
    }
}
