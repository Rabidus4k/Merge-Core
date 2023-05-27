using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    [SerializeField]
    private Vector3 rayOffset;
    [SerializeField]
    private LayerMask platformLayerMask;

    public Platform NewPlatform { get => newPlatform; }
    public Platform CurrentPlatform { get => currentPlatform; }
    private DragAndDrop3D dragAndDrop;
    private Platform newPlatform;
    private Platform currentPlatform;

    private RaycastHit hit;

    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop3D>();
    }

    private void OnEnable()
    {
        dragAndDrop.OnDrag += DetectPlatform;
    }

    private void OnDisable()
    {
        dragAndDrop.OnDrag -= DetectPlatform;
    }

    private void DetectPlatform()
    {
        if (Physics.Raycast(transform.position + rayOffset, Vector3.down, out hit, 5, platformLayerMask))
        {
            var platform = hit.collider.gameObject.GetComponent<Platform>();

            if (currentPlatform == null)
            {
                ChangeCurrentPlatform(platform);
            }
            else
            {
                newPlatform = platform;
            }
        }
    }

    public void ChangeCurrentPlatform(Platform platform)
    {
        currentPlatform = platform;
    }
}
