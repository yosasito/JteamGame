using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    public RectTransform arrow;
    public Vector3 targetPos = new Vector3(-190, 106, 0);
    public float speed = 200f;
    public float shrinkspeed = 5f;

    private bool isMoving = false;
    private bool shrink = false;


    [SerializeField] private RectTransform testPanel;
    private Vector2 targetSize = new Vector2(50, 50);
    //[SerializeField] private Vector3 Transform;
    private void Start()
    {
        Transform tf = GetComponent<Transform>();
        tf.localScale = new Vector3(1, 1, 1);
    }
    public void OnClickStartButton()
    {
        isMoving = true;
        shrink = true;
        // arrow.sizeDelta = new Vector2(50, 50);       
    }

    void Update()
    {
        if (!isMoving) return;

        arrow.anchoredPosition = Vector3.MoveTowards(
            arrow.anchoredPosition,
            targetPos,
            speed * Time.deltaTime
        );
        if (!shrink) return;

        arrow.sizeDelta = Vector2.MoveTowards(
            arrow.sizeDelta,
            targetSize,
            shrinkspeed * Time.deltaTime
        );

        // “ž’…”»’è
        if (Vector3.Distance(arrow.anchoredPosition, targetPos) < 0.1f)
        {
            isMoving = false;
        }
        if (Vector2.Distance(arrow.sizeDelta, targetSize) < 0.1f)
        {
            shrink = false;
        }
    }
}
