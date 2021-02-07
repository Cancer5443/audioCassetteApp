using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFScript : MonoBehaviour
{
    public GameObject scriptHolder;

    private void OnMouseUp()
    {
        scriptHolder.GetComponent<AudioControl>().FastForward();
    }
}
