using UnityEngine;

public class NonSubjectSprite : MonoBehaviour
{
    GameObject mainCamera;

    Rigidbody ParentBody;
    Animator moveAnim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.Find("PlayerCamera");

        ParentBody = transform.parent.GetComponent<Rigidbody>();
        moveAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate() {
        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
    }
}
