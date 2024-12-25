using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class Change6 : MonoBehaviour
{

    private GameObject thirdpp_pos;
    private GameObject mainCamera;
    private GameObject avatar;
    private Renderer[] renderers;
    private GameObject firstpp_pos;
    private bool isFirstPersonView = true;
    public Transform tpp_pos;
    public float delayTime = 60f;

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
        //3ïbä‘ë“Ç¬
        yield return new WaitForSeconds(delayTime);

        //à íuÇ∆âÒì]ÇçXêVÇ∑ÇÈ
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
