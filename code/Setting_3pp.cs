using UnityEngine;
using UnityEngine.XR;

public class Setting_3pp : MonoBehaviour
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

        //// カメラの位置を設定する
        //Vector3 cameraPosition = thirdpp_pos.transform.localPosition; // カメラの現在の位置を取得する
        //cameraPosition.y = mainCamera.transform.localPosition.y;//OVRCameraRigのY座標に合わせる
        //thirdpp_pos.transform.localPosition = cameraPosition;//カメラの位置を更新する
        //Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

    }

    // Update is called once per frame

    void Update()
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