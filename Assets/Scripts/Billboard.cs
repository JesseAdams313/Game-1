using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Transform cameraTransform;




void Start()
    {
        //find the main camera in the scene
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraTransform != null)
        {
            //make the object look at the camera
            Quaternion targetRotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
        }
    }
}
