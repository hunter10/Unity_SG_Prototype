namespace NetmarbleS.Internal
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class CallbackManager
    {
        public delegate void OnResponse(CallbackMessage message);

        private static Dictionary<int, OnResponse> sHandlerDic = new Dictionary<int, OnResponse>();
        private static int sHandlerNum = 0;
        private static readonly object lockObject = new Object();

        private static NMGameObject nmGameObject;
        public static NMGameObject NetmarbleGameObject
        {
            get
            {
                if (nmGameObject == null)
                {
                    nmGameObject = UnityEngine.Object.FindObjectOfType(typeof(NMGameObject)) as NMGameObject;

                    if (nmGameObject == null)
                    {
                        nmGameObject = new GameObject("NMGameObject").AddComponent<NMGameObject>();
                        UnityEngine.Object.DontDestroyOnLoad(nmGameObject);
                    }
                }

                return nmGameObject;
            }
            set
            {
                if (nmGameObject == value)
                    return;

                if (nmGameObject != null && value != null)
                {
                    GameObject.Destroy(value.gameObject);
                    return;
                }

                nmGameObject = value;
            }
        }

        public static int GetetHandlerNum()
        {
            int handlerNum;
            lock (lockObject)
            {
                handlerNum = ++sHandlerNum;

            }
            return handlerNum;
        }
        public static OnResponse GetHandler(int handlerNum)
        {
            if (handlerNum == 0)
                return null;

            return sHandlerDic[handlerNum];
        }

        public static int AddHandler(OnResponse handler)
        {
            if (null == handler)
                return 0;

            int handlerNum = GetetHandlerNum();
            sHandlerDic.Add(handlerNum, handler);

            return handlerNum;
        }

        public static void RemoveHandler(int handlerNum)
        {
            if (handlerNum == 0)
                return;

            if (sHandlerDic.ContainsKey(handlerNum))
                sHandlerDic.Remove(handlerNum);
        }
    }
}
