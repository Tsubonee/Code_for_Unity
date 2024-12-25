using UnityEngine;

public class TriggerFade : MonoBehaviour
{
    // �����x
    private float alpha = 1f;
    // �����x�̌�����
    private float fadeSpeed = 0.01f;
    // �}�e���A��
    private Material material;

    void Start()
    {
        // �}�e���A�����擾
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // �����x��0���傫���Ȃ�
        if (alpha > 0f)
        {
            // �����x�����炷
            alpha -= fadeSpeed;
            // �}�e���A���̐F���X�V
            material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
        }
    }
}
