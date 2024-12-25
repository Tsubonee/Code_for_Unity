using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pre_Finish : MonoBehaviour
{

    //csvファイルのパス
    public string csvFilePath = @"C:\Users\hirom\OneDrive - 奈良先端科学技術大学院大学\Awe_Experiment\NO.1\trigger＿time.csv";

    private ECG[] Trigger;

    [SerializeField]
    private string sceneName;

    //シーン開始時に呼ばれる
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

    //毎フレーム呼ばれる
    private void Update()
    {
        //Enterキーが押されたかどうかをチェックする
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < Trigger.Length; i++)
            {
                Trigger[i].OnDestroy(); //シリアルポートをクローズする
            }

            // シーン再生を終了する
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //エディタ上でプレイ終了
#else
            Application.Quit(); //アプリケーション終了
#endif

        }
    }

}

