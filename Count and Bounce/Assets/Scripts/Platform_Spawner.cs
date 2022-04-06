using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _finishPlatform;
    public List<GameObject> _lastObjectPrefabs = new List<GameObject>();
    [SerializeField] private int _objectCount = 0;
    [SerializeField] private float _platformBetweenDistance = 0;
    [SerializeField] private float _angle = 0;

    public int GetObjectCount() {
        return _objectCount;
    }

    void Start()
    {
        CreatePlatform(_objectCount);
    }


    private void CreatePlatform(int _count) {
        for(int i = 0; i < _count; i++) {
            GameObject _instance = Instantiate(
                _lastObjectPrefabs[Random.Range(0, 4)], 
                new Vector3(
                    transform.position.x,
                    _lastObjectPrefabs[0].transform.position.y,
                    _lastObjectPrefabs[_lastObjectPrefabs.Count - 1].transform.position.z + _platformBetweenDistance
                ),
                Quaternion.Euler(0f, 0f, Random.Range(-_angle, _angle + 1))
                );
            
            _instance.transform.SetParent(GameObject.Find("Platforms").transform);
            _lastObjectPrefabs.Add(_instance);

            _finishPlatform.transform.position = new Vector3(
                0f,
                0f,
                _instance.transform.position.z + 4f
            );
        }
    }
}
