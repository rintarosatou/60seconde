using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // �v���C���[��Transform
    public Vector3 offset = new Vector3(0, 5, -10); // �v���C���[�Ƃ̋����i���_�j
    public float smoothTime = 0.3f;    // �Ǐ]�̃X���[�Y���i�傫���قǂ������j

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (player != null) return;

        Vector3 tragetPosition = player.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, tragetPosition, ref velocity, smoothTime);
    }
}
