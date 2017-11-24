using UnityEngine;
using UnityEngine.UI;

public class UserItemData
{
    public string id;           // 유저아이디
    public float earningRate;   // 수익율
    public int betPrice;        // 배팅금액
    public float bonus;         // 보너스
    public float earning;       // 수익
}

public class UserItemTableViewCell : TableViewCell<UserItemData>
{
    public Text id;
    public Text earningRate;
    public Text betPrice;
    public Text bonus;
    public Text earning;

    public override void UpdteContent(UserItemData itemData)
    {
        id.text = itemData.id;
        earningRate.text = string.Format("{0:N2}x", itemData.earningRate);
        betPrice.text = string.Format("{0:#,##0}", itemData.betPrice);
        bonus.text = string.Format("{0:N2}%", itemData.bonus);
        earning.text = string.Format("{0:N2}", itemData.earning);
    }
}

