using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public GameObject prefabToSpawn;

    private Transform spawn;
    private float spawnRate = 4f;
    private float timeAfterSpawn;
    private float spawnerWidth;
    private GameManager gameManager;

    void Start() {
        timeAfterSpawn = 0f;

        Enemy enemyObject = FindObjectOfType<Enemy>();
        if (enemyObject != null) {
            spawn = enemyObject.transform;
        } else {
            Debug.LogError("Enemy 오브젝트를 찾을 수 없습니다!");
        }

        gameManager = FindObjectOfType<GameManager>();

        // 스포너의 가로 길이 설정
        spawnerWidth = transform.localScale.x;
    }

    void Update() {

        if (gameManager != null && gameManager.isGameOver) {
            return;
        }

        timeAfterSpawn += Time.deltaTime;
        
        if (timeAfterSpawn >= spawnRate) {
            timeAfterSpawn = 0f;
            
            // 가로 길이 중 랜덤한 위치 계산
            float randomX = Random.Range(-spawnerWidth / 2f, spawnerWidth / 2f);
            Vector3 spawnPosition = transform.position + new Vector3(randomX, 0f, 0f);
            GameObject enemy = Instantiate(prefabToSpawn, spawnPosition, transform.rotation);
            
            if (spawn != null) {
                enemy.transform.LookAt(spawn);
            } else {
                Debug.LogError("Spawn 위치를 설정할 오브젝트를 찾을 수 없습니다!");
            }
        }
    }
}
