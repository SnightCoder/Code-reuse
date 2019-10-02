using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SelectionManager))]
public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnDeselect(Transform selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null){
            outline.OutlineWidth = 0;
            outline.OutlineColor=Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    public void OnSelect(Transform selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null){
            outline.OutlineWidth = 10;
            outline.OutlineColor=Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

}
