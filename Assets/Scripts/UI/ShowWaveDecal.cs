using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWaveDecal : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private IEnumerator DecalAnim()
    {
        yield return new WaitForSeconds(1f);
    }
}
