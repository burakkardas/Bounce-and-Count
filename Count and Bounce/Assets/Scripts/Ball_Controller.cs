using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField] private Game_Manager _gameManager = null;
    [SerializeField] private Rigidbody _rigidBody = null;
    [SerializeField] private GameObject _ballPrefab;

    [Header("Lists")]
    public List<GameObject> _balls = new List<GameObject>();
    [SerializeField] private List<Vector3> _ballPosisitons = new List<Vector3>();


    [Header("Ball Count Text")]
    [SerializeField] private TMP_Text _ballText = null;

    private int _gap = 15;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    
    private void Update() {
        float _y;
        _y = Mathf.RoundToInt(_rigidBody.velocity.y);
        _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _y, _rigidBody.velocity.z);
        _ballPosisitons.Insert(0, transform.position);

        int _index = 0;
        foreach(var _ball in _balls) {
            Vector3 _point = _ballPosisitons[Mathf.Min(_index * _gap, _ballPosisitons.Count - 1)];
            _ball.transform.position = _point;
            _index++;
        }

        _ballText.text = _balls.Count.ToString("00");

        if(transform.position.y <= -2) {
            _gameManager.SetIsDead(true);
        }
    }

    public void CreateaBall() {
        GameObject _ball = Instantiate(_ballPrefab);
        _ball.transform.SetParent(transform);
        _balls.Add(_ball);

    }
}
