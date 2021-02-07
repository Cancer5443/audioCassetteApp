using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertScript : MonoBehaviour
{
    public GameObject scriptHolder;

    private void OnMouseUp()
    {
        scriptHolder.GetComponent<AudioControl>().Insert();
    }
}
