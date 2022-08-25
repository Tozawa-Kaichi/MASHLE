using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RenderTarget : MonoBehaviour
{
    // 描画したいレンダーテクスチャリスト    
    [SerializeField] RenderTexture[] writeTexList;
    // 残像を描画するイメージリスト   
    [SerializeField] RawImage[] imageList;
    int count = 0;  // フレームカウント変数   
    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        // レンダーテクスチャリストの内の一枚を最新の描画にセットする        
        _camera.targetTexture = writeTexList[count % writeTexList.Length];
        // 残像を描画するイメージリストを順番に入れ替えていく
        for (int i = 0; i < imageList.Length; i++)
        {
            int cal = (count % writeTexList.Length + i) % imageList.Length;
            imageList[i].texture = writeTexList[cal];
        }
    }
}
