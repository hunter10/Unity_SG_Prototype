using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using LitJson;

public class TestJson : MonoBehaviour {

    private List<Item> database = new List<Item>();
    private JsonData itemData;

	public class Item
    {
        public string ID { get; set; }               // 유저아이디
        public float EarningRate { get; set; }       // 수익율
        public int BetPrice { get; set; }            // 베팅금액
        public float Bonus { get; set; }             // 보너스
        public float EarningPrice { get; set; }      // 수익

        public Item() { }
        public Item(string id, float earningRate, int betPrice, float bonus, float earningPrice)
        {
            this.ID = id;
            this.EarningRate = earningRate;
            this.BetPrice = betPrice;
            this.Bonus = bonus;
            this.EarningPrice = earningPrice;
        }
    }

    private void Awake()
    {
        JsonLoad();
    }

    void JsonLoad()
    {
        
    }

    public TextAsset jsonData;
    private void OnGUI()
    {
        if(GUILayout.Button("Load"))
        {
            LitJson.JsonData getData = LitJson.JsonMapper.ToObject(jsonData.text);

            JsonData userArray = getData["userArray"];
            for (int i = 0; i < userArray.Count; i++)
            {
                JsonData userData = userArray[i];

                Item item = new Item();
                item.ID = userData["id"].ToString();
                item.EarningRate = float.Parse(userData["earningRate"].ToString());
                item.BetPrice = int.Parse(userData["betPrice"].ToString());
                item.Bonus = float.Parse(userData["bonus"].ToString());
                item.EarningPrice = float.Parse(userData["earningPrice"].ToString());

                database.Add(item);
            }

            foreach(Item i in database)
            {
                Debug.Log("id:" + i.ID + ", bonus:" + i.Bonus);
            }
        }
    }
}

