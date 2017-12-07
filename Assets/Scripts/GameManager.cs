using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
//using System.Diagnostics;
using System.Threading;

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

    DateTime startTime;
    public void OnGraphCalcStart()
    {
        //DateTime startT = DateTime.Now;
        //UnityEngine.Debug.Log(startT.Millisecond);

        //startTime = DateTime.Now;
        //StartCoroutine(ProcGraphCalcStartTest());
        //UnityEngine.Debug.Log(DateTime.Now.Ticks);
        //UnityEngine.Debug.Log(DateTime.Now.Millisecond);



        // C# 예제
        int value = 2;
        for (int power = 0; power <= 32; power++) {
            string temp = string.Format("{0}^{1}={2:N0} (0x{2:X})", value, power, (long)Math.Pow(value, power));
            Debug.Log(temp);
        }



        /*
        // 시간지연 측정
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Thread.Sleep(10000);
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

        UnityEngine.Debug.Log(elapsedTime);
        */
    }

    IEnumerator ProcGraphCalcStartTest()
    {
        while (true)
        {
            int elapsed = DateTime.Now.Millisecond - startTime.Millisecond;
            growthFunc(elapsed);
            //var at = growthFunc(elapsed);
            //Debug.Log(elapsed + ", " + at);
            yield return null;
        }
    }

    void growthFunc(long ms)
    {
        double r = 0.00006f;
        //return Math.Floor(100.0f * Math.Pow(Math.E, r * ms));
        
        double a = Math.Exp(r * ms);
        //double a1 = Math.Pow(Math.E, r * ms);
        //Debug.Log("a:" + a + ", a1:" + a1);
        double b = 100 * a;
        double c = Math.Floor(b);

        UnityEngine.Debug.Log(a + ",   " + b + ",   " + c);
    }

    public void OnGameStopClick()
    {
        //Debug.Log("유저리스트 : " + userListview.GetUserList().Count);
        userListview.ChangeColorState(nBaseBettingRate);
    }

    public void OnBettingClick()
    {
        //Debug.Log("betting...");
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
                //Debug.Log("CountDown : " + currCountDown);
                gameLabel.text = string.Format("{0}", currCountDown);
                if (currCountDown == COUNTDOWN)
                {
                    currState = GAMESTATE.GAMING;
                    //Debug.Log("Game Start ...");
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

