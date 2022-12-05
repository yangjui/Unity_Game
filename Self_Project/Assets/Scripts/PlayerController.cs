using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField]
    private float speed = 3f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // 직접 드래그 할 필요 없이 코드상에서 설정
    }
    private void Update()
    {
        // playerAddForce();

        float xInput = Input.GetAxis("Horizontal"); // x축 y축 중 어디로 이동할지 받기
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed; // 이동방향 적용된 이동 속도!
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 최종적으로 이동 할 방향으로의 속도 ! --> 대각선 방향이 입력될 수도 있으니까!
        // 위의 코드까지는 위 아래로만 이동 가능

        playerRigidbody.velocity = newVelocity;
    }

    // AddForce : 관성이 적용되어 무게감 느껴짐. 누적된 힘으로 점진적 증가 속도 !
    // 반대방향 이동 시 관성에 의해 힘 상쇄 --> 전환 느림
    private void playerAddForce()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
            playerRigidbody.AddForce(0f, 0f, speed);
        if (Input.GetKey(KeyCode.DownArrow) == true)
            playerRigidbody.AddForce(0f, 0f, -speed);
        if (Input.GetKey(KeyCode.RightArrow) == true)
            playerRigidbody.AddForce(speed, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow) == true)
            playerRigidbody.AddForce(-speed, 0f, 0f);
    }

    public void Die() // 사망시 플레이어 비활성화 --> 외부에서 접근됨 !!! public
    {
        gameObject.SetActive(false); // 여기서의 게임 오브젝트는 플레이어 객체
    }
}