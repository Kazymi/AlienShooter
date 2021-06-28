using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private PlayerMovement target;

    private void LateUpdate()
    {
        float currentSpeed = startSpeed + target.Speed;
        // var newPos = Vector3.SmoothDamp(transform.position, _playerTransform.position, currentSpeed * Time.deltaTime);
        var newPos = Vector3.MoveTowards(transform.position, target.transform.position, currentSpeed * Time.deltaTime);
        transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
    }
}