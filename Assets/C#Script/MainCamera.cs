using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;          // プレイヤー
    public Vector3 offset = new Vector3(0, 2, -4);  // カメラの相対位置
    public float RotationSpeed = 5.0f;
    public float SmoothSpeed = 0.125f;
    private float _currentYaw = 0f;

    void LateUpdate()
    {
        // マウスの横移動で回転
        _currentYaw += Input.GetAxis("Mouse X") * RotationSpeed;

        // カメラの回転を計算
        Quaternion rotation = Quaternion.Euler(0, _currentYaw, 0);

        // 目標の位置
        Vector3 desiredPosition = target.position + rotation * offset;

        // スムーズに移動
        transform.position = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

        // 常にプレイヤーを見る
        transform.LookAt(target);
    }
}
