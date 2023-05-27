using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttacher : MonoBehaviour
{
    private DragAndDrop3D dragAndDrop;
    private PlatformDetector platformDetector;

    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop3D>();
        platformDetector = GetComponent<PlatformDetector>();
    }

    private void OnEnable()
    {
        dragAndDrop.OnEndDrag += AttachToPlatform;
    }

    private void OnDisable()
    {
        dragAndDrop.OnEndDrag -= AttachToPlatform;
    }

    private void AttachToPlatform()
    {
        if (!platformDetector.NewPlatform)
            return;

        
        if (platformDetector.NewPlatform.TryAttach(gameObject.GetComponent<Unit>()))
        {
            platformDetector.ChangeCurrentPlatform(platformDetector.NewPlatform);
        }
        else
        {
            platformDetector.CurrentPlatform.Attach(gameObject.GetComponent<Unit>());
        }
    }
}
