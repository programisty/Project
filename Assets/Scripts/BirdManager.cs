using System.Collections;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private GameObject birdPrefab;  // Префаб птицы
    [SerializeField] private Transform birdSpawnerPos;  // Позиция спавна

    private Bird currentBird;  // Текущая птица на экране

    void Start()
    {
        SpawnNewBird();  // Спавн новой птицы при старте игры
    }

    // Функция для спавна новой птицы
    public void SpawnNewBird()
    {
        if (currentBird != null)
        {
            Destroy(currentBird.gameObject);  // Удаляем старую птицу
        }

        // Спавним новую птицу
        GameObject newBirdObj = Instantiate(birdPrefab, birdSpawnerPos.position, Quaternion.identity);
        currentBird = newBirdObj.GetComponent<Bird>();
        currentBird.SetBirdManager(this);  // Назначаем BirdManager для новой птицы

    }
}
