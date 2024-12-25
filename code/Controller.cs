using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SpatialTracking;
using UnityEngine.XR;

public class Controller : MonoBehaviour
{

    public UnityEngine.XR.InputDevice _rightController;
    public UnityEngine.XR.InputDevice _leftController;
    public UnityEngine.XR.InputDevice _HMD;

    [SerializeField] private float holdThreshold = 2.0f;
    private float inputTimer;

    public GameObject rig;


    Rigidbody rb;
    [SerializeField]
    GameObject cam;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float topSpeed = 10.0f;
    [SerializeField] private float _rotSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (Camera.main != null)
        {
            cam = Camera.main.gameObject;
        }
        else
        {
            // Camera.main が見つからない場合のエラーハンドリング
            Debug.LogError("Main camera not found in the scene");
        }

        inputTimer = holdThreshold;
        transform.GetChild(0).GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>().enabled = true;

        StartCoroutine(RotateBase());

        /*
        var desiredforward = cam.transform.parent.forward;

        var difference = desiredforward - cam.transform.forward;

        Vector3 targetangle = new Vector3(0, desiredforward.y, 0);

        cam.transform.eulerAngles = targetangle;
        */

        /*
        Vector3 camForward = cam.transform.forward;
        Vector3 spawnPointForward = cam.transform.parent.forward;

        Vector3 playerForwardFlat = new Vector3(camForward.x, 0, camForward.z).normalized;
        Vector3 desiredForwardFlat = new Vector3(spawnPointForward.x, 0, spawnPointForward.z).normalized;

        float angle = Vector3.SignedAngle(playerForwardFlat, desiredForwardFlat, Vector3.up);

        Vector3 targetAngle = new Vector3(0, angle, 0);

        cam.transform.eulerAngles = targetAngle;
        */

    }

    IEnumerator RotateBase()
    {
        yield return new WaitForSeconds(0.5f);


        Vector3 desired = rig.transform.forward;
        Vector3 actual = rig.transform.forward;



        float rot = Vector3.SignedAngle(desired, actual, rig.transform.up);

        //rig.transform.RotateAround(cam.transform.up, rot);
        //Debug.Log(rot);
        rig.transform.Rotate(new Vector3(0, -rot, 0));
    }

    // Update is called once per frame
    void Update()
    {


        //ControllerMovement();

        if (!_rightController.isValid || !_leftController.isValid || !_HMD.isValid)
        {
            //Debug.Log("InitializeController");
            InitializeInputDevices();
        }


        if ((_rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool r_value) && r_value) || (_leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool l_value) && l_value))
        {


            inputTimer -= Time.deltaTime;
            if (inputTimer <= 0)
            {
                Debug.Log("A Pressed");
            }

        }


        if ((_rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool r_upValue) && !r_upValue) && (_leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool l_upValue) && !l_upValue))
        {
            inputTimer = holdThreshold;
        }

        if (_leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 r_axisValue) && r_axisValue != Vector2.zero)
        {
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;

            Vector3 forwardInput = r_axisValue.y * forward;
            Vector3 rightInput = r_axisValue.x * right;




            Vector3 direction = forwardInput + rightInput;


            rb.AddForce(new Vector3(direction.x, 0, direction.z) * _speed);

            if (rb.velocity.magnitude > topSpeed)
                rb.velocity = rb.velocity.normalized * topSpeed;

            //rb.transform.position = new Vector3(forwardInput, 0, rightInput);
            //rb.transform.Translate(direction * _speed * Time.deltaTime );
        }

        if (_rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 l_axisValue) && l_axisValue != Vector2.zero)
        {


            transform.Rotate(new Vector3(0, _rotSpeed * l_axisValue.x, 0));
        }

    }

    private void InitializeInputDevices()
    {
        if (!_rightController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        }
        if (!_leftController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
        }
        if (!_HMD.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.HeadMounted, ref _HMD);
        }
    }


    private void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref UnityEngine.XR.InputDevice inputDevice)
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }

    private void ControllerMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.transform.Translate(direction * _speed * Time.deltaTime);
    }
}
