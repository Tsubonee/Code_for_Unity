using UnityEngine;
using System.IO;
using System;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class SceneEnd : MonoBehaviour
{
    //csvファイルのパス
    public string csvFilePath = @"C:\Users\hirom\OneDrive - 奈良先端科学技術大学院大学\My_exp\other\trigger＿time.csv";

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
        //スペースキーが押されたかどうかをチェックする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sendTrigger(); //トリガー信号を送る

            //シーン終了時の時間を取得
            string endTime = DateTime.Now.ToString("o");

            // CSVファイルに追記する
            File.AppendAllText(csvFilePath, $"Finish,{endTime}\n");

            if (GameObject.Find("[VRModule]") != null)
            {
                Destroy(GameObject.Find("[VRModule]"));
                Destroy(GameObject.Find("ViveRig"));

            }

            // 切り替え先のシーン名を指定
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);


        }

//        //1のキーが押されたかどうかをチェックする（変更点）
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {

//            sendTrigger(); //トリガー信号を送る

//            //シーン終了時の時間を取得
//            string endTime = DateTime.Now.ToString("o");

//            // CSVファイルに追記する
//            File.AppendAllText(csvFilePath, $"Finish,{endTime}\n");

//            for (int i = 0; i < Trigger.Length; i++)
//            {
//                Trigger[i].OnDestroy(); //シリアルポートをクローズする
//            }

//            // シーン再生を終了する
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false; //エディタ上でプレイ終了
//#else
//            Application.Quit(); //アプリケーション終了
//#endif

//        }
    }

}
