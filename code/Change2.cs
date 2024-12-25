using UnityEngine;
using UnityEngine.XR;

public class Change2 : MonoBehaviour
{

    private Transform thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private Transform firstpp_pos;
    private Vector3 camera_original_pos;
    private Vector3 camera_new_pos;
    private bool isFirstPersonView = true; // 1�l�̎��_���ǂ����̃t���O

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

            if (isFirstPersonView) //1�l�̎��_�Ȃ�
            {
                //mainCamera.transform.localPosition = mainCamera.transform.localPosition + new Vector3(0, 0, -10);

                //mainCamera.transform.position = thirdpp_pos.position;

                //// Vector3 headAngle = GameObject.Find("CenterEyeAnchor").transform;
                //Vector3 camerapos = new Vector3(0, 0, 1.93f);
                ////Quaternion cameraquat = GameObject.Find("CenterEyeAnchor").transform.rotation;
                ////camerapos = cameraquat * camerapos; //�x�N�g������]
                //mainCamera.transform.position = camerapos;



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

            }

            else
            {
         

                mainCamera.transform.position = firstpp_pos.position;

            
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
            Vector3 camerapos = new Vector3(0, 0, -5);
            Quaternion cameraquat = GameObject.Find("CenterEyeAnchor").transform.localRotation;
            //camera_new_pos = mainCamera.transform.localPosition;


            //(updateの中で) CenterEyeAnchor_3pp のlocalPositionを 1. で保存した位置を基準に CenterEyeAnchor の姿勢に合わせて更新
            cameraquat = Quaternion.Normalize(cameraquat);
            camerapos = cameraquat * camerapos;
            //GameObject.Find("CenterEyeAnchor").transform.localPosition = camerapos;
            GameObject.Find("CenterEyeAnchor_3pp").transform.localPosition = camerapos;
            //GameObject.Find("CenterEyeAnchor_3pp2").transform.localPosition = camerapos;

            //CenterEyeAnchor_3pp のlocalPositionをOVRCameraRigのlocalPositionにコピー
            mainCamera.transform.localPosition = GameObject.Find("CenterEyeAnchor_3pp").transform.localPosition;
     

            //mainCamera.transform.localPosition = camerapos;

            //camera_original_pos = mainCamera.transform.localPosition;


        }


    }
}
