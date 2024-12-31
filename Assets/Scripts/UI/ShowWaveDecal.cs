using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShowWaveDecal : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;  
    [SerializeField] private Animator animator;
    [SerializeField] private Texture2D[] waveTexture;
    [SerializeField] private Texture2D bossWaveTexture;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private GameObject player;
    [SerializeField] private DecalProjector projector;
    [SerializeField] private GameObject animParent;

    private void OnEnable()
    {
        startPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 20);
        animParent.transform.position = startPos;
        StartCoroutine("DisableAfterSeconds", 2f);
        if (gameManager.currentWave % 5 == 0 &! (gameManager.currentWave == 0)) 
        {
            projector.material.SetTexture("Base_Map", bossWaveTexture);
            animator.SetTrigger("WaveTrigger");
            return;
        }
        projector.material.SetTexture("Base_Map", waveTexture[gameManager.currentWave]);
        animator.SetTrigger("WaveTrigger");
    }
    private void OnDisable()
    {
        transform.position = startPos;
    }

    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.enabled = false;
    }
}
