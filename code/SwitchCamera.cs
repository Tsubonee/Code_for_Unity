using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera firstPersonCamera; // 1�l�̎��_�p�̃J����
    public Camera thirdPersonCamera; // 3�l�̎��_�p�̃J����

    private float buttonPressedTime; // A�{�^���������ꂽ���Ԃ��L�^����ϐ�
    private bool cameraSwitched; // �J�������؂�ւ�������ǂ������L�^����ϐ�

    void Start()
    {
        // ������Ԃł�1�l�̎��_�ɂ���
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;

        // A�{�^���������ꂽ���ԂƃJ�������؂�ւ�������ǂ���������������
        buttonPressedTime = 0f;
        cameraSwitched = false;
    }

    void Update()
    {
        // A�{�^����������Ă����
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            // A�{�^���������ꂽ���Ԃ����Z����
            buttonPressedTime += Time.deltaTime;

            // A�{�^����5�b�ȏ㉟���ꂽ��
            if (buttonPressedTime >= 5f)
            {
                // �J�������܂��؂�ւ���Ă��Ȃ����
                if (!cameraSwitched)
                {
                    // 1�l�̎��_�p��3�l�̎��_�p�̃J�����̗L���E������؂�ւ���
                    firstPersonCamera.enabled = !firstPersonCamera.enabled;
                    thirdPersonCamera.enabled = !thirdPersonCamera.enabled;

                    // �J�������؂�ւ�������Ƃ��L�^����
                    cameraSwitched = true;
                }
            }
        }
        // A�{�^���������ꂽ��
        else
        {
            // A�{�^���������ꂽ���ԂƃJ�������؂�ւ�������ǂ���������������
            buttonPressedTime = 0f;
            cameraSwitched = false;
        }
    }
}
