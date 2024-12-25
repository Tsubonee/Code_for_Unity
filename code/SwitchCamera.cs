using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera firstPersonCamera; // 1人称視点用のカメラ
    public Camera thirdPersonCamera; // 3人称視点用のカメラ

    private float buttonPressedTime; // Aボタンが押された時間を記録する変数
    private bool cameraSwitched; // カメラが切り替わったかどうかを記録する変数

    void Start()
    {
        // 初期状態では1人称視点にする
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;

        // Aボタンが押された時間とカメラが切り替わったかどうかを初期化する
        buttonPressedTime = 0f;
        cameraSwitched = false;
    }

    void Update()
    {
        // Aボタンが押されている間
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            // Aボタンが押された時間を加算する
            buttonPressedTime += Time.deltaTime;

            // Aボタンが5秒以上押されたら
            if (buttonPressedTime >= 5f)
            {
                // カメラがまだ切り替わっていなければ
                if (!cameraSwitched)
                {
                    // 1人称視点用と3人称視点用のカメラの有効・無効を切り替える
                    firstPersonCamera.enabled = !firstPersonCamera.enabled;
                    thirdPersonCamera.enabled = !thirdPersonCamera.enabled;

                    // カメラが切り替わったことを記録する
                    cameraSwitched = true;
                }
            }
        }
        // Aボタンが離されたら
        else
        {
            // Aボタンが押された時間とカメラが切り替わったかどうかを初期化する
            buttonPressedTime = 0f;
            cameraSwitched = false;
        }
    }
}
