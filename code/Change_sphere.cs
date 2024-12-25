using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_sphere : MonoBehaviour
{

    private Transform thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private Transform firstpp_pos;
    private bool isFirstPersonView = true; // 1�l�̎��_���ǂ����̃t���O
    public float distance = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        thirdpp_pos = GameObject.Find("CenterEyeAnchor_3pp").transform;
        firstpp_pos = GameObject.Find("CenterEyeAnchor_1pp").transform;
        mainCamera = GameObject.Find("OVRCameraRig");
        avatar = GameObject.Find("avator");

        //�A�o�^�[�̃����_�[���擾
        renderers = avatar.GetComponentsInChildren<Renderer>();

        //�ځA���A���A���̃����_�[�̓I�t�ɂ��Ȃ����A�e�������e���郂�[�h�ɕύX����
        foreach (Renderer r in renderers)
        {
            if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
            {
                r.enabled = true;
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //�e�������e���郂�[�h�ɕύX
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        thirdpp_pos = GameObject.Find("CenterEyeAnchor_3pp").transform;
        firstpp_pos = GameObject.Find("CenterEyeAnchor_1pp").transform;
        if (Input.GetKeyDown("space"))
        {

            if (isFirstPersonView) //1�l�̎��_�Ȃ�
            {
                mainCamera.transform.position = thirdpp_pos.position; //�������폜

                ////    //�ځA���A���A���̃����_�[���I���ɂ���
                foreach (Renderer r in renderers)
                {
                    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                    {
                        r.enabled = true;
                        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; //�e�𓊉e���郂�[�h�ɕύX
                    }
                }

                isFirstPersonView = false;

                //��������ǉ�
                Vector3 headDirection = mainCamera.transform.forward; //���̌����x�N�g�����擾
                float distance = 0.05f; //�J�����Ɠ��̋����i�K�X�����j
                Vector2 sphericalCoord = ToSphericalCoord(headDirection); //���ʍ��W�ɕϊ�
                Vector3 cameraPosition = ToCartesianCoord(sphericalCoord, distance); //�J�����̈ʒu�x�N�g�����v�Z
                mainCamera.transform.position = cameraPosition; //�J�����̈ʒu���X�V
                mainCamera.transform.LookAt(firstpp_pos); //�J�����̌����𓪂ɍ��킹��
                //�����܂Œǉ�

            }

            else
            {
                //���C���J�������A�N�e�B�u�ɐݒ�

                mainCamera.transform.position = firstpp_pos.position;

                //�ځA���A���A���̃����_�[�̓I�t�ɂ��Ȃ����A�e�������e���郂�[�h�ɕύX����
                foreach (Renderer r in renderers)
                {
                    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                    {
                        r.enabled = true;
                        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //�e�������e���郂�[�h�ɕύX
                    }
                }

                isFirstPersonView = true;
            }
        }

        //��������ǉ�
        if (!isFirstPersonView) //3�l�̎��_�Ȃ�
        {
            Vector3 headDirection = mainCamera.transform.forward; //���̌����x�N�g�����擾
            float distance = 0.05f; //�J�����Ɠ��̋����i�K�X�����j
            Vector2 sphericalCoord = ToSphericalCoord(headDirection); //���ʍ��W�ɕϊ�
            Vector3 cameraPosition = ToCartesianCoord(sphericalCoord, distance); //�J�����̈ʒu�x�N�g�����v�Z
            mainCamera.transform.position = cameraPosition; //�J�����̈ʒu���X�V
            mainCamera.transform.LookAt(firstpp_pos); //�J�����̌����𓪂ɍ��킹��
        }
        //�����܂Œǉ�
    }

    //��������ǉ�
    //���̌����x�N�g�������ʍ��W�ɕϊ�����֐�
    Vector2 ToSphericalCoord(Vector3 direction)
    {
        float x = direction.x;
        float y = direction.y;
        float z = direction.z;
        float r = Mathf.Sqrt(x * x + y * y + z * z);
        float theta = Mathf.Acos(y / r); //�ܓx�i0�`�΁j
        float phi = Mathf.Atan2(z, x); //�o�x�i-�΁`�΁j
        return new Vector2(theta, phi);
    }

    //�ܓx�ƌo�x����J�����̈ʒu�x�N�g�����v�Z����֐�
    Vector3 ToCartesianCoord(Vector2 sphericalCoord, float distance)
    {
        float theta = sphericalCoord.x;
        float phi = sphericalCoord.y;
        float x = distance * Mathf.Sin(theta) * Mathf.Cos(phi);
        float y = distance * Mathf.Cos(theta);
        float z = distance * Mathf.Sin(theta) * Mathf.Sin(phi);
        return new Vector3(x, y, z);
    }
    //�����܂Œǉ�

}
