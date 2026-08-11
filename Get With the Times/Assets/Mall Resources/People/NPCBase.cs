using UnityEngine;
using System.Collections.Generic;

public class NPCBase : MonoBehaviour {
    //for roaming behavior
    public bool roams = true;
    public Vector3 homeLocation = Vector3.zero;
    public float stopMax = 5.0f;
    public float moveMax = 10.0f;
    public float roamSpeed = 1.0f;
    public float roamMaxDist = 10.0f;
    [HideInInspector] public Vector3 destination = Vector3.zero;
    [HideInInspector] public float roamTimer = 0;
    [HideInInspector] public bool walking = false;


    //for making the child a billboard
    public bool hasSprite = true;
    GameObject mainCamera;
    [HideInInspector] public GameObject childSprite;

    //for making actors only appear on specified days
    public List<int> daysToAppearOn = new List<int>() { 0, 1, 2, 3, 4, 5 };

    public virtual void NPCInit() {

        if (!daysToAppearOn.Contains(GlobalManager.globalInstance.day)) {
            Destroy(gameObject);
        }

        if (roams) {
            if (homeLocation.Equals(Vector3.zero)) {
                homeLocation = transform.position;
            }
            destination = homeLocation;
        }


        if (hasSprite) {
            mainCamera = GameObject.Find("PlayerCamera");
            childSprite = transform.GetChild(0).gameObject;
            childSprite.GetComponent<Animator>().enabled = false;
        }
    }

    //for handling interactions 
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Interact") {
            interactBehavior(other);
        }
    }
    //as above
    public virtual void interactBehavior(Collider other) {

    }

    //for making the sprite face the camera
    public virtual void spriteBehavior() {
        if (hasSprite) {
            childSprite.transform.LookAt(new Vector3(mainCamera.transform.position.x, childSprite.transform.position.y, mainCamera.transform.position.z));
        }
    }

    //for making the NPC's 'Randomly' walk around the mall
    public virtual void roamTick() {
        //changing states
        if (!walking && roamTimer <= 0) {
            roamPickTarget();
        }
        else if (walking && roamTimer <= 0) {
            roamStop();
        }
        else if (roamTimer <= 0) {
            Debug.Log("Check The Roam Code, walking bool isn't set properly");
            roamTimer = 10.0f;
        }
        //performing state actions
        else if (!walking) {
            roamIdle();
        }
        else if (walking) {
            roamWalk();
        }
        else {
            Debug.Log("How tf did you activate this?");
        }
    }

    public virtual void roamPickTarget() {
        destination = new Vector3(homeLocation.x + Random.Range(-roamMaxDist, roamMaxDist), 0, homeLocation.z + Random.Range(-roamMaxDist, roamMaxDist));

        roamTimer = Random.Range(0, moveMax);
        walking = true;

        if (hasSprite) {
            childSprite.GetComponent<Animator>().enabled = true; 
        }
    }

    public virtual void roamStop() {
        roamTimer = Random.Range(0, stopMax);
        walking = false;

        if (hasSprite) {
            childSprite.GetComponent<Animator>().enabled = false;
        }
    }

    public virtual void roamIdle() {
        roamTimer -= Time.deltaTime;
    }

    public virtual void roamWalk() {

        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(destination.x - transform.position.x, 0, destination.z - transform.position.z) * roamSpeed*Time.deltaTime,ForceMode.Impulse);
        roamTimer -= Time.deltaTime;
    }
    


}
