using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 6f; // 탄알이동 속력
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // 직접 넣을 필요 없음
        bulletRigidbody.velocity = transform.forward * speed; // 앞으로 이동하는 방향을 가진 속도

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "Player") // 충돌한 게 플레이어일때
        {
            PlayerController playerController = _other.GetComponent<PlayerController>();
            if (playerController != null)
                playerController.Die();
        }
    }
}