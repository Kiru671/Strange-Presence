using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Slider slider;

    public void SetVolume()
    {
        musicSource.volume = slider.value;
    }
}
