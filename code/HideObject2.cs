using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideObject2 : MonoBehaviour
{
    // ��\���ɂ���I�u�W�F�N�g
    public GameObject targetObject;

    // ��\���ɂ���܂ł̎��ԁi�b�j
    public float delayTime = 60f;

    // �A�o�^�[�̃����_���[�̔z��
    private Renderer[] renderers;

    // Start is called before the first frame update
    void Start()
    {
        //// �A�o�^�[�̃����_���[���擾
        //renderers = targetObject.GetComponentsInChildren<Renderer>();

        //// �A�o�^�[�̃����_�[�����ׂăI�t�ɂ���
        //foreach (Renderer r in renderers)
        //{
        //    r.enabled = false;
        //}
        //Debug.Log("11111111");

        //// ��\���ɂ���R���[�`�����J�n
        //StartCoroutine(HideAfterDelay());
    }

    // ��\���ɂ���R���[�`��
    IEnumerator HideAfterDelay()
    {
        // �w�肵�����Ԃ����҂�
        yield return new WaitForSeconds(delayTime);

        // �I�u�W�F�N�g���\���ɂ���
        targetObject.SetActive(false);

        //// �A�o�^�[�̃����_�[�����ׂăI���ɂ���
        //foreach (Renderer r in renderers)
        //{
        //    r.enabled = true;
        //}

        //// �A�o�^�[�̈ꕔ�͉e�����\��������
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