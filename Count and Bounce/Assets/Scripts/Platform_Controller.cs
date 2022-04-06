using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform_Controller : MonoBehaviour
{
    [SerializeField] private Game_Manager _gameManager = null;
    [SerializeField] private GameObject _ball;
    [SerializeField] private enum PlatformType{
        _withText,
        _withoutText
    }

    [SerializeField] private PlatformType _tpye;


    [Header("Text Color")]
    [SerializeField] private Color _positiveColor;
    [SerializeField] private Color _negativeColor;

    [Header("Platform Text")]
    [SerializeField] private TMP_Text _platformText = null;

    [Header("Gameplay")]
    [SerializeField] private float _force;
    [SerializeField] private int _count = 0;
    [SerializeField] private int _randomCount = 0;
    private bool _isHit = false;
    private string _platformType;
    private int _ballCount = 0;
    private int _minusBall = 0;
    void Start()
    {
        RandomPlatformCount();
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _gameManager = GameObject.FindObjectOfType<Game_Manager>();

        switch(_tpye) {
            case PlatformType._withText : RandomPlatformCount();
                break;
            case PlatformType._withoutText : _count = 0; PlatformText(0, Color.clear);
                break;
        }

        
    }

    void Update()
    {
        if(_isHit && transform.parent != null) {
            transform.parent.gameObject.transform.parent = null;
        }
        _ballCount = _ball.GetComponent<Ball_Controller>()._balls.Count;
        _minusBall= _ball.GetComponent<Ball_Controller>()._balls.Count + _count;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ball")) {
            Rigidbody _objRigidBody = other.gameObject.GetComponent<Rigidbody>();
            _objRigidBody.velocity = new Vector3(
                _objRigidBody.velocity.x,
                _objRigidBody.velocity.y,
                5
            );
            _objRigidBody.AddForce(Vector3.up * _force * Time.deltaTime, ForceMode.VelocityChange);
            

            CheckPlatformCount(_count, other.gameObject);

            _isHit = true;

        }
    }

    private void CheckPlatformCount(int _value, GameObject _gameObject) {
        if(_value > 0) {
            for(int i = 0; i < _count; i++) {
                _gameObject.GetComponent<Ball_Controller>().CreateaBall();
            }
        }
        else if(_value < 0) {
            if(_ballCount > -1 * _count) {
                for(int i = _ballCount - 1; i >= _minusBall; i--) {
                    _gameObject.GetComponent<Ball_Controller>()._balls.RemoveAt(i);
                    _ball.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            else {
                _gameManager.SetIsDead(true);
            }
            
        }
        else {
            return;
        }
    }

    private void RandomPlatformCount() {
        int _randomNumber = Random.Range(-_randomCount, _randomCount + 1);
        _count = _randomNumber;

        if(_randomNumber > 0) {
            PlatformText(_randomNumber, _positiveColor);
        }
        else if(_randomNumber < 0) {
            PlatformText(_randomNumber, _negativeColor);
        }
        else {
            _platformText.text = "";
        }
    }

    private void PlatformText(int _value, Color _color) {
        _platformText.text = _value.ToString();
        _platformText.color = _color;
    }

    
}
