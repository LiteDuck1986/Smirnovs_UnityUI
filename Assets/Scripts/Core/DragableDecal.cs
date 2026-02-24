using UnityEngine;
using UnityEngine.EventSystems;

public class MovableDecal : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    private RectTransform parentRect;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // parent rect
        parentRect = transform.parent as RectTransform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Novieto decal priekša on click
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect, 
            eventData.position, 
            eventData.pressEventCamera, 
            out localPoint
        );

        rectTransform.anchoredPosition = localPoint;
    }

    // Right click lai iznīcinātu
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Destroy(gameObject);
        }
    }
}