using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    // �^�C�}�[
    private float timer;
    // �^�C�}�[���J�n���邩�ǂ���
    private bool startTimer;
    // �g���K�[�ɐG�ꂽ�I�u�W�F�N�g�iInspector�E�B���h�E����ݒ�j
    public Collider other;
    // �V�[����؂�ւ���܂ł̎��ԁiInspector�E�B���h�E����ݒ�j
    public float timeToChange = 30f;
    // �J�ڂ���V�[���̖��O�iInspector�E�B���h�E����ݒ�j
    public string sceneToChange = "MenuScene";

    void Start()
    {
        // �^�C�}�[��0�ɏ�����
        timer = 0f;
        // �^�C�}�[���J�n���Ȃ�
        startTimer = false;
    }

    void Update()
    {
        // �^�C�}�[���J�n���ꂽ��
        if (startTimer)
        {
            // �^�C�}�[�𑝂₷
            timer += Time.deltaTime;
            // �^�C�}�[��timeToChange�ȏ�ɂȂ�����
            if (timer >= timeToChange)
            {
                // sceneToChange�ɑJ�ڂ���
                SceneManager.LoadScene(sceneToChange);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �g���K�[�ɐG�ꂽ�I�u�W�F�N�g���v���C���[�Ȃ�
        if (other == this.other)
        {
            // �^�C�}�[���J�n����
            startTimer = true;
        }
    }
}