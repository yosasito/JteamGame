using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door; // 開閉する扉
    public float openHeight = 3f; // 開く高さ
    public float openSpeed = 2f; // 開閉スピード

    private bool isOpen = false;
    private Vector3 closedPos;
    private Vector3 openPos;

    private bool isMoving = false;

    void Start()
    {
        // 扉の初期位置を記録
        closedPos = door.transform.position;
        openPos = closedPos + Vector3.up * openHeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            // 開閉をトグル（開いていれば閉じ、閉じていれば開く）
            isOpen = !isOpen;
            StopAllCoroutines();
            StartCoroutine(MoveDoor(isOpen));
        }
    }

    System.Collections.IEnumerator MoveDoor(bool open)
    {
        isMoving = true;
        Vector3 start = door.transform.position;
        Vector3 end = open ? openPos : closedPos;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            door.transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        door.transform.position = end;
        isMoving = false;
    }
}