using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public float speed = 0.5f;
    private Transform player;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        // 태그로 플레이어 찾기
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!gameManager.isGameOver) {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damageAmount) {
        hp -= damageAmount;
        if (hp <= 0) {
            Die();
        }
    }

    void Die() {
        gameManager.IncreaseKillScore();
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Spawner")) {
            return;
        }
    }
}