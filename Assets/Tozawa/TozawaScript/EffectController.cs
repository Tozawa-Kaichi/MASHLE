using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] float _lifeTime = 0;
    // Start is called before the first frame update

    private void Start()
    {
        Destroy(this.gameObject, _lifeTime);
    }
}
