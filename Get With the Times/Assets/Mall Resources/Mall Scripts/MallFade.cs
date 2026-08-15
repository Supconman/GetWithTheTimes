using UnityEngine;
using UnityEngine.UI;

public class MallFade : MonoBehaviour
{
    public float fadeSpeed = 1.0f;

    Image img;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.color = new Vector4(img.color.r, img.color.b, img.color.g, img.color.a - fadeSpeed * Time.deltaTime);
        if(img.color.a <= 0) {
            Destroy(gameObject);
        }
    }
}
