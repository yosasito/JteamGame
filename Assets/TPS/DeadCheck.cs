using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCheck : MonoBehaviour
{
    [SerializeField] private GameObject player;

    PlayerController playerController;
    TextMeshProUGUI uiText;
    public bool isProcessing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
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

