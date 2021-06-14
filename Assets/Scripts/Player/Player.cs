using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick lookJoystick;
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerLook PlayerLook;

    private void Start()
    {
        playerMove.Initialized(playerConfiguration,moveJoystick);
        PlayerLook.Initialized(lookJoystick);
    }
}
