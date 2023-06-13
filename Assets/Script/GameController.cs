using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //�^�C�g���V�[���p
    public bool ispushed_StartButton = false;

    public static int[] Base = new int[4]; //�x�[�X�̐�

    /// <summary>
    /// ����
    /// </summary>
    public Runner Runner_A;
    public Runner Runner_B;
    /// <summary>
    /// �Ŏ�
    /// </summary>
    public Batter Batter_A;
    public Batter Batter_B;
    /// <summary>
    /// ����
    /// </summary>
    public Pitcher Pitcher_A;
    public Pitcher Pitcher_B;

    //�������g�𐶐����A�V�[���J�ڂɂ��j�󂳂�Ȃ��悤�ɂ���
    public static GameController instance = null;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
