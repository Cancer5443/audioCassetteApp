using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    public float rotateSpeed;
    private float rotateZ;
    private float volumeAngle;
    private float rotationz;

    public void Update()
    {
        volumeAngle = transform.eulerAngles.z;
    }

    private void OnMouseDrag()
    {
        rotateZ = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;
        rotationz = volumeAngle + rotateZ;

        if (rotationz > 0 && rotationz < 180)
        {
            transform.Rotate(Vector3.forward, rotateZ);
        }
        else if (rotationz <= 0)
        {
            transform.Rotate(Vector3.forward, 1f);
            volumeAngle = 1;
        }
        else if (rotationz >= 180)
        {
            transform.Rotate(Vector3.forward, 179f);
            volumeAngle = 179;
        }
    }
}
