using UnityEngine;
using UnityEngine.EventSystems;

public class BrokenWall : MonoBehaviour
{
    //public int enemyHit = 0;
    //public int hitCount = 3;
    //public float rayLength = 2f;

    //public LayerMask enemyMask;

    public int hitCount = 2;
    private int currentHit = 0;

    public float checkDistance = 0.5f;
    public LayerMask enemyMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 origin = transform.position + Vector3.up * 0.2f;

        //Vector3[] dirs =
        //{
        //    Vector3.forward,
        //    Vector3.back,
        //    Vector3.left,
        //    Vector3.right
        //};

        //foreach (var dir in dirs)
        //{
        //    Debug.DrawRay(origin, dir * rayLength, Color.red, 0.1f);

        //    if (Physics.SphereCast(origin, 5f, dir, out RaycastHit hit, rayLength, enemyMask))
        //    {
        //        if (hit.collider.CompareTag("Enemy"))
        //        {
        //            ChaserScript chaser = hit.collider.GetComponent<ChaserScript>();

        //            if (chaser != null && chaser.Chasing)
        //            {
        //                enemyHit += 1;
        //               // Debug.Log("壁ヒット数 = " + enemyHit);
        //            }
        //        }
        //    }
        //}

        //if (enemyHit >= hitCount)
        //{
        //    Destroy(this.gameObject);
        //}

        Vector3 origin = transform.position + Vector3.up * 0.5f;
        Vector3 dir = transform.right; // 壁の前方向

        Debug.DrawRay(origin, dir * checkDistance, Color.red);

        if (Physics.Raycast(origin, dir, out RaycastHit hit, checkDistance, enemyMask))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                ChaserScript chaser = hit.collider.GetComponent<ChaserScript>();
                if (chaser == null || !chaser.Chasing)
                    return;

                // 敵の向きが壁に向いているか
                float dot = Vector3.Dot(hit.collider.transform.forward, transform.forward);

                if (dot > 0.7f) // 正面突進のみ
                {
                    currentHit++;
                    Debug.Log("壁ヒット：" + currentHit);

                    if (currentHit >= hitCount)
                        Destroy(gameObject);
                }
            }
        }
    }

}
