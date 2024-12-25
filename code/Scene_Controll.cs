using UnityEngine;
using System.IO; // CSV�t�@�C�����������߂ɕK�v
using System; // DateTime���������߂ɕK�v
using UnityEngine.SceneManagement; // �V�[����J�ڂ��邽�߂ɕK�v
using System.IO.Ports; // �V���A���|�[�g���������߂ɕK�v
using System.Collections;

public class Scene_Controll : MonoBehaviour
{
    // ��\���ɂ���I�u�W�F�N�g
    public GameObject targetObject;
    // ��\���ɂ���܂ł̎��ԁi�b�j
    public float delayTime = 30f;
    // �V�[����J�ڂ���܂ł̎��ԁi�b�j
    public float timeToChange = 120f;
    // �J�ڂ���V�[���̖��O
    public string sceneToChange = "Menu";
    // CSV�t�@�C���̕ۑ���
    public string csvFilePath = @"C:\Users\hirom\OneDrive - �ޗǐ�[�Ȋw�Z�p��w�@��w\My_exp\csvfile\other_trigger.csv";

    // �ǉ�: Audio Source�I�u�W�F�N�g���Q�Ƃ���ϐ�
    public GameObject audioSourceObject;
    private AudioSource audioSource;
    // �I��


    private ECG[] Trigger;
    

    void Awake()
    {
        
    }

    void sendTrigger()
    {
        for (int i = 0; i < Trigger.Length; i++)
        {
            Trigger[i].OnClickButton();
        }
    }

    void Start()
    {
        Shimmer();



        // CSV�t�@�C�������݂��Ȃ��ꍇ�͐V�K�쐬����
        if (!File.Exists(csvFilePath))
        {
            // �w�b�_�[�s����������
            File.WriteAllText(csvFilePath, "Event,Time\n");
        }
        // �J�n�������擾����
        string startTime = DateTime.Now.ToString("o");
        // CSV�t�@�C���ɒǋL����
        File.AppendAllText(csvFilePath, $"Start,{startTime}\n");
        // OnSerialTrigger(1)�֐����Ăяo��
        sendTrigger();
        // ��\���ɂ���R���[�`�����J�n
        StartCoroutine(HideAfterDelay());
        // �V�[����J�ڂ���R���[�`�����J�n
        StartCoroutine(ChangeAfterDelay());

    }

    void Shimmer()
    {
        // �ǉ�: Audio Source�R���|�[�l���g���擾���Afalse�ɐݒ肷��
        if (audioSourceObject != null) // Audio Source�I�u�W�F�N�g��None�łȂ����`�F�b�N����
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
            audioSource.enabled = false;
        }
        // �I��

        GameObject ecg = GameObject.Find("Shimmer");
        Trigger = ecg.GetComponentsInChildren<ECG>();

    }

    private void DisableVRModule()
    {
        if (GameObject.Find("[VRModule]") != null)
        {
            GameObject.Find("[VRModule]").SetActive(false);
        }
    }

    // ��\���ɂ���R���[�`��
    IEnumerator HideAfterDelay()
    {
        // �w�肵�����Ԃ����҂�
        yield return new WaitForSeconds(delayTime);
        // �I�u�W�F�N�g���\���ɂ���
        targetObject.SetActive(false);
        string hideTime = DateTime.Now.ToString("o");
        // CSV�t�@�C���ɒǋL����
        File.AppendAllText(csvFilePath, $"Hide,{hideTime}\n");
        // OnSerialTrigger(1)�֐����Ăяo��
        sendTrigger();

        // �ǉ�: Audio Source�R���|�[�l���g��true�ɐݒ肷��
        if (audioSource != null) // Audio Source�R���|�[�l���g��None�łȂ����`�F�b�N����
        {
            audioSource.enabled = true;
        }

        // �I��
    }

    // �V�[����J�ڂ���R���[�`��
    IEnumerator ChangeAfterDelay()
    {
        // �w�肵�����Ԃ����҂�
        yield return new WaitForSeconds(timeToChange);
        // �J�ڎ������擾����
        string changeTime = DateTime.Now.ToString("o");
        // CSV�t�@�C���ɒǋL����
        File.AppendAllText(csvFilePath, $"Change,{changeTime}\n");
        // OnSerialTrigger(1)�֐����Ăяo��
        sendTrigger();


        // �V�[����J�ڂ���
        SceneManager.LoadScene(sceneToChange);
    }

}
