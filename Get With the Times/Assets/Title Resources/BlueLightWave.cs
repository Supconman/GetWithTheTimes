using UnityEngine;

public class BlueLightWave : MonoBehaviour
{

    public float waveLength = 5.0f;
    public float waveSpeed = 1.0f;
    bool waveOn = false;

    // Update is called once per frame
    void Update()
    {
        if (waveOn && waveLength >= 0.0f) {
            transform.Translate(new Vector3(waveSpeed* Time.deltaTime, 0.0f, 0.0f));
            waveLength -= Time.deltaTime; 
        }
        else {
            waveOn = false; 
        }
    }

    public void enableWave() {
        waveOn = true; 
    }
}
