using UnityEngine;

public class MallCamMove : MonoBehaviour
{
    public GameObject player;

    float Xrotation;

    public float Sensitivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get input
        float mouseY = Input.GetAxisRaw("Mouse Y")  * Sensitivity;

        //calculate rotation
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -50.0f, 50.0f);

        
    }

    private void LateUpdate() {
        //perform rotation (including copying player y rotation)
        transform.rotation = Quaternion.Euler(Xrotation, player.transform.rotation.eulerAngles.y, 0);

        //Move camera to player position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z);
    }
}
