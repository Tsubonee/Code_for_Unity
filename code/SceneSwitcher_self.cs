using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��̋@�\���g�����߂ɕK�v

public class SceneSwitcher_self : MonoBehaviour
{
    // �V�[���Đ����ɌĂ΂�郁�\�b�h
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Menu�V�[���ɐ؂�ւ���
            SceneManager.LoadScene("Menu");
        }
    }
}
