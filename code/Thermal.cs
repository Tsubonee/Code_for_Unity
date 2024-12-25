using System.IO.Ports;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
public class Thermal : MonoBehaviour
{
    // OWliftcap AE シリアルポートの設定
    public string OWliftPortName = "COM7";
    public int OWliftBaudRate = 9600;
    int OWlifttimeout = 10; // タイムアウト（ミリ秒）
    public SerialPort OWliftSerialPort;

    public int Trigger = 0;
    void Awake()
    {
        Open();
    }
    private void Start()
    {
        //OnSerialTrigger(1);
    }
    void Open()
    {
        OWliftSerialPort = new SerialPort(OWliftPortName, OWliftBaudRate, Parity.None);
        OWliftSerialPort.DataBits = 8;
        OWliftSerialPort.Parity = Parity.None;
        OWliftSerialPort.StopBits = StopBits.One;
        OWliftSerialPort.DtrEnable = true;

        try
        {
            OWliftSerialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        if (OWliftSerialPort.IsOpen)
        {
            Debug.Log("OWLIFTCap シリアルポートが正常にオープンされました");
        }
        else
        {
            Debug.Log("OWLIFTCap シリアルポートのオープンに失敗しました");
        }
    }

    public void OnSerialTrigger(int bitSize)
    {
        if (OWliftSerialPort.IsOpen)
        {
            try
            {
                OWliftSerialPort.Write("1");
                Debug.Log("SendBit" + bitSize);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    // シリアルポートのクローズ
    void OnDestroy()
    {
        OWliftSerialPort.Close();
        //Debug.Log("Closed Serial Port");
    }

    public void OnClickButton()
    {
        OnSerialTrigger(1);
    }
}