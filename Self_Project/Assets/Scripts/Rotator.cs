using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float RotationSpeed = 30f;

    private void Update()
    {
        transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0f);
        // 1초에 30도씩 회전
    }
}
