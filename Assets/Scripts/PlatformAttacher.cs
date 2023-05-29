using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttacher : MonoBehaviour
{
    private DragAndDropBase dragAndDrop;
    private PlatformDetector platformDetector;

    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDropBase>();
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
