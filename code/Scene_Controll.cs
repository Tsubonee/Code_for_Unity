using UnityEngine;
using System.IO; // CSVファイルを扱うために必要
using System; // DateTimeを扱うために必要
using UnityEngine.SceneManagement; // シーンを遷移するために必要
using System.IO.Ports; // シリアルポートを扱うために必要
using System.Collections;

public class Scene_Controll : MonoBehaviour
{
    // 非表示にするオブジェクト
    public GameObject targetObject;
    // 非表示にするまでの時間（秒）
    public float delayTime = 30f;
    // シーンを遷移するまでの時間（秒）
    public float timeToChange = 120f;
    // 遷移するシーンの名前
    public string sceneToChange = "Menu";
    // CSVファイルの保存先
    public string csvFilePath = @"C:\Users\hirom\OneDrive - 奈良先端科学技術大学院大学\My_exp\csvfile\other_trigger.csv";

    // 追加: Audio Sourceオブジェクトを参照する変数
    public GameObject audioSourceObject;
    private AudioSource audioSource;
    // 終了


    private ECG[] Trigger;
    

    void Awake()
    {
        
    }

    void sendTrigger()
    {
        for (int i = 0; i < Trigger.Length; i++)
        {
            Trigger[i].OnClickButton();
        }
    }

    void Start()
    {
        Shimmer();



        // CSVファイルが存在しない場合は新規作成する
        if (!File.Exists(csvFilePath))
        {
            // ヘッダー行を書き込む
            File.WriteAllText(csvFilePath, "Event,Time\n");
        }
        // 開始時刻を取得する
        string startTime = DateTime.Now.ToString("o");
        // CSVファイルに追記する
        File.AppendAllText(csvFilePath, $"Start,{startTime}\n");
        // OnSerialTrigger(1)関数を呼び出す
        sendTrigger();
        // 非表示にするコルーチンを開始
        StartCoroutine(HideAfterDelay());
        // シーンを遷移するコルーチンを開始
        StartCoroutine(ChangeAfterDelay());

    }

    void Shimmer()
    {
        // 追加: Audio Sourceコンポーネントを取得し、falseに設定する
        if (audioSourceObject != null) // Audio SourceオブジェクトがNoneでないかチェックする
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
            audioSource.enabled = false;
        }
        // 終了

        GameObject ecg = GameObject.Find("Shimmer");
        Trigger = ecg.GetComponentsInChildren<ECG>();

    }

    private void DisableVRModule()
    {
        if (GameObject.Find("[VRModule]") != null)
        {
            GameObject.Find("[VRModule]").SetActive(false);
        }
    }

    // 非表示にするコルーチン
    IEnumerator HideAfterDelay()
    {
        // 指定した時間だけ待つ
        yield return new WaitForSeconds(delayTime);
        // オブジェクトを非表示にする
        targetObject.SetActive(false);
        string hideTime = DateTime.Now.ToString("o");
        // CSVファイルに追記する
        File.AppendAllText(csvFilePath, $"Hide,{hideTime}\n");
        // OnSerialTrigger(1)関数を呼び出す
        sendTrigger();

        // 追加: Audio Sourceコンポーネントをtrueに設定する
        if (audioSource != null) // Audio SourceコンポーネントがNoneでないかチェックする
        {
            audioSource.enabled = true;
        }

        // 終了
    }

    // シーンを遷移するコルーチン
    IEnumerator ChangeAfterDelay()
    {
        // 指定した時間だけ待つ
        yield return new WaitForSeconds(timeToChange);
        // 遷移時刻を取得する
        string changeTime = DateTime.Now.ToString("o");
        // CSVファイルに追記する
        File.AppendAllText(csvFilePath, $"Change,{changeTime}\n");
        // OnSerialTrigger(1)関数を呼び出す
        sendTrigger();


        // シーンを遷移する
        SceneManager.LoadScene(sceneToChange);
    }

}
