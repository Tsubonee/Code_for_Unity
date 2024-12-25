using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class collision_3pp : MonoBehaviour
{

    private GameObject thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private GameObject firstpp_pos;
    private bool isFirstPersonView = true;
    public Transform tpp_pos;
    public float delayTime = 60f;

    // カメラとターゲットの距離
    public float distance = 5f;

    // カメラと壁の距離
    public float offset = 0.5f;

    // 壁のレイヤー
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
        //3秒間待つ
        yield return new WaitForSeconds(delayTime);

        //位置と回転を更新する
        //transform.position = new Vector3(tpp_pos.position.x, transform.position.y, tpp_pos.position.z);
        transform.position = tpp_pos.position;
        transform.rotation = tpp_pos.rotation;
    }

    void Update()
    {


        //transform.position = new Vector3(tpp_pos.position.x, transform.position.y, tpp_pos.position.z);
        transform.position = tpp_pos.position;
        transform.rotation = tpp_pos.rotation;
    }
}