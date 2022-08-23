using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startChild : MonoBehaviour
{
    [Header("開始時に親子関係解除")]
    string test = "";
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
