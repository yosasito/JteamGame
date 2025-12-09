using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonIC : MonoBehaviour
{
     public Sprite highlightedSprite;
    private Image buttonImage;
    private Sprite normalSprite;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        normalSprite = buttonImage.sprite;
    }
    public void OnPointerEnter()
    {
        buttonImage.sprite = highlightedSprite;
    }
    public void OnPointerExit()
    {
        buttonImage.sprite = normalSprite;
    }
}
