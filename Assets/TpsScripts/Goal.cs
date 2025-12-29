using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    bool getGoal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getGoal = true;
            Debug.Log("ÉNÉäÉA");
        }
    }
}
