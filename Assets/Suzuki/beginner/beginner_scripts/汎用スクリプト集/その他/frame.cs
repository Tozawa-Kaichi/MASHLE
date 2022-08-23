using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("フレームレートを起動時指定")]
    int _frame = 60;
    void Start()
    {
        Application.targetFrameRate = _frame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
