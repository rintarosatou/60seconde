using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;          // プレイヤー
    public Vector3 offset = new Vector3(0, 2, -4);  // カメラの相対位置
    public float rotationSpeed = 5.0f;
    public float smoothSpeed = 0.125f;

    private float currentYaw = 0f;

    void LateUpdate()
    {
        // マウスの横移動で回転
        currentYaw += Input.GetAxis("Mouse X") * rotationSpeed;

        // カメラの回転を計算
        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);

        // 目標の位置
        Vector3 desiredPosition = target.position + rotation * offset;

        // スムーズに移動
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 常にプレイヤーを見る
        transform.LookAt(target);
    }
}
