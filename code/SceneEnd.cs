using UnityEngine;
using System.IO;
using System;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class SceneEnd : MonoBehaviour
{
    //csv�t�@�C���̃p�X
    public string csvFilePath = @"C:\Users\hirom\OneDrive - �ޗǐ�[�Ȋw�Z�p��w�@��w\My_exp\other\trigger�Qtime.csv";

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
        //�X�y�[�X�L�[�������ꂽ���ǂ������`�F�b�N����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sendTrigger(); //�g���K�[�M���𑗂�

            //�V�[���I�����̎��Ԃ��擾
            string endTime = DateTime.Now.ToString("o");

            // CSV�t�@�C���ɒǋL����
            File.AppendAllText(csvFilePath, $"Finish,{endTime}\n");

            if (GameObject.Find("[VRModule]") != null)
            {
                Destroy(GameObject.Find("[VRModule]"));
                Destroy(GameObject.Find("ViveRig"));

            }

            // �؂�ւ���̃V�[�������w��
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);


        }

//        //1�̃L�[�������ꂽ���ǂ������`�F�b�N����i�ύX�_�j
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {

//            sendTrigger(); //�g���K�[�M���𑗂�

//            //�V�[���I�����̎��Ԃ��擾
//            string endTime = DateTime.Now.ToString("o");

//            // CSV�t�@�C���ɒǋL����
//            File.AppendAllText(csvFilePath, $"Finish,{endTime}\n");

//            for (int i = 0; i < Trigger.Length; i++)
//            {
//                Trigger[i].OnDestroy(); //�V���A���|�[�g���N���[�Y����
//            }

//            // �V�[���Đ����I������
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false; //�G�f�B�^��Ńv���C�I��
//#else
//            Application.Quit(); //�A�v���P�[�V�����I��
//#endif

//        }
    }

}
