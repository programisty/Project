using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuPanel;  // Панель меню, которую будем показывать/скрывать

    // Ссылка на кнопки
    public Button playButton;
    public Button rulesButton;
    public Button exitButton;

    void Start()
    {
        // Включаем и выключаем меню по умолчанию
        menuPanel.SetActive(true);

        // Назначаем действия для кнопок
        playButton.onClick.AddListener(PlayGame);
        rulesButton.onClick.AddListener(ShowRules);
        exitButton.onClick.AddListener(ExitGame);
    }

    void PlayGame()
    {
        // Здесь можно загрузить сцену с игрой
        SceneManager.LoadScene("menu"); // Замените "GameScene" на имя вашей сцены
    }

    void ShowRules()
    {
        // Здесь можно показать окно с правилами или описание
        Debug.Log("Правила");
    }

    void ExitGame()
    {
        // Закрыть игру
        Application.Quit();
    }
}
