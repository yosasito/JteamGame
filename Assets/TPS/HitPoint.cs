using UnityEngine;
using UnityEngine.UI;

public class HitPoint : MonoBehaviour
{
    private Image image;
    public float playerHp;

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
        image.fillAmount = playerController.Hp / playerHp;
    }
}
