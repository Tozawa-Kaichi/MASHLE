using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StageController
{
    [SerializeField] GameObject _zakoDeathEffect;
    [SerializeField] bool _air=false;
    void Update()
    {
        DestroyOverTheLine();
        if (_air)
        {
            StageMove();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_zakoDeathEffect,this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
