using UnityEngine;
using VRQuestionnaireToolkit;

public class ExportToCSVEventHandler : MonoBehaviour
{
    private ExportToCSV exportToCSV;

    void Start()
    {
        exportToCSV = GetComponent<ExportToCSV>();
        if (exportToCSV != null)
        {
            exportToCSV.QuestionnaireFinishedEvent.AddListener(OnQuestionnaireFinished);
        }
    }

    void OnQuestionnaireFinished()
    {
        // �A���P�[�g���I�������Ƃ��Ɏ��s�������������L�q
        // �Ⴆ�΁AMenu�V�[���ւ̑J�ڂ��s��
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
