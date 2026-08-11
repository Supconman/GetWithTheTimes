using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RizzPerson : NPCBase {

    public float speakPitch = 100.0f;
    bool changingScene = false;
    bool changingSceneWaitOne = true; 

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
        changingScene = true;
        changingSceneWaitOne = true;
    }

    //make the sprite face towards the camera
    private void LateUpdate() {
        spriteBehavior();
        if (changingScene && !changingSceneWaitOne) {
            //I'm not cleaning this texture up, since we'll only have like 5 of them, but be aware of that in case this use case expands.  
            GlobalManager.globalInstance.battleBackground = ScreenCapture.CaptureScreenshotAsTexture();
            GlobalManager.globalInstance.battleBackground.Apply();

            SceneManager.LoadScene("BattleScene");

            changingScene = false; 
        }
        else if (changingScene) {
            childSprite.GetComponent<SpriteRenderer>().enabled = false;
            changingSceneWaitOne = false; 
        }
    }
}
