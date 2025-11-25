using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCheck : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    private TextMeshProUGUI uiText;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        uiText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playerController.dead)
        {
            Debug.Log("GameOver");
            uiText.text = "GameOver";

            // ÉVÅ[ÉìêÿÇËë÷Ç¶
            yield return new WaitForSeconds(1f);
            //SceneManager.LoadScene("GameOver");
        }
    }
}
