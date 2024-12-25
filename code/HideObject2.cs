using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideObject2 : MonoBehaviour
{
    // 非表示にするオブジェクト
    public GameObject targetObject;

    // 非表示にするまでの時間（秒）
    public float delayTime = 60f;

    // アバターのレンダラーの配列
    private Renderer[] renderers;

    // Start is called before the first frame update
    void Start()
    {
        //// アバターのレンダラーを取得
        //renderers = targetObject.GetComponentsInChildren<Renderer>();

        //// アバターのレンダーをすべてオフにする
        //foreach (Renderer r in renderers)
        //{
        //    r.enabled = false;
        //}
        //Debug.Log("11111111");

        //// 非表示にするコルーチンを開始
        //StartCoroutine(HideAfterDelay());
    }

    // 非表示にするコルーチン
    IEnumerator HideAfterDelay()
    {
        // 指定した時間だけ待つ
        yield return new WaitForSeconds(delayTime);

        // オブジェクトを非表示にする
        targetObject.SetActive(false);

        //// アバターのレンダーをすべてオンにする
        //foreach (Renderer r in renderers)
        //{
        //    r.enabled = true;
        //}

        //// アバターの一部は影だけ表示させる
        //foreach (Renderer r in renderers)
        //{
        //    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
        //    {
        //        r.enabled = false;
        //        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        //    }
        //}
    }
}