using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField]
    private Sprite normalSprite;
    [SerializeField]
    private Sprite mutedSprite;

    private Image image;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        image = GetComponent<Image>();
        SetImage(SoundManager.Instance.GetSoundMuted());
    }

    public void SoundButtonClicked()
    {
        SoundManager.Instance.SetSoundMuted(!SoundManager.Instance.GetSoundMuted());
        SetImage(SoundManager.Instance.GetSoundMuted());
    }

    private void SetImage(bool muted)
    {
        image.sprite = muted ? mutedSprite : normalSprite;
    }
}
