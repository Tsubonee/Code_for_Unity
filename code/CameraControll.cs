using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    private GameObject mainCamera;      //���C���J�����i�[�p
    private GameObject subCamera;       //�T�u�J�����i�[�p 


    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J���������ꂼ��擾
        mainCamera = GameObject.Find("CenterEyeAnchor");
        subCamera = GameObject.Find("CenterEyeAnchor_3pp");

        //�T�u�J�������A�N�e�B�u�ɂ���
        subCamera.SetActive(false);
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        //A�{�^���������ꂽ��
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            //���_��؂�ւ���
            SwitchView();
        }
    }

    //���_��؂�ւ���֐�
    private void SwitchView()
    {
        //���݂̎��_��3�l�̂Ȃ�
        if (subCamera.activeSelf)
        {
            //1�l�̎��_�ɂ���
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
        //���݂̎��_��1�l�̂Ȃ�
        else
        {
            //3�l�̎��_�ɂ���
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }
    }
}
