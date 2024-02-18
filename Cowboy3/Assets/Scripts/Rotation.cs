using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class Rotation : MonoBehaviour
{
    public float rotationX;
    public float minRotX;
    public float maxRotX;
    public float mouseX;
    public float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minRotX, maxRotX);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
