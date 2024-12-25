//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Scene_Change : MonoBehaviour
//{
//    // �{�^���ɑΉ�����V�[�������C���X�y�N�^�[����ݒ肷��
//    [SerializeField]
//    private string sceneName;

//    // �{�^���������ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
//    public void OnClickButton()
//    {
//        // �V�[�������w�肵�ăV�[����J�ڂ���
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
    // �V�[���؂�ւ��̃��\�b�h
    public void SwitchScene()
    {
        //SceneManager.MoveGameObjectToScene(GameObject.Find("[ViveInputUtility]"), SceneManager.GetActiveScene());

        // �؂�ւ���̃V�[�������w��
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}