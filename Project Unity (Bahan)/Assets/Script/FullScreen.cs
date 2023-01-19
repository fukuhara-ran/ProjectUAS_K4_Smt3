using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("changed fullscreen mode");
    }
}
