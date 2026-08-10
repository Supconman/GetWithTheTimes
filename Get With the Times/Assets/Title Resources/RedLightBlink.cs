using UnityEngine;

public class RedLightBlink : MonoBehaviour
{
    public Light redLight;
    public float maxIntensity = 10;
    public float disappearSpeed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redLight = gameObject.GetComponent<Light>();
    }
    void Update() {
        if(redLight.intensity > 0.0f) {
            redLight.intensity -= disappearSpeed * Time.deltaTime;
        }
        else {
            redLight.intensity = 0.0f; 
        }
        

    }
    public void blink () {
        redLight.intensity = maxIntensity;
    }

}
