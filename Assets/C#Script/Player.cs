using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using TMPro.EditorUtilities;
#endif

public class Player : MonoBehaviour
{
    // Animator（アニメーション）と Rigidbody（ジャンプに使用）
    private Animator animator;
    public Rigidbody _rd = null;
    // Start is called before the first frame update
    void Start()
    {
        //映像を60fps固定
        Application.targetFrameRate = 60;
        Debug.Log("start");

        // Rigidbody を取得
        _rd = GetComponent<Rigidbody>();

        // Animator を取得（"Run" アニメーション切り替え用）
        animator = GetComponent<Animator>();
    }
    private void Awake()// ゲーム開始前に一度だけ呼ばれる（他の Start よりも早く）
    {
        Debug.Log("Awake");// 起動順を確認する用のログ
    }
    //1フレームに一回処理をしてくれる
    // Update is called once per frame
    // 速度を調整しやすくするために speed を定義
    public float moveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;

        //Wキー(前進移動)
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += gameObject.transform.forward * moveSpeed * Time.deltaTime;// Z方向に移動
            transform.rotation = Quaternion.Euler(0, 0, 0);// 正面を向く
            isMoving = true;
        }
        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= -gameObject.transform.forward * moveSpeed * Time.deltaTime;// Z方向に後退
            transform.rotation = Quaternion.Euler(0, 180f, 0);// 後ろ向き
            isMoving = true;
        }
        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.05f, 0, 0);// X方向に右移動
            transform.rotation = Quaternion.Euler(0, 90f, 0);// 右を向く
            isMoving = true;
        }
        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0.05f, 0, 0);// X方向に左移動
            transform.rotation = Quaternion.Euler(0, 270f, 0); // 左を向く
            isMoving = true;
        }
        // アニメーション切り替え（動いてるかどうかで）
        animator.SetBool("Run", isMoving);
        //Spaceキー（ジャンプ）Raycast で地面にいるときのみ
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rd.AddForce(new Vector3(0, 250, 0));// ジャンプの力（調整可能）

        }
        // いずれかの移動キーが離されたらアニメーション停止
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Run", false);// アニメーションを停止（Run → Idleなど）
        }
        // --- 足元に地面があるかどうかを判定する ---
        bool IsGrounded()
        {
            // プレイヤーの位置から真下に向かって Ray を 1.1 ユニット飛ばす
            //オブジェクトの前や下に「Ray（光線）」を飛ばして、
            // **「何かに当たったか？」**を調べるのに使う
            // 何か（地面など）にぶつかったら true、ぶつからなければ false を返す
            return Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }
    }
}
