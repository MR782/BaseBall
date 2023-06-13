using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    //アニメーター
    [SerializeField] private Animator _animator;
    //レイヤー
    [SerializeField] private int _layer;

    /// <summary>
    ///開かれているかのフラグ 
    /// </summary>
    private static readonly int ParamIsOpen = Animator.StringToHash("isOpen");
    public bool isOpen => gameObject.activeSelf;

    // アニメーション中かどうか
    public bool isTransition { get; private set; }

    // ダイアログを開く
    public void Open()
    {
        // 既に開かれているなら操作を実施しない
        if (this.isOpen || this.isTransition) return;

        // パネル自体アクティブ状態へ
        gameObject.SetActive(true);

        // Openフラグセット
        _animator.SetBool(ParamIsOpen, true);

        // アニメーション待機
        StartCoroutine(WaitAnimation("DialogOpen"));
    }

    // ダイアログを閉じる
    public void Close()
    {
        // 不正操作防止
        if (!this.isOpen || this.isTransition) return;

        // IsOpenフラグをクリア
        _animator.SetBool(ParamIsOpen, false);

        // アニメーション待機し、終わったらパネル自体を非アクティブにする
        StartCoroutine(WaitAnimation("DialogClose", () => gameObject.SetActive(false)));
    }

    // 開閉アニメーションの待機コルーチン
    private IEnumerator WaitAnimation(string stateName, UnityAction onCompleted = null)
    {
        this.isTransition = true;

        yield return new WaitUntil(() =>
        {
            // ステートが変化し、アニメーションが終了するまでループ
            var state = _animator.GetCurrentAnimatorStateInfo(_layer);
            return state.IsName(stateName) && state.normalizedTime >= 1;
        });

        this.isTransition = false;

        onCompleted?.Invoke();
    }
}
