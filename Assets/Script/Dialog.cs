using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    //�A�j���[�^�[
    [SerializeField] private Animator _animator;
    //���C���[
    [SerializeField] private int _layer;

    /// <summary>
    ///�J����Ă��邩�̃t���O 
    /// </summary>
    private static readonly int ParamIsOpen = Animator.StringToHash("isOpen");
    public bool isOpen => gameObject.activeSelf;

    // �A�j���[�V���������ǂ���
    public bool isTransition { get; private set; }

    // �_�C�A���O���J��
    public void Open()
    {
        // ���ɊJ����Ă���Ȃ瑀������{���Ȃ�
        if (this.isOpen || this.isTransition) return;

        // �p�l�����̃A�N�e�B�u��Ԃ�
        gameObject.SetActive(true);

        // Open�t���O�Z�b�g
        _animator.SetBool(ParamIsOpen, true);

        // �A�j���[�V�����ҋ@
        StartCoroutine(WaitAnimation("DialogOpen"));
    }

    // �_�C�A���O�����
    public void Close()
    {
        // �s������h�~
        if (!this.isOpen || this.isTransition) return;

        // IsOpen�t���O���N���A
        _animator.SetBool(ParamIsOpen, false);

        // �A�j���[�V�����ҋ@���A�I�������p�l�����̂��A�N�e�B�u�ɂ���
        StartCoroutine(WaitAnimation("DialogClose", () => gameObject.SetActive(false)));
    }

    // �J�A�j���[�V�����̑ҋ@�R���[�`��
    private IEnumerator WaitAnimation(string stateName, UnityAction onCompleted = null)
    {
        this.isTransition = true;

        yield return new WaitUntil(() =>
        {
            // �X�e�[�g���ω����A�A�j���[�V�������I������܂Ń��[�v
            var state = _animator.GetCurrentAnimatorStateInfo(_layer);
            return state.IsName(stateName) && state.normalizedTime >= 1;
        });

        this.isTransition = false;

        onCompleted?.Invoke();
    }
}
