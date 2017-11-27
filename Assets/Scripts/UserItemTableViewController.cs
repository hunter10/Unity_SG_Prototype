using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ScrollRect))]
public class UserItemTableViewController : TableViewController<UserItemData>
{
    int compareIndex = 0;

    private void LoadData()
    {
        tableData = new List<UserItemData>()
        {
            new UserItemData { id="pjy0406900", nEarningRate=101, betPrice=110000, bonus=0.87f, earning=2055.80f },
            new UserItemData { id="saint951w", nEarningRate=111, betPrice=100000, bonus=0.87f, earning=1868.91f },
            new UserItemData { id="saint951a", nEarningRate=112, betPrice=100000, bonus=0.87f, earning=1868.91f },
            new UserItemData { id="saint951b", nEarningRate=152, betPrice=100000, bonus=0.87f, earning=1868.91f },
            new UserItemData { id="zzzxc74289", nEarningRate=202, betPrice=24000, bonus=4.74f, earning=1617.48f },
            new UserItemData { id="qwer08177", nEarningRate=233, betPrice=20000, bonus=4.74f, earning=1547.90f },
            // 타임 지연 효과를 위해 100배씩 증가
            
            // ---------- 여기서부터 기준값 오버
            new UserItemData { id="dhdtkxkds", nEarningRate=301, betPrice=10000, bonus=0.0f, earning=0.0f },
        };


        //-------------------------------------
        // 오름차순으로 소트해서 업데이트해야 함.
        
        tableData.Sort(delegate (UserItemData a, UserItemData b)
        {
            if (a.nEarningRate > b.nEarningRate) return -1;
            else if(a.nEarningRate < b.nEarningRate) return 1;
            return 0;
        });

        // 오름차순이기 때문에 맨 끝이 젤 작은 수.
        compareIndex = tableData.Count - 1;
        
        //-------------------------------------


        //-------------------------------------
        // 내림차순 상태로 처리된다면
        // compareIndex = 0;
        //-------------------------------------


        // 스크롤시킬 내용의 크기를 갱신한다
        UpdateContents();
    }

    public List<UserItemData> GetUserList()
    {
        return tableData;
    }

    // 리스트 항목에 대응하는 셀의 높이를 반환하는 메서드
    protected override float CellHeightAtIndex(int index)
    {
        return 40.0f;
    }

    // 인스턴스를 로드할 때 호출된다
    protected override void Awake()
    {
        // 기반 클래스에 포함된 Awake 메서드를 호출한다
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        // 리스트 항목의 데이터를 읽어 들인다
        LoadData();

        GameManager.Instance.OnIncrementEvent += OnIncrementEvent;
    }

    // 전체 유저를 한꺼번에 바꿀때
    public void ChangeColorState(float fBaseBettingRate)
    {
        for(int i=0; i<tableData.Count; i++)
        {
            if(tableData[i].nEarningRate <= fBaseBettingRate)
                CellAttributeChange(i, MyColor.GREEN);
            else
                CellAttributeChange(i, MyColor.RED);
        }
    }

    
    public void OnIncrementEvent(int currRate)
    {
        Debug.Log("currRate:" + currRate);
        while (currRate >= tableData[compareIndex].nEarningRate)
        {
            // 속성값 증가
            // 비교인덱스 증가
            Debug.Log("     " + tableData[compareIndex].id + ", " + tableData[compareIndex].nEarningRate);
            CellAttributeChange(compareIndex, MyColor.GREEN);

            // 오름차순 처리일때
            compareIndex--;

            // 내림차순 처리일때
            //compareIndex++;
        }
    }
}

