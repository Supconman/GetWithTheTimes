using UnityEngine;
using UnityEngine.InputSystem;

public class MallInteract : MonoBehaviour
{

    public bool debug = false;
    public float cooldownMax = 0.2f;
    public float interactDisappear = 0.19f;
    float curCooldown = 0.0f;
    bool currentlyActive = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (Keyboard.current != null && (Keyboard.current.spaceKey.wasPressedThisFrame || Input.GetMouseButtonDown(0)) && curCooldown <= 0.0f && !currentlyActive) {
            currentlyActive = true;
            if (debug) {
                GetComponent<Renderer>().enabled = true;
            }
            GetComponent<Collider>().enabled = true;
            curCooldown = cooldownMax;
        }
        else if(currentlyActive && curCooldown <= interactDisappear) {
            currentlyActive = false;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        else if(curCooldown > 0.0f) {
            curCooldown -= Time.deltaTime; 
        }
    }
}
