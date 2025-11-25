using UnityEngine;

public class Got_Item : MonoBehaviour
{
    int score = 0;
    public int clearTask;
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
        if (score == clearTask)
        {
            Destroy(this.gameObject);
        }
    }
}
