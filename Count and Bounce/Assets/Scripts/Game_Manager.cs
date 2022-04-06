using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{

    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private GameObject _gameOverPanel;

    private bool _isDead = false;
    public bool GetIsDead() {
        return _isDead;
    }
    public void SetIsDead(bool _value) {
        _isDead = _value;
    }
    void Awake()
    {
        _levelCompletePanel = GameObject.Find("Level Complete Panel");
        _levelCompletePanel = GameObject.Find("Level Complete Panel");

    }
    void Update()
    {
        if(_isDead) {
            _gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
        Color_Manager.Instace.RandomPlatformColor();
        _isDead = false;
        _gameOverPanel.SetActive(false);
    }

    public void NextLevel() {
        SceneManager.LoadScene(1);
        Color_Manager.Instace.RandomPlatformColor();
    }
}
