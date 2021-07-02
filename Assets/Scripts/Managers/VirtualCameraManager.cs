using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{
   [SerializeField] private List<VirtualCameraButton> _cameraButtons = new List<VirtualCameraButton>();

   private void Awake()
   {
      foreach (var VARIABLE in _cameraButtons)
      {
         VARIABLE.Initialize(this);
      }
   }

   public void SetCamera(CinemachineVirtualCamera virtualCamera)
   {
      foreach (var VARIABLE in _cameraButtons)
      {
         VARIABLE.Camera.Priority = 0;
      }
      virtualCamera.Priority = 1;
   }
}
