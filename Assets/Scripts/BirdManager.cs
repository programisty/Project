using System.Collections;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private GameObject birdPrefab;  // ������ �����
    [SerializeField] private Transform birdSpawnerPos;  // ������� ������

    private Bird currentBird;  // ������� ����� �� ������

    void Start()
    {
        SpawnNewBird();  // ����� ����� ����� ��� ������ ����
    }

    // ������� ��� ������ ����� �����
    public void SpawnNewBird()
    {
        if (currentBird != null)
        {
            Destroy(currentBird.gameObject);  // ������� ������ �����
        }

        // ������� ����� �����
        GameObject newBirdObj = Instantiate(birdPrefab, birdSpawnerPos.position, Quaternion.identity);
        currentBird = newBirdObj.GetComponent<Bird>();
        currentBird.SetBirdManager(this);  // ��������� BirdManager ��� ����� �����

    }
}
