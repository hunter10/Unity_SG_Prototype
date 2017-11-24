using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ScrollRect))]
public class UserItemTableViewController : TableViewController<UserItemData>
{
    private void LoadData()
    {
        tableData = new List<UserItemData>()
        {
            // 맨 아래가 최초 추가된것임.
            new UserItemData { id="dhdtkxkds", earningRate=1.04f, betPrice=10000, bonus=0.0f, earning=0.0f },
            // ---------- 여기서부터 위로 꽝
            new UserItemData { id="qwer08177", earningRate=1.03f, betPrice=20000, bonus=4.74f, earning=1547.90f },
            new UserItemData { id="zzzxc74289", earningRate=1.02f, betPrice=24000, bonus=4.74f, earning=1617.48f },
            new UserItemData { id="saint951w", earningRate=1.01f, betPrice=100000, bonus=0.87f, earning=1868.91f },
            new UserItemData { id="pjy0406900", earningRate=1.01f, betPrice=110000, bonus=0.87f, earning=2055.80f },
        };

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
    }

    public void ChangeColorState()
    {

    }
}

