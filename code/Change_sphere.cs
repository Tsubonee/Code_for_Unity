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
    private bool isFirstPersonView = true; // 1人称視点かどうかのフラグ
    public float distance = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        thirdpp_pos = GameObject.Find("CenterEyeAnchor_3pp").transform;
        firstpp_pos = GameObject.Find("CenterEyeAnchor_1pp").transform;
        mainCamera = GameObject.Find("OVRCameraRig");
        avatar = GameObject.Find("avator");

        //アバターのレンダーを取得
        renderers = avatar.GetComponentsInChildren<Renderer>();

        //目、頭、歯、髪のレンダーはオフにしないが、影だけ投影するモードに変更する
        foreach (Renderer r in renderers)
        {
            if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
            {
                r.enabled = true;
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //影だけ投影するモードに変更
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

            if (isFirstPersonView) //1人称視点なら
            {
                mainCamera.transform.position = thirdpp_pos.position; //ここを削除

                ////    //目、頭、歯、髪のレンダーをオンにする
                foreach (Renderer r in renderers)
                {
                    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                    {
                        r.enabled = true;
                        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; //影を投影するモードに変更
                    }
                }

                isFirstPersonView = false;

                //ここから追加
                Vector3 headDirection = mainCamera.transform.forward; //頭の向きベクトルを取得
                float distance = 0.05f; //カメラと頭の距離（適宜調整）
                Vector2 sphericalCoord = ToSphericalCoord(headDirection); //球面座標に変換
                Vector3 cameraPosition = ToCartesianCoord(sphericalCoord, distance); //カメラの位置ベクトルを計算
                mainCamera.transform.position = cameraPosition; //カメラの位置を更新
                mainCamera.transform.LookAt(firstpp_pos); //カメラの向きを頭に合わせる
                //ここまで追加

            }

            else
            {
                //メインカメラをアクティブに設定

                mainCamera.transform.position = firstpp_pos.position;

                //目、頭、歯、髪のレンダーはオフにしないが、影だけ投影するモードに変更する
                foreach (Renderer r in renderers)
                {
                    if (r.name == "Renderer_EyeLeft" || r.name == "Renderer_EyeRight" || r.name == "Renderer_Head" || r.name == "Renderer_Teeth" || r.name == "Renderer_Hair")
                    {
                        r.enabled = true;
                        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //影だけ投影するモードに変更
                    }
                }

                isFirstPersonView = true;
            }
        }

        //ここから追加
        if (!isFirstPersonView) //3人称視点なら
        {
            Vector3 headDirection = mainCamera.transform.forward; //頭の向きベクトルを取得
            float distance = 0.05f; //カメラと頭の距離（適宜調整）
            Vector2 sphericalCoord = ToSphericalCoord(headDirection); //球面座標に変換
            Vector3 cameraPosition = ToCartesianCoord(sphericalCoord, distance); //カメラの位置ベクトルを計算
            mainCamera.transform.position = cameraPosition; //カメラの位置を更新
            mainCamera.transform.LookAt(firstpp_pos); //カメラの向きを頭に合わせる
        }
        //ここまで追加
    }

    //ここから追加
    //頭の向きベクトルを球面座標に変換する関数
    Vector2 ToSphericalCoord(Vector3 direction)
    {
        float x = direction.x;
        float y = direction.y;
        float z = direction.z;
        float r = Mathf.Sqrt(x * x + y * y + z * z);
        float theta = Mathf.Acos(y / r); //緯度（0～π）
        float phi = Mathf.Atan2(z, x); //経度（-π～π）
        return new Vector2(theta, phi);
    }

    //緯度と経度からカメラの位置ベクトルを計算する関数
    Vector3 ToCartesianCoord(Vector2 sphericalCoord, float distance)
    {
        float theta = sphericalCoord.x;
        float phi = sphericalCoord.y;
        float x = distance * Mathf.Sin(theta) * Mathf.Cos(phi);
        float y = distance * Mathf.Cos(theta);
        float z = distance * Mathf.Sin(theta) * Mathf.Sin(phi);
        return new Vector3(x, y, z);
    }
    //ここまで追加

}
