using UnityEngine;

public class CameraWallCheck : MonoBehaviour
{
    // �^�[�Q�b�g�iOVRPlayerController�j
    public Transform target;

    // �J�����iOVRCameraRig�j
    public Transform camera;

    // �J�����ƃ^�[�Q�b�g�̋���
    public float distance = 3f;

    // �ǃ`�F�b�N�p���C���[�}�X�N
    public LayerMask wallLayers;

    // �ǃ`�F�b�N�p���C�L���X�g���
    private RaycastHit wallHit;

    // �ǃ`�F�b�N�p���C�������������W
    private Vector3 wallHitPosition;

    // �J�������ړ�������W
    private Vector3 desiredPosition;

    // �^�[�Q�b�g�̍��W
    private Vector3 targetPosition;

    // �J�����̑��x
    private Vector3 velocity = Vector3.zero;

    // �J�����̈ړ�����
    private float smoothTime = 0.3f;

    void Update()
    {
        // �^�[�Q�b�g�̍��W���擾
        targetPosition = target.position;

        // �^�[�Q�b�g�̑O�����x�N�g�����擾
        Vector3 forward = target.forward;

        // �ǂ��Ȃ��Ɖ��肵���ꍇ�̃J�����̍��W���Z�o
        desiredPosition = targetPosition - forward * distance;

        // �ǃ`�F�b�N���s��
        if (WallCheck())
        {
            // �ǂɓ��������ꍇ�́A�����������W�ɃJ�������ړ�������
            camera.position = Vector3.SmoothDamp(camera.position, wallHitPosition, ref velocity, smoothTime);
        }
        else
        {
            // �ǂɓ�����Ȃ������ꍇ�́A�Z�o�������W�ɃJ�������ړ�������
            camera.position = Vector3.SmoothDamp(camera.position, desiredPosition, ref velocity, smoothTime);
        }

        // �J�����͏�Ƀ^�[�Q�b�g�������悤�ɂ���
        //camera.LookAt(target);
    }

    protected bool WallCheck()
    {
        if (Physics.Raycast(targetPosition, desiredPosition - targetPosition, out wallHit, Vector3.Distance(targetPosition, desiredPosition), wallLayers, QueryTriggerInteraction.Ignore))
        {
            // �ǂ���0.5f��������
            wallHitPosition = wallHit.point + wallHit.normal * 0.5f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
