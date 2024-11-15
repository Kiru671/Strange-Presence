using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCam;
    private float ShakeTimer;

    void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin multiChannelPerlin =
            virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        multiChannelPerlin.m_AmplitudeGain = intensity;
        ShakeTimer = time;
    }

    private void Update()
    {
        if (ShakeTimer > 0) 
        {
            ShakeTimer -= Time.deltaTime;
            if (ShakeTimer < 0) 
            {
                CinemachineBasicMultiChannelPerlin multiChannelPerlin =
                    virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                multiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
