using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class TargetManager : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;  // Префаб мишени
    [SerializeField] private int totalTargets = 10;    // Общее количество мишеней
    [SerializeField] private float spawnAreaWidth = 10f; // Ширина области спавна
    [SerializeField] private float spawnAreaHeight = 5f; // Высота области спавна
    [SerializeField] private Text scoreText;            // Текст для отображения счётчика
    [SerializeField] private GameObject victoryPanel;    // Панель победы
    [SerializeField] private Timer timer;               // Ссылка на Timer

    private int targetsSpawned = 0;  // Счетчик созданных мишеней
    private int targetsDestroyed = 0; // Счетчик уничтоженных мишеней

    void Start()
    {
        victoryPanel.SetActive(false); // Скрываем панель победы при старте
        SpawnTarget();  // Спавн первой мишени при старте
        UpdateScore();  // Обновляем счётчик
    }

    // Функция для спавна новой мишени
    public void SpawnTarget()
    {
        if (targetsSpawned < totalTargets)
        {
            // Генерируем случайные координаты для спавна
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2)
            );

            // Спавним новую мишень
            GameObject newTargetObj = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            targetsSpawned++;
            UpdateScore(); // Обновляем счётчик

            // Назначаем TargetManager для мишени
            Target targetScript = newTargetObj.GetComponent<Target>();
            targetScript.SetTargetManager(this);
        }
        else
        {
            ShowVictory(); // Если все мишени уничтожены, показываем индикатор победы
        }
    }

    // Обновление счётчика
    public void UpdateScore()
    {
        scoreText.text = "Уничтожено мишеней: " + targetsDestroyed + "/" + totalTargets;
    }

    // Показать панель победы
    public void ShowVictory()
    {
        scoreText.text = " ";
        victoryPanel.SetActive(true); // Показываем панель победы
        timer.StopTimer(); // Останавливаем таймер
    }

    // Увеличить счётчик уничтоженных мишеней
    public void TargetDestroyed()
    {
        targetsDestroyed++;
        UpdateScore();
    }
}