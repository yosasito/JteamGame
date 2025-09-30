using UnityEngine;

public class Got_Item : MonoBehaviour
{
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    // Update is called once per frame
    public void AddScore(int plus)
    {
        //int sum = scoreS.score + scoreT.point + scoreF.score;
        score += plus;
        Debug.Log(score);
    }
    void Update()
    {
        if (score == 2)
        {
            Destroy(this.gameObject);
        }
    }
}
