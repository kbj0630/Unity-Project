using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }
    }
}
