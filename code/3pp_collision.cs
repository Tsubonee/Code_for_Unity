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
        // カメラとターゲットの位置を取得する
        Vector3 cameraPosition = thirdpp_pos.transform.position;
        Vector3 targetPosition = tpp_pos.position;

        // カメラとターゲットの位置からRayの方向を計算する
        Vector3 direction = (cameraPosition - targetPosition).normalized;

        // Physics.RaycastでRayを発射して、壁に当たったかどうかを判定する
        RaycastHit hit;
        if (Physics.Raycast(targetPosition, direction, out hit, distance, wallLayers))
        {
            // 壁に当たった場合は、壁の位置を取得して、カメラの位置を壁の少し手前に移動する
            cameraPosition = hit.point - direction * offset;
        }
        else
        {
            // 壁に当たらなかった場合は、カメラの位置をターゲットに近づける
            cameraPosition = targetPosition + direction * distance;
        }

        // カメラの位置と回転を更新する
        thirdpp_pos.transform.position = cameraPosition;
        thirdpp_pos.transform.LookAt(targetPosition);
    }
}