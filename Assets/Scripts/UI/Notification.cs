using UnityEngine;

public class Notification : MonoBehaviour
{
    public GameObject notificationPanel;
    public GameObject menuButtons;

    // Static mainīgais
    private static bool hasShownNotification = false;

    void Start()
    {
        // Pārbauda vai esam notifikācijas paneli jau parādījuši
        if (hasShownNotification == false)
        {
            notificationPanel.SetActive(true);
            hasShownNotification = true;

            menuButtons.SetActive(false);
        }
        else
        {
            notificationPanel.SetActive(false);
            menuButtons.SetActive(true);
        }
    }
}