using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private Slider slider;

    public void SetVolume()
    {
        sfxSource.volume = slider.value;
    }
}
