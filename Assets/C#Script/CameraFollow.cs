using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // プレイヤーのTransform
    public Vector3 offset = new Vector3(0, 5, -10); // プレイヤーとの距離（視点）
    public float smoothTime = 0.3f;    // 追従のスムーズさ（大きいほどゆっくり）

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (player != null) return;

        Vector3 tragetPosition = player.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, tragetPosition, ref velocity, smoothTime);
    }
}
