using TMPro;
using UnityEngine;

public class sutaminaScript : MonoBehaviour
{
    [SerializeField] public GameObject player;
    PlayerController sutaminaS;

    TextMeshProUGUI uiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        sutaminaS = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "" + sutaminaS.sutamina;
    }
}
