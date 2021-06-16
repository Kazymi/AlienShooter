using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private FireButton fireButton;
    
    public  FireButton FireButton
    {
        set => fireButton = value;
    }
    public bool Fire => fireButton.PointDown || Input.GetKey(KeyCode.Q);
}