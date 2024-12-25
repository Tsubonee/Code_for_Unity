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
        // アンケートが終了したときに実行したい処理を記述
        // 例えば、Menuシーンへの遷移を行う
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
