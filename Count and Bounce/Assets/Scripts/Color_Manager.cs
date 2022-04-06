using UnityEngine;

public class Color_Manager : MonoBehaviour
{
    private static Color_Manager _instance = null;

    public static Color_Manager Instace{
        get {
            return _instance;
        }
    }

    [SerializeField] private Material _platformMaterial = null;
    [SerializeField] private Color[] _colors = null;

    void Awake()
    {
        if(_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        RandomPlatformColor();
    }

    public void RandomPlatformColor() {
        int _randomIndex = Random.Range(0, _colors.Length);
        _platformMaterial.color = _colors[_randomIndex];
    } 
}
