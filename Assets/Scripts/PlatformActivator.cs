using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayerMask;
    private DragAndDropBase dragAndDropBase;
    private Camera cam;
    private Platform lastPlatform;

    private void Awake()
    {
        dragAndDropBase = GetComponent<DragAndDropBase>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        dragAndDropBase.OnDrag += ActivatePlatform;
        dragAndDropBase.OnEndDrag += DeactivatePlatform;
    }

    private void OnDisable()
    {
        dragAndDropBase.OnDrag -= ActivatePlatform;
        dragAndDropBase.OnEndDrag -= DeactivatePlatform;
    }

    private void ActivatePlatform()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, platformLayerMask))
        {
            var platform = hit.collider.GetComponent<Platform>();

            if (platform.IsEnemy)
                return;

            platform.Activate();

            if (lastPlatform != null && platform != lastPlatform)
                lastPlatform.Deactivate();

            lastPlatform = platform;
        }
    }

    private void DeactivatePlatform()
    {
        if (lastPlatform != null)
            lastPlatform.Deactivate();
    }
}
