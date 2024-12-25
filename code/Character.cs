using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator animator;
    [SerializeField] float speed;

    static int hashFront = Animator.StringToHash("Front");
    static int hashSide = Animator.StringToHash("Side");

    private void Awake()
    {
        TryGetComponent(out animator);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get input from left stick (horizontal and vertical)
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        var leftStick = new Vector3(inputX, 0, inputY).normalized;

        // Get the forward direction based on HMD orientation
        var hmdForward = Camera.main.transform.forward;
        hmdForward.y = 0; // Ignore vertical component
        hmdForward.Normalize();

        // Calculate velocity based on left stick and HMD forward
        var velocity = speed * (leftStick.x * hmdForward + leftStick.z * Camera.main.transform.right);

        // Set animator parameters for movement
        animator.SetFloat(hashFront, velocity.z, 0.1f, Time.deltaTime);
        animator.SetFloat(hashSide, velocity.x, 0.1f, Time.deltaTime);
    }
}
