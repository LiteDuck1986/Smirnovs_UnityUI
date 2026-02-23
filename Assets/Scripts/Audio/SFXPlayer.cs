using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public void PlayClickSFX()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayClick();
        }
    }

    public void PlayHoverSFX()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayHover();
        }
    }

    public void PlayCloseSFX()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayClose();
        }
    }
}
