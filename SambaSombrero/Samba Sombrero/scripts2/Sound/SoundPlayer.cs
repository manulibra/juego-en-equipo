using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    public void PlaySound()
    {
        SoundManager.Instance.PlaySoundEffect(clip);
    }
}
