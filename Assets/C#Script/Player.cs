using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using TMPro.EditorUtilities;
#endif

public class Player : MonoBehaviour
{
    // Animator�i�A�j���[�V�����j�� Rigidbody�i�W�����v�Ɏg�p�j
    private Animator animator;
    public Rigidbody _rd = null;
    // Start is called before the first frame update
    void Start()
    {
        //�f����60fps�Œ�
        Application.targetFrameRate = 60;
        Debug.Log("start");

        // Rigidbody ���擾
        _rd = GetComponent<Rigidbody>();

        // Animator ���擾�i"Run" �A�j���[�V�����؂�ւ��p�j
        animator = GetComponent<Animator>();
    }
    private void Awake()// �Q�[���J�n�O�Ɉ�x�����Ă΂��i���� Start ���������j
    {
        Debug.Log("Awake");// �N�������m�F����p�̃��O
    }
    //1�t���[���Ɉ�񏈗������Ă����
    // Update is called once per frame
    // ���x�𒲐����₷�����邽�߂� speed ���`
    public float moveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;

        //W�L�[(�O�i�ړ�)
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += gameObject.transform.forward * moveSpeed * Time.deltaTime;// Z�����Ɉړ�
            transform.rotation = Quaternion.Euler(0, 0, 0);// ���ʂ�����
            isMoving = true;
        }
        // S�L�[�i����ړ��j
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= -gameObject.transform.forward * moveSpeed * Time.deltaTime;// Z�����Ɍ��
            transform.rotation = Quaternion.Euler(0, 180f, 0);// ������
            isMoving = true;
        }
        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.05f, 0, 0);// X�����ɉE�ړ�
            transform.rotation = Quaternion.Euler(0, 90f, 0);// �E������
            isMoving = true;
        }
        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0.05f, 0, 0);// X�����ɍ��ړ�
            transform.rotation = Quaternion.Euler(0, 270f, 0); // ��������
            isMoving = true;
        }
        // �A�j���[�V�����؂�ւ��i�����Ă邩�ǂ����Łj
        animator.SetBool("Run", isMoving);
        //Space�L�[�i�W�����v�jRaycast �Œn�ʂɂ���Ƃ��̂�
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rd.AddForce(new Vector3(0, 250, 0));// �W�����v�̗́i�����\�j

        }
        // �����ꂩ�̈ړ��L�[�������ꂽ��A�j���[�V������~
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Run", false);// �A�j���[�V�������~�iRun �� Idle�Ȃǁj
        }
        // --- �����ɒn�ʂ����邩�ǂ����𔻒肷�� ---
        bool IsGrounded()
        {
            // �v���C���[�̈ʒu����^���Ɍ������� Ray �� 1.1 ���j�b�g��΂�
            //�I�u�W�F�N�g�̑O�≺�ɁuRay�i�����j�v���΂��āA
            // **�u�����ɓ����������H�v**�𒲂ׂ�̂Ɏg��
            // �����i�n�ʂȂǁj�ɂԂ������� true�A�Ԃ���Ȃ���� false ��Ԃ�
            return Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }
    }
}
