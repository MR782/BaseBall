using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //タイトルシーン用
    public bool ispushed_StartButton = false;

    public static int[] Base = new int[4]; //ベースの数

    /// <summary>
    /// 走者
    /// </summary>
    public Runner Runner_A;
    public Runner Runner_B;
    /// <summary>
    /// 打者
    /// </summary>
    public Batter Batter_A;
    public Batter Batter_B;
    /// <summary>
    /// 投手
    /// </summary>
    public Pitcher Pitcher_A;
    public Pitcher Pitcher_B;

    //自分自身を生成し、シーン遷移により破壊されないようにする
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
