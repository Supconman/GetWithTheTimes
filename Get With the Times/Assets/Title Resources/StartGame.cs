using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public bool allowStart = false;
    bool clickedToStart = false;

    public float startingTime = 0;
    float timer;

    Material screen;

    public float redFadeDelay = 2.0f;
    public float redFadeSpeed = 1.0f;
    bool sentRedSignal = false;
    public GameObject recordText1;
    public GameObject recordText2;
    float curIntensity = 0;

    public float blackFadeDelay = 8.0f;
    public float blackFadeSpeed = 1.0f;
    public float musicFadeSpeed = 10.0f;

    public float sceneTransitionDelay = 15.0f;

    public AudioClip cameraSnap;
    AudioSource bgm;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = startingTime;
        bgm = GetComponent<AudioSource>();
        screen = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update() {

        //wait for input
        if (allowStart && !clickedToStart && Keyboard.current != null) {
            if (Keyboard.current.spaceKey.isPressed || Input.GetMouseButtonDown(0)) {
                clickedToStart = true;
                AudioSource.PlayClipAtPoint(cameraSnap, new Vector3(0,0,-7));
            }
        }

        //transition sequence
        if (clickedToStart) {
            if (!sentRedSignal) {
                recordText1.GetComponent<MetaTextTurnOn>().lightUp = true;
                recordText2.GetComponent<MetaTextTurnOn>().lightUp = true;
                sentRedSignal = true;
            }

            if (timer >= sceneTransitionDelay) {
                SceneManager.LoadScene("NarrationScene");
            }
            else if (timer >= redFadeDelay && timer <= blackFadeDelay && curIntensity < 1.0f) {
                curIntensity += redFadeSpeed * Time.deltaTime; 
                screen.SetFloat("_Intensity",curIntensity); 
            }
            else if (timer >= blackFadeDelay) {
                screen.SetFloat("_Alpha", 1);

                curIntensity -= blackFadeSpeed * Time.deltaTime;
                screen.SetFloat("_Intensity", curIntensity);

                bgm.volume -= musicFadeSpeed*Time.deltaTime;
            }

            timer += Time.deltaTime;
        }

    }

    public void turnStartOn() {
        allowStart = true; 
    }

}
