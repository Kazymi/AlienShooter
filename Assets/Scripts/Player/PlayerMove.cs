using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour,ISpeed
{
    [SerializeField] private bool mobile = true;
    private Joystick _joystick;
    private CharacterController _characterController;
    private float _currentSpeed;
    
    public Dictionary<TypeBuff, float> ActiveBuffs { get; set; }

    private void Start()
    {
        ActiveBuffs = new Dictionary<TypeBuff, float>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Initialize(PlayerConfiguration playerConfiguration, Joystick joystick)
    {
        _joystick = joystick;
        _currentSpeed = playerConfiguration.Speed;
    }
    
    public void AddBuff(TypeBuff buff, float valueSpeed)
    {
        if (!ActiveBuffs.ContainsKey(buff))
        {
            ActiveBuffs.Add(buff,valueSpeed);
            _currentSpeed += valueSpeed;
        }
    }

    public void DeactivateBuff(TypeBuff buff)
    {
        if (ActiveBuffs.ContainsKey(buff))
        {
            _currentSpeed -= ActiveBuffs[buff];
            ActiveBuffs.Remove(buff);
        }
    }
    
    private void Move()
    {
        var moveDir = mobile ? new Vector3(-_joystick.Horizontal, 0, -_joystick.Vertical) : new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDir = transform.TransformDirection(moveDir);
        moveDir *= _currentSpeed * Time.deltaTime;
        _characterController.Move(moveDir);
    }
}