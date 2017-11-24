namespace NetmarbleS.Internal
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using LitJson;

    public class CallbackMessage
    {
        private string message;
        private IDictionary messageDic;
        private JsonData data;

        public CallbackMessage(string message)
        {
            this.message = message;
            messageDic = JsonMapper.ToObject(this.message) as IDictionary;
        }

        public int GetInt(string key)
        {
            return messageDic.GetInt(key);
        }
        
        public string GetString(string key)
        {
            return messageDic.GetString(key);
        }

        public bool GetBool(string key)
        {
            return messageDic.GetBool(key);
        }

        public IList GetList(string key)
        {
            if (messageDic.Contains(key))
            {
                IList list = messageDic[key] as IList;
                return list;
            }
            else
            {
                Log.Warning("[CallbackMessage] Key not found : " + key);
                return null;
            }
            
        }

        public IDictionary GetDictionary(string key)
        {
            if (messageDic.Contains(key))
            {

                IDictionary dic = messageDic[key] as IDictionary;
                return dic;
            }
            else
            {
                Log.Warning("[CallbackMessage] Key not found : " + key);
                return null;
            }
        }

        //public CallbackMessage GetCallbackMessage(string key)
        //{
        //    string json = Convert.ToString(messageDict[key]);
        //    CallbackMessage message = new CallbackMessage(json);
        //    return message;
        //}

        public Result GetResult()
        {
            if (messageDic.Contains("result"))
            {
               IDictionary resultDic = messageDic["result"] as IDictionary;

               string domain = resultDic.GetString("domain");
               int code = resultDic.GetInt("code");
               int detailCode = resultDic.GetInt("detailCode"); 
               string message = resultDic.GetString("message");
               Result result = new Result(domain, code, detailCode, message);
               return result;
            }
            else
            {
                return null;
            }
        }

        public int GetHandlerNum()
        {
            return messageDic.GetInt("handlerNum");
        }

        public override string ToString()
        {
            return message;
        }
    }
}