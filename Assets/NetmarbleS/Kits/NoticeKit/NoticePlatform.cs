namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class NoticePlatform : INotice
    {
        public string VERSION
        {
            get
            {
                return "0.0.0.0000";
            }
        }

        public int INTRO
        {
            get { return 0; }
        }

        public int INGAME
        {
            get { return 0; }
        }

        public void SetViewConfiguration(string configuration)
        {

        }
    }
}