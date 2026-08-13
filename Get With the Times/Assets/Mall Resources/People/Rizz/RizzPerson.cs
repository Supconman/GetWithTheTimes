using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RizzPerson : NPCBase {

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
        childSprite.GetComponent<SpriteRenderer>().enabled = false;
        SceneManager.LoadScene("BattleScene");
    }

    //make the sprite face towards the camera
    private void LateUpdate() {
        spriteBehavior();
    }
}
