using UnityEngine;
using UnityEngine.UI;

public class UserItemData
{
    public string id;           // 유저아이디
    public int nEarningRate;    // 수익율
    public int betPrice;        // 배팅금액
    public float bonus;         // 보너스
    public float earning;       // 수익
}

public enum MyColor
{
    RED,
    GREEN,
    WHITE,
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
        float rate = (float)itemData.nEarningRate / 100.0f;
        earningRate.text = string.Format("{0:0.00}x", rate);
        betPrice.text = string.Format("{0:#,##0}", itemData.betPrice);
        bonus.text = string.Format("{0:N2}%", itemData.bonus);
        earning.text = string.Format("{0:N2}", itemData.earning);
    }

    public override void ChangeColor(UserItemData itemdata, MyColor color)
    {
        string colorString = "<Color=#000000>";
        if(color == MyColor.RED)
            colorString = "<Color=#ff0000>";
        else if (color == MyColor.GREEN)
            colorString = "<Color=#00ff00>";

        id.text = colorString + itemdata.id + "</color>";
        string tempRate = string.Format("{0:0.00}x", (float)itemdata.nEarningRate / 100.0f);
        earningRate.text = colorString + tempRate + "</color>";
        betPrice.text = colorString + itemdata.betPrice + "</color>";
        bonus.text = colorString + itemdata.bonus + "</color>";
        earning.text = colorString + itemdata.earning + "</color>";
    }
}

