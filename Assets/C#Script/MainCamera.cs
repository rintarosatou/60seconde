using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;          // �v���C���[
    public Vector3 offset = new Vector3(0, 2, -4);  // �J�����̑��Έʒu
    public float RotationSpeed = 5.0f;
    public float SmoothSpeed = 0.125f;
    private float _currentYaw = 0f;

    void LateUpdate()
    {
        // �}�E�X�̉��ړ��ŉ�]
        _currentYaw += Input.GetAxis("Mouse X") * RotationSpeed;

        // �J�����̉�]���v�Z
        Quaternion rotation = Quaternion.Euler(0, _currentYaw, 0);

        // �ڕW�̈ʒu
        Vector3 desiredPosition = target.position + rotation * offset;

        // �X���[�Y�Ɉړ�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

        // ��Ƀv���C���[������
        transform.LookAt(target);
    }
}
