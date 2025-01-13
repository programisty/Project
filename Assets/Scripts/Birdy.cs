using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdRb;
    [SerializeField] private Rigidbody2D pointRb;

    private BirdManager birdManager;  // Ссылка на BirdManager
    private bool isTouched = false;

    public float maxDist = 1f;

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
        StartCoroutine(Fly());
    }
    IEnumerator Fly()
    {
        yield return new WaitForSeconds(0.05f);
        SpringJoint2D spring = gameObject.GetComponent<SpringJoint2D>();
        if (spring != null)
        {
            spring.enabled = false;
        }

        this.enabled = false;

        yield return new WaitForSeconds(2f);
        birdManager.SpawnNewBird();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
            birdManager.SpawnNewBird();
        }
    }

    public void SetBirdManager(BirdManager manager)
    {
        birdManager = manager;
    }
}