using TMPro;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    ChaserScript chasingS;

    TextMeshProUGUI uiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        chasingS = enemy.GetComponent<ChaserScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chasingS.Chasing == true)
        {
            uiText.text = "Watch Out!!";
        }
        else if (chasingS.Chasing == false)
        {
            uiText.text = "";
        }
    }
}
