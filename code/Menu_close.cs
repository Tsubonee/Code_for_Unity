using UnityEngine;
using System.IO;
using System;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Menu_close : MonoBehaviour
{

    private ECG[] Trigger;

    //�V�[���J�n���ɌĂ΂��
    void Awake()
    {
        GameObject ecg = GameObject.Find("Shimmer");
        Trigger = ecg.GetComponentsInChildren<ECG>();
    }


    //���t���[���Ă΂��
    private void Update()
    {
        //�X�y�[�X�L�[�������ꂽ���ǂ������`�F�b�N����
        if (Input.GetKeyDown(KeyCode.AltGr))
        {

            if (GameObject.Find("[VRModule]") != null)
            {
                Destroy(GameObject.Find("[VRModule]"));
                Destroy(GameObject.Find("ViveRig"));

            }

            for (int i = 0; i < Trigger.Length; i++)
            {
                Trigger[i].OnDestroy(); //�V���A���|�[�g���N���[�Y����
            }
        }
    }

}
