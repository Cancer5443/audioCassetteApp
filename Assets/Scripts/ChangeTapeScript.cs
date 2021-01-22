using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTapeScript : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject cassette;
    private float rotateZ;
    private bool isDraging = false;
    private Vector3 aSitePossition = new Vector3(270f, 0f, 0f);
    private Vector3 bSitePossition = new Vector3(270f, 180f, 0f);
    private Vector3 currentPosition;
    private float cassetteY;
    public GameObject scriptHolder;

    private void OnMouseDrag()
    {
        isDraging = true;
        rotateZ = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;

        cassette.transform.Rotate(Vector3.back, rotateZ);
        currentPosition = cassette.transform.eulerAngles;
    }

    private void OnMouseUp()
    {
        cassetteY = cassette.transform.eulerAngles.y;
        if (cassetteY >= 90f && cassetteY <= 270f)
        {
            StartCoroutine("SetPositionB");
            scriptHolder.GetComponent<AudioControl>().SetAudioSourceB();
            Debug.Log("Set to B");
        }
        else
        {
            StartCoroutine("SetPositionA");
            scriptHolder.GetComponent<AudioControl>().SetAudioSourceA();
            Debug.Log("Setto A");
        }

        if (isDraging == false)
        {
            scriptHolder.GetComponent<AudioControl>().Insert();
        }
        isDraging = false;
        Debug.Log(currentPosition);
    }

    private IEnumerator SetPositionA()
    {
        currentPosition = cassette.transform.eulerAngles;
        while (isDraging == false && currentPosition != aSitePossition)
        {
            cassette.transform.Rotate(Vector3.back, 1f);
            yield return null;
        }
        cassette.transform.eulerAngles = aSitePossition;
    }

    private IEnumerator SetPositionB()
    {
        currentPosition = cassette.transform.eulerAngles;
        while (isDraging == false && currentPosition != bSitePossition)
        {
            cassette.transform.Rotate(Vector3.back, 1f);
            yield return null;
        }
        cassette.transform.eulerAngles = bSitePossition;
    }
}
