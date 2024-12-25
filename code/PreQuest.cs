using UnityEngine;
using System.IO;
using System;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class PreQuest : MonoBehaviour
{

    [SerializeField]
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.Find("[VRModule]") != null)
            {
                Destroy(GameObject.Find("[VRModule]"));
                Destroy(GameObject.Find("ViveRig"));

            }

            // êÿÇËë÷Ç¶êÊÇÃÉVÅ[ÉìñºÇéwíË
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
