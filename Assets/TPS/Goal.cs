using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    bool getGoal = false;

    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getGoal = true;
            Debug.Log("ÉNÉäÉA");
        }
    }
}
