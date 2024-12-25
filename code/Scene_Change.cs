//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Scene_Change : MonoBehaviour
//{
//    // ボタンに対応するシーン名をインスペクターから設定する
//    [SerializeField]
//    private string sceneName;

//    // ボタンが押されたときに呼ばれるメソッド
//    public void OnClickButton()
//    {
//        // シーン名を指定してシーンを遷移する
//        SceneManager.LoadScene(sceneName);
//    }
//}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


//[ViveInputUtility]

public class Scene_Change : MonoBehaviour

{

    [SerializeField]
    private string sceneName;
    // シーン切り替えのメソッド
    public void SwitchScene()
    {
        //SceneManager.MoveGameObjectToScene(GameObject.Find("[ViveInputUtility]"), SceneManager.GetActiveScene());

        // 切り替え先のシーン名を指定
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}