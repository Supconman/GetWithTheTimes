using System;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{

    public int day = 0;
    public Texture2D battleBackground;
    public bool egg = false; 

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
