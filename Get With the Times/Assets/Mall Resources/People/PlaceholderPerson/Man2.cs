using UnityEditor.UI;
using UnityEngine;

public class Man2 : NPCBase {

    public bool interacted = false;
    public bool recieved = false;
    public Sprite egg; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        NPCInit();
        transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;

        if (GlobalManager.globalInstance.egg) {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y <= -400) {
            Destroy(gameObject);
        }
    }

    //interaction behavior
    public override void interactBehavior(Collider other) {
        if (!interacted) {
            gameObject.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(10000.0f, 20000.0f), Random.Range(-500.0f, 500.0f))), ForceMode.Impulse);
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = egg;
            interacted = true; 
        }
        else if (!recieved) {
            gameObject.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-5000.0f, 5000.0f), Random.Range(10.0f, 10.0f), Random.Range(-5000.0f, 5000.0f))), ForceMode.Impulse);
            gameObject.GetComponent<AudioSource>().Play();
            recieved = true;
            GlobalManager.globalInstance.egg = true; 
        }
        else {
            Destroy(gameObject);
        }

    }

    //make the sprite face towards the camera
    private void LateUpdate() {
        spriteBehavior();
    }
}
