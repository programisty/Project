using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuPanel;  // ������ ����, ������� ����� ����������/��������

    // ������ �� ������
    public Button playButton;
    public Button rulesButton;
    public Button exitButton;

    void Start()
    {
        // �������� � ��������� ���� �� ���������
        menuPanel.SetActive(true);

        // ��������� �������� ��� ������
        playButton.onClick.AddListener(PlayGame);
        rulesButton.onClick.AddListener(ShowRules);
        exitButton.onClick.AddListener(ExitGame);
    }

    void PlayGame()
    {
        // ����� ����� ��������� ����� � �����
        SceneManager.LoadScene("menu"); // �������� "GameScene" �� ��� ����� �����
    }

    void ShowRules()
    {
        // ����� ����� �������� ���� � ��������� ��� ��������
        Debug.Log("�������");
    }

    void ExitGame()
    {
        // ������� ����
        Application.Quit();
    }
}
