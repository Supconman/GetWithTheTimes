using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    TMP_Text text;
    AudioSource sound; 
    
    int day = 0;

    public float appearTime = 2.0f;
    public float disappearTime = 5.0f;
    public float disappearSpeed = 1.0f;
    float curTime = 0;
    bool appearedYet = false;

    public List<string> DayText = new List<string>() {"?? Days Remain", "5 Days Remain", "4 Days Remain", "3 Days Remain", "2 Days...", "The Final Day" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
        day = GlobalManager.globalInstance.day;
        sound = GetComponent<AudioSource>();

        if (day <= 5) {
            text.text = DayText[day];
        }
        else {
            text.text = "Someone Broke the Day Counter";
        }

        text.color = new Vector4(text.color.r, text.color.g, text.color.b, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;

        if(!appearedYet && curTime >= appearTime) {
            text.color = new Vector4(text.color.r, text.color.g, text.color.b, 1.0f);
            sound.Play();
            appearedYet = true;
        }
        else if (appearedYet && curTime >= disappearTime) {
            if(text.color.a <= 0.0f) {
                Destroy(gameObject);
            }
            text.color = new Vector4(text.color.r, text.color.g, text.color.b, text.color.a - disappearSpeed * Time.deltaTime);
        }
        
    }
}
