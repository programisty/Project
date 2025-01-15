using UnityEngine;

public class Target : Sounds
{
    private TargetManager targetManager;
    [SerializeField] public float speed = 2.0f;   
    [SerializeField] public float distance = 2.0f;      
    private float originalY;
    private bool movingUp = true;

    void Start()
    {
        originalY = transform.position.y; // Запоминаем начальную позицию по Y
    }

    void Update()
    {
        float newY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;

        // Проверяем границы движения
        if (movingUp && newY >= originalY + distance)
        {
            newY = originalY + distance;
            movingUp = false;
        }
        else if (!movingUp && newY <= originalY - distance)
        {
            newY = originalY - distance;
            movingUp = true;
        }

        transform.position = new Vector2(transform.position.x, newY); // Обновляем позицию
    }

    public void SetTargetManager(TargetManager manager)
    {
        targetManager = manager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            PlaySound(sounds[0], volume: 2f, destroyed:true);
            Destroy(gameObject);    
            targetManager.TargetDestroyed();      
            targetManager.SpawnTarget();     
        }
    }
}