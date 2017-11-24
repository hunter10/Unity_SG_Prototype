using UnityEngine;
using System.Collections;



public class GameManager : MonoBehaviour {

    public enum GAMESTATE
    {
        NONE,
        READY,
        COUNTDOWN,
        GAME,
        RESULT
    }

    public GAMESTATE currState = GAMESTATE.NONE;
    public int COUNTDOWN = 3;

    public UserItemTableViewController userListview;

    float SetBettingRate = 1.03f;

    public void Start()
    {
        currState = GAMESTATE.READY;
    }

    public void OnBettingClick()
    {
        Debug.Log("betting...");
        // 기준값 1.03보다 초과면 빨간새으로 
        // 기준값 1.03보다 이하면 녹색으로

        Debug.Log("유저리스트 : " + userListview.GetUserList().Count);
    }

    public void OnGameStartClick()
    {
        currState = GAMESTATE.COUNTDOWN;
        StartCoroutine(Proc_GameStart());
    }

    int currCountDown = 0;
    IEnumerator Proc_GameStart()
    {
        float deltatime = 0;
        while(deltatime >= 1)
        {
            deltatime += Time.deltaTime;
            deltatime = 0;
            currCountDown++;

            if(currCountDown == COUNTDOWN)
            {
                break;
            }

            yield return null;
        }

        yield break;
    }
}

