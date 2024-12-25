using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideObject : MonoBehaviour
{
    // ��\���ɂ���I�u�W�F�N�g
    public GameObject targetObject;


    // ��\���ɂ���܂ł̎��ԁi�b�j
    public float delayTime = 60f;


    // Start is called before the first frame update
    void Start()
    {
        // ��\���ɂ���R���[�`�����J�n
        StartCoroutine(HideAfterDelay());

    }

    // ��\���ɂ���R���[�`��
    IEnumerator HideAfterDelay()
    {
        // �w�肵�����Ԃ����҂�
        yield return new WaitForSeconds(delayTime);

        // �I�u�W�F�N�g���\���ɂ���
        targetObject.SetActive(false);
    }
}