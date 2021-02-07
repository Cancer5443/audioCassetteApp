using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject gimbleX;
    //public GameObject gimbleY;
    private float rotateX;
    private float rotateY;
    private bool isDraging = false;
    private Vector3 startPosition = new Vector3 (0f, 0f, 0f);
    private Vector3 currentPosition;

    private void OnMouseDrag()
    {
        rotateX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        rotateY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        gimbleX.transform.Rotate(Vector3.up, -rotateX);
        gimbleX.transform.Rotate(Vector3.right, rotateY);
    }

    private void OnMoudeDown()
    {
        isDraging = true;
    }

    private void OnMouseUp()
    {
        isDraging = false;
        StartCoroutine("ResetPosition");
    }

    private IEnumerator ResetPosition()
    {
        currentPosition = gimbleX.transform.eulerAngles;
        while (isDraging == false && startPosition == currentPosition)
        {
            gimbleX.transform.Rotate(startPosition, 0.1f);
            yield return null;
        }
        gimbleX.transform.eulerAngles = startPosition;
    }

}
