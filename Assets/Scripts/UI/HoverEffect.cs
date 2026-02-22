using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Text Iestatījumi")]
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Color normalColor = new Color(0.7f, 0.7f, 0.7f, 1f); // Pelēcīgs
    [SerializeField] private Color hoverColor = Color.white;
    [SerializeField] private float scaleMultiplier = 1.05f; // Mazs pieaugums

    private Vector3 originalScale;

    void Start()
    {
        if (buttonText == null) buttonText = GetComponentInChildren<TextMeshProUGUI>();
        
        originalScale = transform.localScale;
        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
        transform.localScale = originalScale * scaleMultiplier;
        AudioManager.Instance.PlayHover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
        transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonText.color = normalColor;
        transform.localScale = originalScale;
        AudioManager.Instance.PlayClick();
    }
}