using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class thirdpp_collision: MonoBehaviour
{ 

    private GameObject thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private GameObject firstpp_pos;
    private bool isFirstPersonView = true;
    public Transform tpp_pos;
    public float delayTime = 60f;

    // �J�����ƃ^�[�Q�b�g�̋���
    public float distance = 5f;

    // �J�����ƕǂ̋���
    public float offset = 0.5f;

    // �ǂ̃��C���[
    public LayerMask wallLayers;

    // Start is called before the first frame update
    void Start()
    {
        thirdpp_pos = GameObject.Find("Camera");
        firstpp_pos = GameObject.Find("CenterEyeAnchor");
        mainCamera = GameObject.Find("OVRCameraRig");
        StartCoroutine(DelayCoroutine());

    }

    // Update is called once per frame

    private IEnumerator DelayCoroutine()
    {
        //3�b�ԑ҂�
        yield return new WaitForSeconds(delayTime);

        //�ʒu�Ɖ�]���X�V����
        //transform.position = new Vector3(tpp_pos.position.x, transform.position.y, tpp_pos.position.z);
        transform.position = tpp_pos.position;
        transform.rotation = tpp_pos.rotation;
    }

    void Update()
    {
        // �J�����ƃ^�[�Q�b�g�̈ʒu���擾����
        Vector3 cameraPosition = thirdpp_pos.transform.position;
        Vector3 targetPosition = tpp_pos.position;

        // �J�����ƃ^�[�Q�b�g�̈ʒu����Ray�̕������v�Z����
        Vector3 direction = (cameraPosition - targetPosition).normalized;

        // Physics.Raycast��Ray�𔭎˂��āA�ǂɓ����������ǂ����𔻒肷��
        RaycastHit hit;
        if (Physics.Raycast(targetPosition, direction, out hit, distance, wallLayers))
        {
            // �ǂɓ��������ꍇ�́A�ǂ̈ʒu���擾���āA�J�����̈ʒu��ǂ̏�����O�Ɉړ�����
            cameraPosition = hit.point - direction * offset;
        }
        else
        {
            // �ǂɓ�����Ȃ������ꍇ�́A�J�����̈ʒu���^�[�Q�b�g�ɋ߂Â���
            cameraPosition = targetPosition + direction * distance;
        }

        // �J�����̈ʒu�Ɖ�]���X�V����
        thirdpp_pos.transform.position = cameraPosition;
        thirdpp_pos.transform.LookAt(targetPosition);
    }
}