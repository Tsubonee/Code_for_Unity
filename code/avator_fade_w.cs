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

        // �A�o�^�[�̃����_�[�����ׂăI�t�ɂ���
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        GameObject hideObject = GameObject.Find("Scene Change");
        // Scene_Controll�X�N���v�g���擾
        Scene_Controll sceneScript = hideObject.GetComponent<Scene_Controll>();

        Time = sceneScript.delayTime;
        // ��\���ɂ���R���[�`�����J�n
        StartCoroutine(HideAfterDelay()); // �R���[�`�����Ăяo��

    }

    IEnumerator HideAfterDelay()
    {
        // �w�肵�����Ԃ����҂�
        yield return new WaitForSeconds(Time);

        // �A�o�^�[�̃����_�[�����ׂăI���ɂ���
        foreach (Renderer r in renderers)
        {
            r.enabled = true;
        }



        // �A�o�^�[�̈ꕔ�͉e�����\��������
        foreach (Renderer r in renderers)
        {
            if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
            {
                // r.enabled = false; // ����̓R�����g�A�E�g����
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                // �}�e���A���̐F�𓧖��ɂ���
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
