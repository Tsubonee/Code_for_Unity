using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll1 : MonoBehaviour
{

    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 
    private GameObject avatar;          //アバター格納用
    private Renderer[] renderers;       //アバターのレンダー格納用


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("CenterEyeAnchor");
        subCamera = GameObject.Find("CenterEyeAnchor_3pp");

        //サブカメラを非アクティブにする
        subCamera.SetActive(false);

        //アバターを取得
        avatar = GameObject.Find("avator");

        //アバターのレンダーを取得
        renderers = avatar.GetComponentsInChildren<Renderer>();
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        //スペースキーが押されている間、サブカメラをアクティブにする
        if (Input.GetKey("space"))
        {
            //サブカメラをアクティブに設定
            mainCamera.SetActive(false);
            Debug.Log("Hello");
            subCamera.SetActive(true);

            //目、頭、歯、髪のレンダーをオンにする
            foreach (Renderer r in renderers)
            {
                if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                {
                    r.enabled = true;
                    r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; //影を投影するモードに変更
                }
            }
        }
        else
        {
            //メインカメラをアクティブに設定
            subCamera.SetActive(false);
            mainCamera.SetActive(true);

            //目、頭、歯、髪のレンダーはオフにしないが、影だけ投影するモードに変更する
            foreach (Renderer r in renderers)
            {
                if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                {
                    r.enabled = true;
                    r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //影だけ投影するモードに変更
                }
            }
        }
    }
}