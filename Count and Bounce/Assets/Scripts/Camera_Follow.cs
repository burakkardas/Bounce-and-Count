using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform _ball = null;
    private Vector3 _offset;
    [SerializeField] [Range(0, 2)] private float _lerpTime = 0; 
    void Start()
    {
        _offset = transform.position - _ball.position;
    }

    void LateUpdate()
    {
        var _newPos = Vector3.Lerp(transform.position, _offset + _ball.transform.position, _lerpTime * Time.deltaTime);
        transform.position = _newPos;
    }
}
