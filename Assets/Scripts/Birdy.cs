using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdRb;
    [SerializeField] private Rigidbody2D pointRb;

    private BirdManager birdManager;  // Ссылка на BirdManager
    private bool isTouched = false;

    public float maxDist = 1f;
    public float launchForceMultiplier = 20f;  // Множитель силы старта
    public float gravityScale = 1f;  // Гравитация для более быстрого полета

    void Start()
    {
        birdRb.gravityScale = gravityScale;  // Устанавливаем гравитацию
    }

    void Update()
    {
        if (isTouched)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePos, pointRb.position) > maxDist)
            {
                birdRb.position = pointRb.position + (mousePos - pointRb.position).normalized * maxDist;
            }
            else
            {
                birdRb.position = mousePos;
            }
        }
    }

    private void OnMouseDown()
    {
        isTouched = true;
        birdRb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnMouseUp()
    {
        isTouched = false;
        birdRb.bodyType = RigidbodyType2D.Dynamic;

        // Рассчитываем направление и силу запуска с учетом множителя
        Vector2 launchForce = (pointRb.position - birdRb.position).normalized * launchForceMultiplier;
        birdRb.AddForce(launchForce, ForceMode2D.Impulse);

        // Запускаем Coroutine для появления новой птицы
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        // Ускоряем полет, уменьшая время ожидания
        yield return new WaitForSeconds(0.05f);  // Меньше времени на ожидание

        // Отключаем соединение (если есть компонент SpringJoint2D)
        SpringJoint2D spring = gameObject.GetComponent<SpringJoint2D>();
        if (spring != null)
        {
            spring.enabled = false;
        }

        this.enabled = false;  // Отключаем компонент

        // Подождем, пока птичка долетит, затем спавним новую
        yield return new WaitForSeconds(3f);  // Уменьшаем задержку перед появлением новой птицы

        birdManager.SpawnNewBird();  // Создаем новую птицу через BirdManager
    }

    // Метод для установки ссылки на BirdManager
    public void SetBirdManager(BirdManager manager)
    {
        birdManager = manager;
    }
}
