using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VirtualCameraButton : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private VirtualCameraManager _virtualCameraManager;
    private Button _button;

    public CinemachineVirtualCamera Camera => _virtualCamera;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _virtualCameraManager.SetCamera(_virtualCamera);
    }

    public void Initialize(VirtualCameraManager virtualCameraManager)
    {
        _virtualCameraManager = virtualCameraManager;
    }
}
