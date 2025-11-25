using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCheck : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    private TextMeshProUGUI uiText;
    private bool isProcessing = false;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        uiText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playerController.dead && !isProcessing)
        {
            isProcessing = true;
            Debug.Log("GameOver");
            uiText.text = "GameOver";

            StartCoroutine(GoToGameOver());
        }
    }

    private IEnumerator GoToGameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}

