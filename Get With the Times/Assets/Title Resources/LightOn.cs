using UnityEngine;

public class LightOn : MonoBehaviour
{

    public Light redLight;
    public float maxIntensity = 60;
    public float appearSpeed = 1;
    bool lightUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redLight = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightUp && redLight.intensity < maxIntensity) {
            redLight.intensity += appearSpeed * Time.deltaTime;
        }
        else {
            lightUp = false; 
        }
    }

    public void turnLightOn() {
        lightUp = true; 
    }
}
