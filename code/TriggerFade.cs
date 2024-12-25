using UnityEngine;

public class TriggerFade : MonoBehaviour
{
    // 透明度
    private float alpha = 1f;
    // 透明度の減少量
    private float fadeSpeed = 0.01f;
    // マテリアル
    private Material material;

    void Start()
    {
        // マテリアルを取得
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // 透明度が0より大きいなら
        if (alpha > 0f)
        {
            // 透明度を減らす
            alpha -= fadeSpeed;
            // マテリアルの色を更新
            material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
        }
    }
}
