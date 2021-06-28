using System.Collections.Generic;
using UnityEngine;

public class CanvasPicker : MonoBehaviour
{
    [SerializeField] private List<Canvas> canvases;

    public void OpenCanvas(Canvas canvas)
    {
        foreach (var i in canvases)
        {
            i.enabled = false;
        }
        canvas.enabled = true;
    }
}