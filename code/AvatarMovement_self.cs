using UnityEngine;
using UnityEngine.XR;

public class AvatarMovement_self: MonoBehaviour
{
    // �A�j���[�^�[�𐧌䂷�邽�߂̕ϐ�
    private Animator animator;

    // ���������ɃA�j���[�^�[���擾����
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // ���t���[���Ă΂�鏈��
    private void Update()
    {
        // �X�e�B�b�N�̓��͒l���擾����
        Vector2 inputAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        float horizontal = inputAxis.x;
        float vertical = inputAxis.y;
        // �X�e�B�b�N�̓��͂��R���\�[���E�B���h�E�ɕ\��
        //UnityEngine.Debug.Log("Horizontal: " + horizontal + ", Vertical: " + vertical);

        // ���͒l������Ε������[�V�������Đ����A�Ȃ���ΐÎ~���[�V�����ɂ���
        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
