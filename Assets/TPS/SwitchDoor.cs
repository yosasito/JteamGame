using UnityEngine;
using System.Collections;

public class SwitchDoor : MonoBehaviour
{
    public GameObject[] doors;   
    public float openHeight = 5f;
    public float openSpeed = 2f;

    private bool isOpen = false;
    private bool moving = false;

    private Vector3 closedPos;
    private Vector3 openPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (doors.Length > 0)
        {
            closedPos = doors[0].transform.position;//位置
            openPos = closedPos + Vector3.up * openHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !moving)
        {
            isOpen = !isOpen;
            StopAllCoroutines();
            StartCoroutine(MoveDoors(isOpen)); // 壁を動かす
        }
    }

    IEnumerator MoveDoors(bool open)//ゆっくり
    {
        moving = true;
        float t = 0f;

        Vector3[] startPos = new Vector3[doors.Length];
        Vector3[] endPos = new Vector3[doors.Length];

        // 各ドアの開始・終了位置を準備
        for (int i = 0; i < doors.Length; i++)
        {
            startPos[i] = doors[i].transform.position;
            endPos[i] = open ? (startPos[i] + Vector3.up * openHeight)
                             : (startPos[i] - Vector3.up * openHeight);
        }

        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].transform.position = Vector3.Lerp(startPos[i], endPos[i], t);
            }
            yield return null;
        }

        moving = false;
    }
}
