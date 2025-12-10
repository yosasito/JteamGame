using UnityEngine;
using UnityEngine.EventSystems;

public class BrokenWall : MonoBehaviour
{
    public int enemyHit = 0;
    public int hitCount = 3;
    public float rayLength = 2f;

    public LayerMask enemyMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position + Vector3.up * 0.2f;

        Vector3[] dirs =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        foreach (var dir in dirs)
        {
            Debug.DrawRay(origin, dir * rayLength, Color.red, 0.1f);

            if (Physics.SphereCast(origin, 5f, dir, out RaycastHit hit, rayLength, enemyMask))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    ChaserScript chaser = hit.collider.GetComponent<ChaserScript>();

                    if (chaser != null && chaser.Chasing)
                    {
                        enemyHit += 1;
                        Debug.Log("•Çƒqƒbƒg” = " + enemyHit);
                    }
                }
            }
        }

        if (enemyHit >= hitCount)
        {
            Destroy(this.gameObject);
        }
    }
}
