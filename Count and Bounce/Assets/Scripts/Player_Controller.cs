using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 0;
    void Update()
    {
        float _moveX = Input.GetAxis("Mouse X");

        if(Input.GetMouseButton(0)) {
            transform.Rotate(0f, 0f, _moveX * _rotateSpeed * Time.deltaTime);
        }
    }
}
