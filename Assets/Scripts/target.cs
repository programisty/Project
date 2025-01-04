using UnityEngine;

public class target : MonoBehaviour
{   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
        }
    }
}
