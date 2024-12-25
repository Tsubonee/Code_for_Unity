using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideObject : MonoBehaviour
{
    // 非表示にするオブジェクト
    public GameObject targetObject;


    // 非表示にするまでの時間（秒）
    public float delayTime = 60f;


    // Start is called before the first frame update
    void Start()
    {
        // 非表示にするコルーチンを開始
        StartCoroutine(HideAfterDelay());

    }

    // 非表示にするコルーチン
    IEnumerator HideAfterDelay()
    {
        // 指定した時間だけ待つ
        yield return new WaitForSeconds(delayTime);

        // オブジェクトを非表示にする
        targetObject.SetActive(false);
    }
}