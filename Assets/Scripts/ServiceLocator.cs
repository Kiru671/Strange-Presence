using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static ISoundPlayer _soundPlayer;

    public static void RegisterSoundPlayer(ISoundPlayer soundPlayer)
    {
        _soundPlayer = soundPlayer;
    }

    public static ISoundPlayer GetSoundPlayer()
    {
        return _soundPlayer;
    }
}
