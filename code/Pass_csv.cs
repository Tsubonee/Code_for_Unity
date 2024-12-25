using UnityEngine;
using System.IO; // CSV�t�@�C�����������߂ɕK�v
using System; // DateTime���������߂ɕK�v

public class Pass_csv : MonoBehaviour
{
    // �g���K�[�ɐG�ꂽ�I�u�W�F�N�g�iInspector�E�B���h�E����ݒ�j
    public Collider other;
    // CSV�t�@�C���̕ۑ���iInspector�E�B���h�E����ݒ�j
    public string csvFilePath = @"C:\Users\hirom\OneDrive - �ޗǐ�[�Ȋw�Z�p��w�@��w\My_exp\csvfile\other_pass_time.csv";

    void Start()
    {
        // CSV�t�@�C�������݂��Ȃ��ꍇ�͐V�K�쐬����
        if (!File.Exists(csvFilePath))
        {
            // �w�b�_�[�s����������
            File.WriteAllText(csvFilePath, "Player,Time\n");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �g���K�[�ɐG�ꂽ�I�u�W�F�N�g���v���C���[�Ȃ�
        if (other == this.other)
        {
            // ���ݎ������擾����
            string currentTime = DateTime.Now.ToString("o");
            // �v���C���[�̖��O���擾����
            string playerName = other.name;
            // CSV�t�@�C���ɒǋL����
            File.AppendAllText(csvFilePath, $"{playerName},{currentTime}\n");
        }
    }
}
