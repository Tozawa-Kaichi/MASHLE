using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundM : MonoBehaviour
{
    [Header("[効果音マネージャー]\nここに予めセットし、マネージャーから\nGManager.instance.setrgで指定して再生")]
    [SerializeField]
    AudioClip[] se;

    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetKeyDown (KeyCode.Delete))//セーブデータをおまけで破壊できる
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        if( GManager.instance.ase != null)//aseにaudioclipを格納すると再生されるおまけ
        {
            audioS.PlayOneShot(GManager.instance.ase);
            GManager.instance.ase = null;
        }
        else if( GManager.instance.setrg != -1 && GManager.instance.setrg != 99)//ここで再生
        {
            audioS.PlayOneShot(se[GManager.instance.setrg]);
            GManager.instance.setrg = -1;
        }
    }

}
