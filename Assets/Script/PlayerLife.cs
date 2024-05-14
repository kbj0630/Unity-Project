using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {
    public int maxLife = 5; // 최대 라이프
    public float invincibleTime = 2f; // 무적 시간

    private int currentLife; // 현재 라이프
    private bool isInvincible = false; // 무적 상태 여부
    private float invincibleTimer = 0f; // 무적 타이머
    private GameManager gameManager;

    void Start() {
        currentLife = maxLife; // 초기 라이프 설정
        gameManager = FindObjectOfType<GameManager>();
        gameManager.UpdateLifeText(currentLife);
    }

    void Update() {
        // 무적 타이머 업데이트
        if (isInvincible) {
            invincibleTimer += Time.deltaTime;
            if (invincibleTimer >= invincibleTime) {
                isInvincible = false;
                invincibleTimer = 0f;
            }
        }
    }

    // 충돌 처리
    void OnCollisionEnter(Collision collision) {
        // 충돌한 오브젝트가 Enemy인지 확인
        if (collision.gameObject.tag == "Enemy") {
            if (!isInvincible) {
                TakeDamage();
            }
        }
    }

    // 라이프 차감 및 무적 상태 설정
    void TakeDamage() {
        currentLife--; // 라이프 차감
        Debug.Log("Life: " + currentLife);

        // 무적 상태로 변경
        isInvincible = true;
        invincibleTimer = 0f;

        gameManager.UpdateLifeText(currentLife);

        if (currentLife <= 0) {
            gameManager.EndGame();
        }
    }
}
