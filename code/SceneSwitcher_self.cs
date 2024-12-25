using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理の機能を使うために必要

public class SceneSwitcher_self : MonoBehaviour
{
    // シーン再生中に呼ばれるメソッド
    void Update()
    {
        // スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Menuシーンに切り替える
            SceneManager.LoadScene("Menu");
        }
    }
}
