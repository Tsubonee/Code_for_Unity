using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Shimer_open : MonoBehaviour
{

    // Shimmer シリアルポートの設定
    public string ShimmerPortName = "COM4";
    public int ShimmerBaudRate = 115200;
    int Shimmertimeout = 10; // タイムアウト（ミリ秒）
    public SerialPort ShimmerSerialPort;


    // OWliftcap  シリアルポートの設定
    public string OWliftPortName = "COM7";
    public int OWliftBaudRate = 115200;
    int OWlifttimeout = 10; // タイムアウト（ミリ秒）
    public SerialPort OWliftSerialPort;

    // Start is called before the first frame update
    void Awake()
    {
        Open();
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        ShimmerSerialPort = new SerialPort(ShimmerPortName, ShimmerBaudRate, Parity.None);
        ShimmerSerialPort.DataBits = 8;
        ShimmerSerialPort.Parity = Parity.None;
        ShimmerSerialPort.StopBits = StopBits.One;
        ShimmerSerialPort.DtrEnable = true;

        OWliftSerialPort = new SerialPort(OWliftPortName, OWliftBaudRate, Parity.None);
        OWliftSerialPort.DataBits = 8;
        OWliftSerialPort.Parity = Parity.None;
        OWliftSerialPort.StopBits = StopBits.One;
        OWliftSerialPort.DtrEnable = true;

        try
        {
            ShimmerSerialPort.Open();
            OWliftSerialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        if (ShimmerSerialPort.IsOpen)
        {
            Debug.Log("Shimmerシリアルポートが正常にオープンされました");
        }
        else
        {
            Debug.Log("Shimmerシリアルポートのオープンに失敗しました");
        }

    }
}
