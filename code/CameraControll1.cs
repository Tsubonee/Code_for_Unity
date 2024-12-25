using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll1 : MonoBehaviour
{

    private GameObject mainCamera;      //���C���J�����i�[�p
    private GameObject subCamera;       //�T�u�J�����i�[�p 
    private GameObject avatar;          //�A�o�^�[�i�[�p
    private Renderer[] renderers;       //�A�o�^�[�̃����_�[�i�[�p


    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J���������ꂼ��擾
        mainCamera = GameObject.Find("CenterEyeAnchor");
        subCamera = GameObject.Find("CenterEyeAnchor_3pp");

        //�T�u�J�������A�N�e�B�u�ɂ���
        subCamera.SetActive(false);

        //�A�o�^�[���擾
        avatar = GameObject.Find("avator");

        //�A�o�^�[�̃����_�[���擾
        renderers = avatar.GetComponentsInChildren<Renderer>();
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        //�X�y�[�X�L�[��������Ă���ԁA�T�u�J�������A�N�e�B�u�ɂ���
        if (Input.GetKey("space"))
        {
            //�T�u�J�������A�N�e�B�u�ɐݒ�
            mainCamera.SetActive(false);
            Debug.Log("Hello");
            subCamera.SetActive(true);

            //�ځA���A���A���̃����_�[���I���ɂ���
            foreach (Renderer r in renderers)
            {
                if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                {
                    r.enabled = true;
                    r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; //�e�𓊉e���郂�[�h�ɕύX
                }
            }
        }
        else
        {
            //���C���J�������A�N�e�B�u�ɐݒ�
            subCamera.SetActive(false);
            mainCamera.SetActive(true);

            //�ځA���A���A���̃����_�[�̓I�t�ɂ��Ȃ����A�e�������e���郂�[�h�ɕύX����
            foreach (Renderer r in renderers)
            {
                if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                {
                    r.enabled = true;
                    r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //�e�������e���郂�[�h�ɕύX
                }
            }
        }
    }
}