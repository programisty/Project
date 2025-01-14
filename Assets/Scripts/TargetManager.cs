using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI

public class TargetManager : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;  // ������ ������
    [SerializeField] private int totalTargets = 10;    // ����� ���������� �������
    [SerializeField] private float spawnAreaWidth = 10f; // ������ ������� ������
    [SerializeField] private float spawnAreaHeight = 5f; // ������ ������� ������
    [SerializeField] private Text scoreText;            // ����� ��� ����������� ��������
    [SerializeField] private GameObject victoryPanel;    // ������ ������
    [SerializeField] private Timer timer;               // ������ �� Timer

    private int targetsSpawned = 0;  // ������� ��������� �������
    private int targetsDestroyed = 0; // ������� ������������ �������

    void Start()
    {
        victoryPanel.SetActive(false); // �������� ������ ������ ��� ������
        SpawnTarget();  // ����� ������ ������ ��� ������
        UpdateScore();  // ��������� �������
    }

    // ������� ��� ������ ����� ������
    public void SpawnTarget()
    {
        if (targetsSpawned < totalTargets)
        {
            // ���������� ��������� ���������� ��� ������
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2)
            );

            // ������� ����� ������
            GameObject newTargetObj = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            targetsSpawned++;
            UpdateScore(); // ��������� �������

            // ��������� TargetManager ��� ������
            Target targetScript = newTargetObj.GetComponent<Target>();
            targetScript.SetTargetManager(this);
        }
        else
        {
            ShowVictory(); // ���� ��� ������ ����������, ���������� ��������� ������
        }
    }

    // ���������� ��������
    public void UpdateScore()
    {
        scoreText.text = "���������� �������: " + targetsDestroyed + "/" + totalTargets;
    }

    // �������� ������ ������
    public void ShowVictory()
    {
        scoreText.text = " ";
        victoryPanel.SetActive(true); // ���������� ������ ������
        timer.StopTimer(); // ������������� ������
    }

    // ��������� ������� ������������ �������
    public void TargetDestroyed()
    {
        targetsDestroyed++;
        UpdateScore();
    }
}