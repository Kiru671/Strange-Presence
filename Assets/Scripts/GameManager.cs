using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private bool waveCleared;
    public int currentWave = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCleared)
        {
            NextWave();
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextWave();
        }
    }
#endif
    private void NextWave()
    {
        currentWave++;
        waveCleared = false;
    }
}
