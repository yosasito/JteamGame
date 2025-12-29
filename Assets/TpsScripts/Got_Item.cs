using UnityEngine;
using TMPro;

public class Got_Item : MonoBehaviour
{
    int score = 0;
    public int clearTask;
    public int itemVal;

    [SerializeField] TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //scoreText.text = "" + itemVal;
    }
    // Update is called once per frame
    void Update()
    {
        if (score >= clearTask)
        {
            Destroy(this.gameObject);
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + (itemVal - score).ToString();
        }
    }
    public void AddScore(int plus)
    {
        score += plus;
        Debug.Log("âÒé˚êî= " + score);

        UpdateUI();
    }
}
