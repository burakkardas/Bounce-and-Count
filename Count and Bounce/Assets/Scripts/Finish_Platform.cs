using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish_Platform : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private TMP_Text _finishText;
    private int _count = 0;

    void Update()
    {
        _finishText.text = _count.ToString();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ball")) {
            Debug.Log("Level Complete");
            _count =  other.gameObject.GetComponent<Ball_Controller>()._balls.Count;
            _particle.Play();
        }
    }
}
