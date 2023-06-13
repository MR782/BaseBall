using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{


    [SerializeField] float pitch_interval = 0.0f;//投球間隔
    public BallCreater.BallKind[] Balls = new BallCreater.BallKind[10];//投手が投げるボールの種類
    
    //投手が投げるボールの種類


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
