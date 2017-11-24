namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class PromotionPlatform : IPromotion
    {
        public string VERSION
        {
            get
            {
                return "0.0.0.0000";
            }
        }

        public int BASE
        {
            get { return 0; }
        }

        public int UPPER
        {
            get { return 0; }
        }

        public int MAIN
        {
            get { return 0; }
        }

        public int EVENT
        {
            get { return 0; }
        }

        public int ETC
        {
            get { return 0; }
        }


        public void SetViewConfiguration(string configuration)
        {

        }
    }
}