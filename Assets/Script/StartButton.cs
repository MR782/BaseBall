using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

#pragma warning disable CS0108 // メンバーは継承されたメンバーを非表示にします。キーワード new がありません
    [SerializeField] private AudioClip startSE;
    private AudioSource audio;
#pragma warning restore CS0108 // メンバーは継承されたメンバーを非表示にします。キーワード new がありません

    // Start is called before the first frame update
    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        GameController.instance.ispushed_StartButton = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ボタンが押されたらシーンを変える
    public void OnClickStartButton()
    {
        //ボタンが押されたとき１回だけ動作させる
        if (GameController.instance.ispushed_StartButton == false)
        {
            GameController.instance.ispushed_StartButton = true;
            this.audio.PlayOneShot(startSE);
            Invoke("SceneChange", 3.0f);
        }
    }

    public void SceneChange()
    {
        //SceneManager.LoadScene("game");
    }
}
