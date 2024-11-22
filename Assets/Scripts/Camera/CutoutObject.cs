using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    [SerializeField] private Transform targetObject;

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private float cutoutSize = 0.35f;
    [SerializeField] private float falloffSize = 0.35f;

    private Camera mainCamera;
    
    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }
    
    void Update()
    {
        Vector2 cutOutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutOutPos.y /= Screen.width / Screen.height;

        Vector3 offset = targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, wallMask);
        
        for (int i = 0; i < hitObjects.Length; i++)
        {
            Material[] materials = hitObjects[i].collider.gameObject.GetComponent<Renderer>().materials;
            
            for(int j = 0; j < materials.Length; j++)
            {
                materials[j].SetVector("_CutoutPos", cutOutPos);
                materials[j].SetFloat("_CutoutSize", cutoutSize);
                materials[j].SetFloat("_FalloffSize", falloffSize);
            }
        }
    }
    
}
