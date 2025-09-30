using UnityEngine;
using UnityEngine.AI;

public class navme : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] public Transform target;
    [SerializeField] GameObject player;

    public float distance = 5f;
    private void Start()
    {      
        player = GameObject.FindWithTag("Player");

        //new
        agent = GetComponent<NavMeshAgent>();
        
    }


    // Update is called once per frame
    void Update()
    {
        float positionDif = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(positionDif);

        if (distance <= positionDif)
        {
            agent.SetDestination(player.transform.position);
           // Debug.Log(player.transform.position);
        }

    }
}
