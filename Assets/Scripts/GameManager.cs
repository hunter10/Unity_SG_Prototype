using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager> {

    public enum GAMESTATE
    {
        NONE,
        READY,
        COUNTDOWN,
        GAMING,
        RESULT
    }

    public GAMESTATE currState = GAMESTATE.NONE;
    public int COUNTDOWN = 3;

    public UserItemTableViewController userListview;

    int nCurrBettingRate = 100;    // 1.00 부터 시작
    //float baseBettingRate = 1.03f;   // 기준배율
    int nBaseBettingRate = 300;   // 기준배율(x100해서 사용), (1.40 표현상의 차이는 있음.)

    public ProcScript _procScript = null;


    public Text gameLabel;

    public delegate void IncrementEvent(int rate);
    public IncrementEvent OnIncrementEvent;

    public void Start()
    {
        currState = GAMESTATE.READY;
        
    }


    public void OnGameStopClick()
    {
        Debug.Log("유저리스트 : " + userListview.GetUserList().Count);
        userListview.ChangeColorState(nBaseBettingRate);
    }

    public void OnBettingClick()
    {
        Debug.Log("betting...");
    }

    public void OnGameStartClick()
    {
        nCurrBettingRate = 100;
        currState = GAMESTATE.COUNTDOWN;
        StartCoroutine(Proc_CountDownStart());

        //_procScript.AddProc("Proc_CountDownStart");
    }



    int currCountDown = 0;
    IEnumerator Proc_CountDownStart()
    {
        float deltatime = 0;
        while(deltatime <= 1)
        {
            deltatime += Time.deltaTime;
            if (deltatime > 1)
            {
                deltatime = 0;
                currCountDown++;
                Debug.Log("CountDown : " + currCountDown);
                gameLabel.text = string.Format("{0}", currCountDown);
                if (currCountDown == COUNTDOWN)
                {
                    currState = GAMESTATE.GAMING;
                    Debug.Log("Game Start ...");
                    break;
                }
            }
            yield return null;
        }

        StartCoroutine("Proc_GameStart");

        //_procScript.DoneProc();
        yield break;
    }

    IEnumerator Proc_GameStart()
    {
        while(nCurrBettingRate < nBaseBettingRate)
        {
            nCurrBettingRate += 1;
            //Debug.Log("currBettingRate:" + nCurrBettingRate);
            gameLabel.text = string.Format("{0:0.00}x", nCurrBettingRate / 100.0f);
            //-------------------------------
            // 이부분을 큐 처리? 
            if (OnIncrementEvent != null)
                OnIncrementEvent(nCurrBettingRate);
            //-------------------------------

            yield return null;
        }

        gameLabel.text = string.Format("게임결과\n@{0:0.00}x", nCurrBettingRate / 100.0f);
        
    }
}

