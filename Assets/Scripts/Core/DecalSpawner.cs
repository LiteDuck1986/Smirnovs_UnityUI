using UnityEngine;
using UnityEngine.EventSystems;

public class DecalSpawner : MonoBehaviour, IPointerDownHandler
{
    public GameObject decalPrefab;
    public Transform characterPanel; // UI Parent
    public RectTransform spawnPoint; // spawn point

    public void OnPointerDown(PointerEventData eventData)
    {
        // Max 3 decals
        if (characterPanel.childCount >= 3) return;

        AudioManager.Instance.PlayClick();

        // Spawno decal
        GameObject newDecal = Instantiate(decalPrefab, characterPanel);

        RectTransform decalRect = newDecal.GetComponent<RectTransform>();
        decalRect.anchoredPosition = spawnPoint.anchoredPosition;
        
        // random offset spawn
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-10f, 10f);
        decalRect.anchoredPosition += new Vector2(randomX, randomY);
    }
}