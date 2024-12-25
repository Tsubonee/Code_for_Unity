using UnityEngine;
using UnityEngine.XR;

public class Change3 : MonoBehaviour
{

    private Transform thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private Transform firstpp_pos;
    private Vector3 camera_original_pos;
    private Vector3 camera_new_pos;
    private bool isFirstPersonView = true; 

    // Start is called before the first frame update
    void Start()
    {
        thirdpp_pos = GameObject.Find("CenterEyeAnchor_3pp").transform;
        firstpp_pos = GameObject.Find("CenterEyeAnchor_1pp").transform;
        mainCamera = GameObject.Find("OVRCameraRig");
        avatar = GameObject.Find("avator");


        renderers = avatar.GetComponentsInChildren<Renderer>();


        foreach (Renderer r in renderers)
        {
            if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
            {
                r.enabled = true;
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //�e�������e���郂�[�h�ɕύX
            }
        }

        camera_original_pos = mainCamera.transform.localPosition; //(updateの外で) 一度だけ，OVRCameraRig の初期位置を保存。

    }

    // Update is called once per frame

    void Update()
    {
        thirdpp_pos = GameObject.Find("CenterEyeAnchor_3pp").transform;
        firstpp_pos = GameObject.Find("CenterEyeAnchor_1pp").transform;





        if (Input.GetKeyDown("space"))
        {

            if (isFirstPersonView)
            {

                foreach (Renderer r in renderers)
                {
                    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                    {
                        r.enabled = true;
                        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; //�e�𓊉e���郂�[�h�ɕύX
                    }
                }

                isFirstPersonView = false;
                camera_original_pos = mainCamera.transform.localPosition; //(updateの外で) 一度だけ，OVRCameraRig の初期位置を保存。

            }

            else
            {


                mainCamera.transform.position = firstpp_pos.transform.position;


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

        if (!isFirstPersonView)
        {
            Vector3 camerapos = new Vector3(0, 0, -4);
            Vector3 offset = new Vector3(0, 0, 1.5f);
            Quaternion cameraquat = GameObject.Find("CenterEyeAnchor").transform.localRotation;


            //(updateの中で) CenterEyeAnchor_3pp のlocalPositionを 1. で保存した位置を基準に CenterEyeAnchor の姿勢に合わせて更新
            cameraquat = Quaternion.Normalize(cameraquat);

            Quaternion q = cameraquat;

            float angle;
            Vector3 axis;
            q.ToAngleAxis(out angle, out axis);
            Quaternion q_half = Quaternion.AngleAxis(angle / 2.0f, axis);

            camerapos = q_half * camerapos + (camera_original_pos) + offset; 

            GameObject.Find("CenterEyeAnchor_3pp").transform.localPosition = camerapos;
      

            //CenterEyeAnchor_3pp のlocalPositionをOVRCameraRigのlocalPositionにコピー
            mainCamera.transform.localPosition = GameObject.Find("CenterEyeAnchor_3pp").transform.localPosition;

        }


    }
}