using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]  private float _startSpeed;
    
    private Transform _playerTransform;
    private PlayerMove _playerMove;

    public void Initialize(PlayerMove playerMove)
    {
        _playerMove = playerMove;
        _playerTransform = playerMove.transform;
    }
    private void Update()
    {
        float currentSpeed = _startSpeed + _playerMove.Speed;
        var newPos = Vector3.MoveTowards(transform.position, _playerTransform.position, currentSpeed*Time.deltaTime);
        transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
    }
}
