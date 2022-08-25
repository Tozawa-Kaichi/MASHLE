using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RenderTarget : MonoBehaviour
{
    // �`�悵���������_�[�e�N�X�`�����X�g    
    [SerializeField] RenderTexture[] writeTexList;
    // �c����`�悷��C���[�W���X�g   
    [SerializeField] RawImage[] imageList;
    int count = 0;  // �t���[���J�E���g�ϐ�   
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
        // �����_�[�e�N�X�`�����X�g�̓��̈ꖇ���ŐV�̕`��ɃZ�b�g����        
        _camera.targetTexture = writeTexList[count % writeTexList.Length];
        // �c����`�悷��C���[�W���X�g�����Ԃɓ���ւ��Ă���
        for (int i = 0; i < imageList.Length; i++)
        {
            int cal = (count % writeTexList.Length + i) % imageList.Length;
            imageList[i].texture = writeTexList[cal];
        }
    }
}
