using UnityEngine;
using UnityEngine.InputSystem;

public class MallPlayerMove : MonoBehaviour
{

    float Yrotation;
    public float Sensitivity;

    Rigidbody body;
    public float speed = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        body = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Sensitivity;

        //calculate rotation
        Yrotation += mouseX;

        //perform rotation (only y rotation, camera is the only thing that does x rotation)
        transform.rotation = Quaternion.Euler(0, Yrotation, 0);

        //get WSAD input and move
        if (Keyboard.current != null) {

            if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed) {
                body.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Acceleration); 
            }
            if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed) {
                body.AddRelativeForce(Vector3.back * speed * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) {
                body.AddRelativeForce(Vector3.left * speed * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
                body.AddRelativeForce(Vector3.right * speed * Time.deltaTime, ForceMode.Acceleration);
            }
        }

        //Failcase for out of bounds.
        if(transform.position.y < -50.0f) {
            transform.position = new Vector3(0, 2, 0);
        }


    }
}
