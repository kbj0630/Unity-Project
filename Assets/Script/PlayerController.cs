using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 3f;
    public float rotationSpeed = 200.0f;

    Vector3 lookDirection;

    // Start is called before the first frame update
    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed).normalized;
        
        if (!(xInput == 0 && zInput == 0)) {
            transform.position += newVelocity * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                                Quaternion.LookRotation(newVelocity), Time.deltaTime * rotationSpeed);
        }

        playerRigidbody.velocity = newVelocity;
    }

    public void Die() {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
