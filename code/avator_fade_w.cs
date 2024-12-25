using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class avator_fade_w : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject avatar;
    private Renderer[] renderers;

    private float Time;

    void Start()
    {
        avatar = GameObject.Find("avator_w");
        renderers = avatar.GetComponentsInChildren<Renderer>();

        // アバターのレンダーをすべてオフにする
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        GameObject hideObject = GameObject.Find("Scene Change");
        // Scene_Controllスクリプトを取得
        Scene_Controll sceneScript = hideObject.GetComponent<Scene_Controll>();

        Time = sceneScript.delayTime;
        // 非表示にするコルーチンを開始
        StartCoroutine(HideAfterDelay()); // コルーチンを呼び出す

    }

    IEnumerator HideAfterDelay()
    {
        // 指定した時間だけ待つ
        yield return new WaitForSeconds(Time);

        // アバターのレンダーをすべてオンにする
        foreach (Renderer r in renderers)
        {
            r.enabled = true;
        }



        // アバターの一部は影だけ表示させる
        foreach (Renderer r in renderers)
        {
            if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
            {
                // r.enabled = false; // これはコメントアウトする
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                // マテリアルの色を透明にする
                foreach (Material m in r.materials)
                {
                    m.color = new Color(0, 0, 0, 0);
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
