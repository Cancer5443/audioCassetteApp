using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    private Animator menu;
    void Start()
    {
        menu = this.gameObject.GetComponent<Animator>();
    }

    public void OpenMenu()
    {
        menu.SetTrigger("OpenMenu");
    }

    public void CloseMunu()
    {
        menu.SetTrigger("CloseMenu");
    }
}
