using UnityEngine;

public class MetaTextTurnOn : MonoBehaviour
{

    Material glow;
    public float maxIntensity = 1;
    public float appearSpeed = 1;
    float curIntensity = 0; 
    bool lightUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        glow = GetComponent<MeshRenderer>().material;
        glow.SetFloat("_Intensity", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (lightUp && curIntensity < maxIntensity - 0.01f) {
            curIntensity += (maxIntensity - curIntensity) * appearSpeed * Time.deltaTime;
            glow.SetFloat("_Intensity", curIntensity);
        }
        else if (lightUp) {
            curIntensity = maxIntensity;
            glow.SetFloat("_Intensity", curIntensity);
            lightUp = false;
        }
    }

    public void turnTextOn() {
        lightUp = true;
    }
}
