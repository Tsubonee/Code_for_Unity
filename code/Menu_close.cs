using UnityEngine;
using System.IO;
using System;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Menu_close : MonoBehaviour
{

    private ECG[] Trigger;

    //シーン開始時に呼ばれる
    void Awake()
    {
        GameObject ecg = GameObject.Find("Shimmer");
        Trigger = ecg.GetComponentsInChildren<ECG>();
    }


    //毎フレーム呼ばれる
    private void Update()
    {
        //スペースキーが押されたかどうかをチェックする
        if (Input.GetKeyDown(KeyCode.AltGr))
        {

            if (GameObject.Find("[VRModule]") != null)
            {
                Destroy(GameObject.Find("[VRModule]"));
                Destroy(GameObject.Find("ViveRig"));

            }

            for (int i = 0; i < Trigger.Length; i++)
            {
                Trigger[i].OnDestroy(); //シリアルポートをクローズする
            }
        }
    }

}
