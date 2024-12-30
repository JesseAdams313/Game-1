using UnityEngine;

public class SpinTarget : MonoBehaviour
{
    [Header("Spin Settings")]
    public bool isSpinning = false;     // Tracks if currently spinning

    [Header("Rotation Settings (degrees / sec)")]
    [Tooltip("Speed at which the object spins around the X-axis (degrees per second).")]
    public float spinSpeedX = 0;      // Degrees per second
    [Tooltip("Speed at which the object spins around the Y-axis (degrees per second).")]
    public float spinSpeedY = 180f;      // Degrees per second
    [Tooltip("Speed at which the object spins around the Z-axis (degrees per second).")]
    public float spinSpeedZ = 0;      // Degrees per second


    //public float spinSpeed = 180f;      // Degrees per second

    void Update()
    {
        if (isSpinning)
        {
            //apply rotation based on the each axis's spin speed
            float xRotation = spinSpeedX * Time.deltaTime;
            float yRotation = spinSpeedY * Time.deltaTime;
            float zRotation = spinSpeedZ * Time.deltaTime;

            // Rotate the object around the X, Y, and Z axes
            transform.Rotate(xRotation, yRotation, zRotation);

        }

    }

    // Called by the CameraInteraction script
    public void ToggleSpin()
    {
        isSpinning = !isSpinning;  // Flip the bool
    }
}
