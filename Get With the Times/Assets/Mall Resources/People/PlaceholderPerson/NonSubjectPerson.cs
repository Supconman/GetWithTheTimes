using UnityEditor.UI;
using UnityEngine;

public class NonSubjectPerson : NPCBase {

    public float speakPitch = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        NPCInit(); 

        if(speakPitch == 100.0f) {
            speakPitch = Random.Range(0.5f, 1.5f);
        }
        gameObject.GetComponent<AudioSource>().pitch = speakPitch;
    }

    // Update is called once per frame
    void Update() {
        roamTick(); 
    }

    //interaction behavior
    public override void interactBehavior(Collider other) {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-2.0f, 3.0f), Random.Range(-5.0f, 5.0f))), ForceMode.Impulse);
        if (base.hasSprite) {
            base.childSprite.GetComponent<Animator>().enabled = true; 
        }
    }

    //make the sprite face towards the camera
    private void LateUpdate() {
        spriteBehavior();
    }
}
