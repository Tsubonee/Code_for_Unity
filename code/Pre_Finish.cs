using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pre_Finish : MonoBehaviour
{

    //csv�t�@�C���̃p�X
    public string csvFilePath = @"C:\Users\hirom\OneDrive - �ޗǐ�[�Ȋw�Z�p��w�@��w\Awe_Experiment\NO.1\trigger�Qtime.csv";

    private ECG[] Trigger;

    [SerializeField]
    private string sceneName;

    //�V�[���J�n���ɌĂ΂��
    void Awake()
    {
        GameObject ecg = GameObject.Find("Shimmer");
        Trigger = ecg.GetComponentsInChildren<ECG>();
    }

    void sendTrigger()
    {
        for (int i = 0; i < Trigger.Length; i++)
        {
            Trigger[i].OnClickButton();
        }
    }

    //���t���[���Ă΂��
    private void Update()
    {
        //Enter�L�[�������ꂽ���ǂ������`�F�b�N����
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < Trigger.Length; i++)
            {
                Trigger[i].OnDestroy(); //�V���A���|�[�g���N���[�Y����
            }

            // �V�[���Đ����I������
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //�G�f�B�^��Ńv���C�I��
#else
            Application.Quit(); //�A�v���P�[�V�����I��
#endif

        }
    }

}

