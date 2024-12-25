using UnityEngine;

public class CameraWallCheck : MonoBehaviour
{
    // ターゲット（OVRPlayerController）
    public Transform target;

    // カメラ（OVRCameraRig）
    public Transform camera;

    // カメラとターゲットの距離
    public float distance = 3f;

    // 壁チェック用レイヤーマスク
    public LayerMask wallLayers;

    // 壁チェック用レイキャスト情報
    private RaycastHit wallHit;

    // 壁チェック用レイが当たった座標
    private Vector3 wallHitPosition;

    // カメラが移動する座標
    private Vector3 desiredPosition;

    // ターゲットの座標
    private Vector3 targetPosition;

    // カメラの速度
    private Vector3 velocity = Vector3.zero;

    // カメラの移動時間
    private float smoothTime = 0.3f;

    void Update()
    {
        // ターゲットの座標を取得
        targetPosition = target.position;

        // ターゲットの前方向ベクトルを取得
        Vector3 forward = target.forward;

        // 壁がないと仮定した場合のカメラの座標を算出
        desiredPosition = targetPosition - forward * distance;

        // 壁チェックを行う
        if (WallCheck())
        {
            // 壁に当たった場合は、当たった座標にカメラを移動させる
            camera.position = Vector3.SmoothDamp(camera.position, wallHitPosition, ref velocity, smoothTime);
        }
        else
        {
            // 壁に当たらなかった場合は、算出した座標にカメラを移動させる
            camera.position = Vector3.SmoothDamp(camera.position, desiredPosition, ref velocity, smoothTime);
        }

        // カメラは常にターゲットを向くようにする
        //camera.LookAt(target);
    }

    protected bool WallCheck()
    {
        if (Physics.Raycast(targetPosition, desiredPosition - targetPosition, out wallHit, Vector3.Distance(targetPosition, desiredPosition), wallLayers, QueryTriggerInteraction.Ignore))
        {
            // 壁から0.5fだけ離す
            wallHitPosition = wallHit.point + wallHit.normal * 0.5f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
