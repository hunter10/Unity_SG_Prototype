namespace NetmarbleS.NMGPlugin.NMGXCodeEditor
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class PBXProject : PBXObject
    {
        protected string MAINGROUP_KEY = "mainGroup";
		// 4.1.0 SystemCapabilities  push 
		private const string ATTRIBUTES_KEY = "attributes";
		private const string TARGET_ATTRIBUTES_KEY = "TargetAttributes";
		private const string TEST_TARGET_ID_KEY = "TestTargetID";
		private const string TARGET_KEY = "targets";

        public PBXProject() : base()
        {
        }

        public PBXProject(string guid, PBXDictionary dictionary) : base(guid, dictionary)
        {	
        }

        public string mainGroupID
        {
            get
            {
                return (string)_data [MAINGROUP_KEY];
            }
        }

		public PBXDictionary Attributes
		{
			get
			{
				if (!ContainsKey(ATTRIBUTES_KEY))
				{
					this.Add(ATTRIBUTES_KEY, new PBXDictionary());
				}
				return (PBXDictionary)_data [ATTRIBUTES_KEY];
			}
		}

		public bool AddPushSystemCapabilities(bool value)
		{
			bool modified = false;

			PBXList targets = ((PBXList)_data [TARGET_KEY]);
			if (!ContainsKey(ATTRIBUTES_KEY))
			{
				this.Add(ATTRIBUTES_KEY, new PBXDictionary());
				modified = true;
			}

			PBXDictionary attributes = ((PBXDictionary)_data [ATTRIBUTES_KEY]);
			if (!attributes.ContainsKey(TARGET_ATTRIBUTES_KEY))
			{
				attributes.Add(TARGET_ATTRIBUTES_KEY, new PBXDictionary());
				modified = true;
			}

			PBXDictionary targetAttributes = ((PBXDictionary)attributes [TARGET_ATTRIBUTES_KEY]);

			foreach (object target in targets) 
			{
				string targetKey = (string)target;

				if (!targetAttributes.ContainsKey(targetKey))
				{
					targetAttributes.Add(targetKey, new PBXDictionary());
					PBXDictionary targetAttribute = (PBXDictionary) targetAttributes [targetKey];

					targetAttribute.Add ("SystemCapabilities", new PBXDictionary());
					PBXDictionary systemCapabilities = (PBXDictionary) targetAttribute ["SystemCapabilities"];

					systemCapabilities.Add ("com.apple.Push", new PBXDictionary());
					PBXDictionary applePush = (PBXDictionary) systemCapabilities ["com.apple.Push"];

					if (value)
						applePush.Add ("enabled", 1);
					else
						applePush.Add ("enabled", 0);

					modified = true;
				}
				else
				{
					PBXDictionary targetAttribute = (PBXDictionary) targetAttributes [targetKey];
					if (!targetAttribute.ContainsKey(TEST_TARGET_ID_KEY))
					{
						if (!targetAttribute.ContainsKey("SystemCapabilities"))
							targetAttribute.Add ("SystemCapabilities", new PBXDictionary());
						PBXDictionary systemCapabilities = (PBXDictionary) targetAttribute ["SystemCapabilities"];

						if (!systemCapabilities.ContainsKey("com.apple.Push"))
							systemCapabilities.Add ("com.apple.Push", new PBXDictionary());
						PBXDictionary applePush = (PBXDictionary) systemCapabilities ["com.apple.Push"];

						if (applePush.ContainsKey("enabled"))
							applePush.Remove("enabled");

						if (value)
							applePush.Add ("enabled", 1);
						else
							applePush.Add ("enabled", 0);

						modified = true;
					}
				}
			}
			return modified;
		}
    }
}
