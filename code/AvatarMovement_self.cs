using UnityEngine;
using UnityEngine.XR;

public class AvatarMovement_self: MonoBehaviour
{
    // アニメーターを制御するための変数
    private Animator animator;

    // 初期化時にアニメーターを取得する
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 毎フレーム呼ばれる処理
    private void Update()
    {
        // スティックの入力値を取得する
        Vector2 inputAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        float horizontal = inputAxis.x;
        float vertical = inputAxis.y;
        // スティックの入力をコンソールウィンドウに表示
        //UnityEngine.Debug.Log("Horizontal: " + horizontal + ", Vertical: " + vertical);

        // 入力値があれば歩くモーションを再生し、なければ静止モーションにする
        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
