using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("CenterEyeAnchor");
        subCamera = GameObject.Find("CenterEyeAnchor_3pp");

        //サブカメラを非アクティブにする
        subCamera.SetActive(false);
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        //Aボタンが押されたら
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            //視点を切り替える
            SwitchView();
        }
    }

    //視点を切り替える関数
    private void SwitchView()
    {
        //現在の視点が3人称なら
        if (subCamera.activeSelf)
        {
            //1人称視点にする
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
        //現在の視点が1人称なら
        else
        {
            //3人称視点にする
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }
    }
}
