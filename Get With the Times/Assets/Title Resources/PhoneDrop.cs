using UnityEngine;

public class PhoneDrop : MonoBehaviour
{
    Rigidbody body;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(Random.Range(0.2f,-0.2f), -0.3f, 0),ForceMode.Impulse);
        body.AddTorque(new Vector3(0, Random.Range(0.5f, -0.5f), 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 15.0f || transform.position.x <= -15.0f || transform.position.y >= 15.0f || transform.position.y <= -15.0f) {
            Destroy(gameObject);
        }
    }
}
