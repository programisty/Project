using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetManager targetManager;

    public void SetTargetManager(TargetManager manager)
    {
        targetManager = manager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);  // Удаляем мишень
            targetManager.TargetDestroyed();  // Увеличиваем счётчик уничтоженных мишеней
            targetManager.SpawnTarget();  // Спавним новую мишень
        }
    }
}