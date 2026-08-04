using UnityEditor.UI;
using UnityEngine;

public class Man : NPCBase {

    public float speakPitch = 100.0f;
    public bool visited = false;
    public int attempted = 0; 

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
        if (visited) {
            Destroy(gameObject);
        }
    }

    //interaction behavior
    public override void interactBehavior(Collider other) {

        if (Random.Range(1, 30) <= attempted) {
            GameObject.Find("Player Collision").transform.position = new Vector3(67670,400,0);
        }
        else {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-2.0f, 3.0f), Random.Range(-5.0f, 5.0f))), ForceMode.Impulse);
            if (base.hasSprite) {
                base.childSprite.GetComponent<Animator>().enabled = true;
            }
        }
        attempted++;
    }

    //make the sprite face towards the camera
    private void LateUpdate() {
        spriteBehavior();
    }
}
