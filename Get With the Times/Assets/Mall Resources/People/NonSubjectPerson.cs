using UnityEditor.UI;
using UnityEngine;

public class NonSubjectPerson : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    //interaction behavior
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Interact") {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5.0f,5.0f), Random.Range(-2.0f, 3.0f), Random.Range(-5.0f, 5.0f)), ForceMode.Impulse);
            Debug.Log("Interaction");
        }
        
    }
}
