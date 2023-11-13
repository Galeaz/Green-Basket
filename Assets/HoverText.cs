using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class HoverText : MonoBehaviour
{
    [SerializeField] string nameStat;
    [SerializeField] string descriptionStat;
    [SerializeField] string inOutOfSeasonStat;
    [SerializeField] string locallySourcedStat;
    [SerializeField] string fairTradeStat;

    private Canvas objectStatsCanvas;
    private Text objectStatsText;
    private bool showObjectStats = false;

    private void Start()
    {
        // Creates the canvas.
        objectStatsCanvas = new GameObject("ObjectStatsCanvas").AddComponent<Canvas>();
        objectStatsCanvas.renderMode = RenderMode.WorldSpace;
        objectStatsCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
        objectStatsCanvas.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        objectStatsCanvas.enabled = false;

        // ITEM TEXTBOX -----------------------------------------------------------------------------------------------------------
        GameObject itemName = new GameObject("ItemName");
        itemName.transform.SetParent(objectStatsCanvas.transform);
        itemName.transform.LookAt(Camera.main.transform);

        objectStatsText = itemName.AddComponent<Text>();
        objectStatsText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // You can use any font you prefer.
        objectStatsText.fontSize = 40;
        objectStatsText.alignment = TextAnchor.UpperCenter;
        objectStatsText.text = nameStat + "\n" + descriptionStat + "\n" + inOutOfSeasonStat + "\n" + locallySourcedStat + "\n" + fairTradeStat;

        RectTransform textTransformOne = itemName.GetComponent<RectTransform>();
        textTransformOne.sizeDelta = new Vector2(700, 1000);
        textTransformOne.anchoredPosition = new Vector2(0, 0);
    }

    private void Update()
    {
        if (showObjectStats)
        {
            objectStatsCanvas.enabled = true;
        }
        else
        {
            objectStatsCanvas.enabled = false;
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        showObjectStats = true;
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        showObjectStats = false;
        objectStatsCanvas.enabled = false;
    }
}