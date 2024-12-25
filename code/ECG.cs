using System.IO.Ports;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
public class ECG : MonoBehaviour
{
    //Shimmer シリアルポートの設定
    public string ShimmerPortName = "COM4";
    public int ShimmerBaudRate = 115200;
    int Shimmertimeout = 10; // タイムアウト（ミリ秒）
    public SerialPort ShimmerSerialPort;
    
    public int Trigger = 0;
    void Awake()
    {
        // do not destroy
        DontDestroyOnLoad(this);
        Open();
    }
    private void Start()
    {
        //OnSerialTrigger(1);
    }
    void Open()
    {
        ShimmerSerialPort = new SerialPort(ShimmerPortName, ShimmerBaudRate, Parity.None);
        ShimmerSerialPort.DataBits = 8;
        ShimmerSerialPort.Parity = Parity.None;
        ShimmerSerialPort.StopBits = StopBits.One;
        ShimmerSerialPort.DtrEnable = true;
        //serialPort.ReadTimeout = -1; // タイムアウトを無効化
        //serialPort.WriteTimeout = -1; // タイムアウトを無効化
        //ShimmerSerialPort.ReadTimeout = eegtimeout;
        //ShimmerSerialPort.WriteTimeout = eegtimeout;

        try
        {
            ShimmerSerialPort.Open();
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
        //serialPort.ReadTimeout = timeout;
        //serialPort.WriteTimeout = timeout;
    }

    public void OnSerialTrigger(int bitSize)
    {
        if (ShimmerSerialPort.IsOpen)
        {
            try
            {
                ShimmerSerialPort.Write("1");
                Debug.Log("SendBit" + bitSize);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    // シリアルポートのクローズ
    public void OnDestroy()
    {
        ShimmerSerialPort.Close();
        Debug.Log("Closed Serial Port");
    }

    public void OnClickButton()
    {
        OnSerialTrigger(1);
    }
}