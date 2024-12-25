using UnityEngine;
using System.IO; // CSVファイルを扱うために必要
using System; // DateTimeを扱うために必要

public class Pass_csv : MonoBehaviour
{
    // トリガーに触れたオブジェクト（Inspectorウィンドウから設定）
    public Collider other;
    // CSVファイルの保存先（Inspectorウィンドウから設定）
    public string csvFilePath = @"C:\Users\hirom\OneDrive - 奈良先端科学技術大学院大学\My_exp\csvfile\other_pass_time.csv";

    void Start()
    {
        // CSVファイルが存在しない場合は新規作成する
        if (!File.Exists(csvFilePath))
        {
            // ヘッダー行を書き込む
            File.WriteAllText(csvFilePath, "Player,Time\n");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // トリガーに触れたオブジェクトがプレイヤーなら
        if (other == this.other)
        {
            // 現在時刻を取得する
            string currentTime = DateTime.Now.ToString("o");
            // プレイヤーの名前を取得する
            string playerName = other.name;
            // CSVファイルに追記する
            File.AppendAllText(csvFilePath, $"{playerName},{currentTime}\n");
        }
    }
}
