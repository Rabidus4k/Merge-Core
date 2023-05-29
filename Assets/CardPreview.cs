using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{
    [SerializeField]
    private Card card;
    [SerializeField]
    private Button button;

    public GameObject PreviewPanel;

    private void OnEnable()
    {
        button.onClick.AddListener(HidePreview);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HidePreview);
    }

    public void ShowPreview(UnitInfo info)
    {
        card.Init(info);
        PreviewPanel.SetActive(true);
    }

    public void HidePreview()
    {
        PreviewPanel.SetActive(false);
    }
}
