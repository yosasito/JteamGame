using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door; 
    public float openHeight = 100f; // 開く高さ
    public float openSpeed = 2f; // 開閉スピード

    private bool isOpen = false;
    private Vector3 closedPos;
    private Vector3 openPos;

    private bool Moving = false;

    void Start()
    {
        // 扉の位置
        closedPos = door.transform.position;
        openPos = closedPos + Vector3.up * openHeight;
    }

    private void OnTriggerEnter(Collider other)//playerが踏む
    {
        if (other.CompareTag("Player") && !Moving)
        {
            isOpen = !isOpen;
            StopAllCoroutines();
            StartCoroutine(MoveDoor(isOpen));
        }
    }

    System.Collections.IEnumerator MoveDoor(bool open)
    {
        Moving = true;
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
        Moving = false;
    }
}