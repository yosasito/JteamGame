using UnityEngine;
using UnityEngine.EventSystems;

public class BrokenWall : MonoBehaviour
{
    //public int enemyHit = 0;
    //public int hitCount = 3;
    //public float rayLength = 2f;

    //public LayerMask enemyMask;

    public int hitCount = 18;
    private int currentHit = 0;

    public float checkDistance = 0.5f;
    public LayerMask enemyMask;

    [SerializeField] GameObject[] wallLevel;//壊れていく壁


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeWall();
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

        Vector3[] dirs =
        {
            transform.right,
            -transform.right
        };

        foreach (var dir in dirs)
        {
            Debug.DrawRay(origin, dir * checkDistance, Color.red);

            if (Physics.Raycast(origin, dir, out RaycastHit hit, checkDistance, enemyMask))
            {
                if (!hit.collider.CompareTag("Enemy"))
                    continue;

                ChaserScript chaser = hit.collider.GetComponent<ChaserScript>();
                if (chaser == null || !chaser.Chasing)
                    continue;

                float dot = Vector3.Dot(hit.collider.transform.forward, -dir);//敵の向き

                if (dot > 0.7f) // 正面だけ
                {
                    currentHit++;
                    ChangeWall();
                    //Debug.Log("壁HIT＝" + currentHit);

                    if (currentHit >= hitCount)
                        Destroy(gameObject);

                    break; 
                }
            }
        }
    }
    void ChangeWall()
    {
        foreach (var a in wallLevel)
            a.SetActive(false);

        if (currentHit >= 8)
            wallLevel[2].SetActive(true);   // かなり壊れ

        else if (currentHit >= 5)
            wallLevel[1].SetActive(true);   // 壊れかけ

        else
            wallLevel[0].SetActive(true);   // 初期
    }
}
