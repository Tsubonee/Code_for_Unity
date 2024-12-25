using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    // タイマー
    private float timer;
    // タイマーを開始するかどうか
    private bool startTimer;
    // トリガーに触れたオブジェクト（Inspectorウィンドウから設定）
    public Collider other;
    // シーンを切り替えるまでの時間（Inspectorウィンドウから設定）
    public float timeToChange = 30f;
    // 遷移するシーンの名前（Inspectorウィンドウから設定）
    public string sceneToChange = "MenuScene";

    void Start()
    {
        // タイマーを0に初期化
        timer = 0f;
        // タイマーを開始しない
        startTimer = false;
    }

    void Update()
    {
        // タイマーが開始されたら
        if (startTimer)
        {
            // タイマーを増やす
            timer += Time.deltaTime;
            // タイマーがtimeToChange以上になったら
            if (timer >= timeToChange)
            {
                // sceneToChangeに遷移する
                SceneManager.LoadScene(sceneToChange);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // トリガーに触れたオブジェクトがプレイヤーなら
        if (other == this.other)
        {
            // タイマーを開始する
            startTimer = true;
        }
    }
}