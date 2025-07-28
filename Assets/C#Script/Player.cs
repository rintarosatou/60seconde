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
            transform.position += gameObject.transform.forward * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isMoving = true;
        }

            // S�L�[�i����ړ��j
            if (Input.GetKey(KeyCode.S))
        {
            transform.position -= -gameObject.transform.forward * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            isMoving = true;
        }
        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.05f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90f, 0);
            isMoving = true;
        }
        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0.05f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270f, 0); 
            isMoving = true;
        }
        // �A�j���[�V�����؂�ւ��i�����Ă邩�ǂ����Łj
        animator.SetBool("Run", isMoving);
        // �����ꂩ�̈ړ��L�[�������ꂽ��A�j���[�V������~
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Run", false);// �A�j���[�V�������~�iRun �� Idle�Ȃǁj
        }
    }
}
