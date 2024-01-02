using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public Transform tr;
    public Camera cm;
    float sens = 5f;
    float yval;
    // Update is called once per frame
    void Update()
    {
        tr.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*sens,0));
        yval += Input.GetAxis("Mouse Y")*sens;
        yval = Mathf.Clamp(yval,-90f,90f);
        cm.transform.localRotation = Quaternion.Euler(-yval,0f,0f);
    }
}
