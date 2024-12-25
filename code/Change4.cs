using UnityEngine;
using UnityEngine.XR;

public class Change4 : MonoBehaviour
{

    private GameObject thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private GameObject firstpp_pos;
    private bool isFirstPersonView = true;
    public Transform tpp_pos;

    // Start is called before the first frame update
    void Start()
    {
        thirdpp_pos = GameObject.Find("Camera");
        firstpp_pos = GameObject.Find("CenterEyeAnchor");
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

    }

    // Update is called once per frame

    void Update()
    {
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
                thirdpp_pos.SetActive(true); //三人称視点用カメラを非アクティブにする
                firstpp_pos.SetActive(false); //一人称視点用カメラをアクティブにする


            }

            else
            {


                foreach (Renderer r in renderers)
                {
                    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                    {
                        r.enabled = true;
                        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //�e�������e���郂�[�h�ɕύX
                    }
                }

                isFirstPersonView = true;
                thirdpp_pos.SetActive(false); //三人称視点用カメラをアクティブにする
                firstpp_pos.SetActive(true); //一人称視点用カメラを非アクティブにする
            }
        }

        if (!isFirstPersonView)
        {
            //transform.position = new Vector3(tpp_pos.position.x, transform.position.y, tpp_pos.position.z);
            // TODO: check if rotatiom does not change height without next line
            //transform.position = tpp_pos.position;

            // TEST START (do not use im experiment!)
            // add limit (test) -> bad
            Debug.Log(Mathf.Abs(tpp_pos.localRotation.eulerAngles.y));
            if (Mathf.Abs(tpp_pos.localRotation.eulerAngles.y) > 40)
            {
                Quaternion quat = tpp_pos.localRotation; // get rotation quaternion
                Vector3 angles = quat.eulerAngles; // get angles
                angles.y = 40 * Mathf.Sign(tpp_pos.rotation.eulerAngles.y); // freeze angle of y axis
                quat.eulerAngles = angles; // put angle back into quaternion
                tpp_pos.localRotation = quat; // put quaternion back into 
                //transform.position = tpp_pos.position;
            }
            // TEST END
            transform.rotation = tpp_pos.rotation;

        }
    }
}
