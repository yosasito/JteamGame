using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door; // �J�����
    public float openHeight = 3f; // �J������
    public float openSpeed = 2f; // �J�X�s�[�h

    private bool isOpen = false;
    private Vector3 closedPos;
    private Vector3 openPos;

    private bool isMoving = false;

    void Start()
    {
        // ���̏����ʒu���L�^
        closedPos = door.transform.position;
        openPos = closedPos + Vector3.up * openHeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            // �J���g�O���i�J���Ă���Ε��A���Ă���ΊJ���j
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