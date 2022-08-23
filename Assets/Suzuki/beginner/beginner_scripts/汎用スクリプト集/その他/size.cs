using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    [Header("起動時の画面サイズ")]
    [SerializeField]
    int size_x;
    [SerializeField]
    int size_y;
    bool fulltrg = false;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(size_x, size_y, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.F11 ))
        {
            if(!fulltrg)
            {
                fulltrg = true;
                Screen.SetResolution(1920, 1080, false);
            }
            else if(fulltrg)
            {
                fulltrg = false;
                Screen.SetResolution(1280, 720, false);
            }
        }
    }

}
