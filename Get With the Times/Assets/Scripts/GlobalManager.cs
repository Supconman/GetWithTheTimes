using System;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{

    private int day = 0;
    private Texture battleBackground;

    public static GlobalManager globalInstance;

    private void Awake()
    {
        if(globalInstance == null) {
            globalInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
