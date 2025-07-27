using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    static BackgroundMusic _instance;

    void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
