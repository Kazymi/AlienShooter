using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuConstrol : MonoBehaviour
{
    [SerializeField] private List<Canvas> canvases = new List<Canvas>();
    
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void OpenCanvas(Canvas canvas)
    {
        foreach (var i in canvases)
        {
            i.enabled = false;
        }
        canvas.enabled = true;
    }
}
