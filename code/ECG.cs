using System.IO.Ports;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
public class ECG : MonoBehaviour
{
    //Shimmer �V���A���|�[�g�̐ݒ�
    public string ShimmerPortName = "COM4";
    public int ShimmerBaudRate = 115200;
    int Shimmertimeout = 10; // �^�C���A�E�g�i�~���b�j
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
        //serialPort.ReadTimeout = -1; // �^�C���A�E�g�𖳌���
        //serialPort.WriteTimeout = -1; // �^�C���A�E�g�𖳌���
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
            Debug.Log("Shimmer�V���A���|�[�g������ɃI�[�v������܂���");
        }
        else
        {
            Debug.Log("Shimmer�V���A���|�[�g�̃I�[�v���Ɏ��s���܂���");
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

    // �V���A���|�[�g�̃N���[�Y
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