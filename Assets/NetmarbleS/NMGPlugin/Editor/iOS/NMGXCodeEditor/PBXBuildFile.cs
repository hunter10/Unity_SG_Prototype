namespace NetmarbleS.NMGPlugin.NMGXCodeEditor
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class PBXBuildFile : PBXObject
    {
        private const string FILE_REF_KEY = "fileRef";
        private const string SETTINGS_KEY = "settings";
        private const string ATTRIBUTES_KEY = "ATTRIBUTES";
        private const string WEAK_VALUE = "Weak";
        private const string COMPILER_FLAGS_KEY = "COMPILER_FLAGS";

        public PBXBuildFile(PBXFileReference fileRef, bool weak = false, string flag = null) : base()
        {
//            Debug.Log(fileRef.name);
            this.Add(FILE_REF_KEY, fileRef.guid);
            SetWeakLink(weak);
            if (flag != null)
            {
                AddCompilerFlag(flag);
            }
        }

        public PBXBuildFile(string  guidRef, bool weak = false, string flag = null) : base()
        {
            this.Add(FILE_REF_KEY, guidRef);
            SetWeakLink(weak);
            if (flag != null)
            {
                AddCompilerFlag(flag);
            }
        }

        public PBXBuildFile(string guid, PBXDictionary dictionary) : base(guid, dictionary)
        {
//			Debug.Log( "constructor child" );
        }

		public bool SetWeakLink( bool weak = false )
		{
			PBXDictionary settings = null;
			PBXList attributes = null;
			
			if (!_data.ContainsKey(SETTINGS_KEY))
			{
				if (weak)
				{
					attributes = new PBXList();
					attributes.Add(WEAK_VALUE);
					
					settings = new PBXDictionary();
					settings.Add(ATTRIBUTES_KEY, attributes);
					_data[SETTINGS_KEY] = settings;
				}
				return true;
			}
			
			settings = _data[SETTINGS_KEY] as PBXDictionary;
			if (!settings.ContainsKey(ATTRIBUTES_KEY))
			{
				if (weak)
				{
					attributes = new PBXList();
					attributes.Add(WEAK_VALUE);
					settings.Add(ATTRIBUTES_KEY, attributes);
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				attributes = settings[ATTRIBUTES_KEY] as PBXList;
			}
			
			if (!attributes.Contains(WEAK_VALUE))
			{
				if (weak)
				{
					attributes.Add(WEAK_VALUE);
				}
			}
			else
			{
				if (!weak)
				{
					attributes.Remove(WEAK_VALUE);
				}
			}
			
			settings[ ATTRIBUTES_KEY] = attributes ;
			if (!this.ContainsKey (SETTINGS_KEY)) {
				this.Add( SETTINGS_KEY, settings );
			} else {
				_data[SETTINGS_KEY] = settings;
			}
			return true;
		}

        public bool AddCompilerFlag(string flag)
        {
            if (!_data.ContainsKey(SETTINGS_KEY))
                _data [SETTINGS_KEY] = new PBXDictionary();
			
            if (!((PBXDictionary)_data [SETTINGS_KEY]).ContainsKey(COMPILER_FLAGS_KEY))
            {
                ((PBXDictionary)_data [SETTINGS_KEY]).Add(COMPILER_FLAGS_KEY, flag);
                return true;
            }
			
            string[] flags = ((string)((PBXDictionary)_data [SETTINGS_KEY]) [COMPILER_FLAGS_KEY]).Split(' ');
            foreach (string item in flags)
            {
                if (item.CompareTo(flag) == 0)
                    return false;
            }
			
            ((PBXDictionary)_data [SETTINGS_KEY]) [COMPILER_FLAGS_KEY] = (string.Join(" ", flags) + " " + flag);
            return true;
        }
		
    }
}
