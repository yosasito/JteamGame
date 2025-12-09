using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField] private Transform Button;
    [SerializeField] private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button = GetComponent<Transform>();
        originalScale = Button.transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.localScale = originalScale * 1.1f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Button.localScale = originalScale;
    }
    // Update is called once per frame

}
