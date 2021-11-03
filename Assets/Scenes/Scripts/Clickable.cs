using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (eventData.button == PointerEventData.InputButton.Left) {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
            Debug.Log(linkIndex);

            if (linkIndex > -1) {
                var linkInfo = text.textInfo.linkInfo[linkIndex];
                var linkId = linkInfo.GetLinkID();

                Debug.Log(linkInfo.GetLinkText());
            }
        }

    }
}
