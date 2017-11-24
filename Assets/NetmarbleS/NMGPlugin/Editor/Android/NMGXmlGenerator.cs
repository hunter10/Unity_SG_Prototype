namespace NetmarbleS.NMGPlugin
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using NetmarbleS.Internal;

    public class NMGXmlGenerator
    {
        private List<XmlNodeList> usesPermissionList = new List<XmlNodeList>();
        private List<XmlNodeList> permissionList = new List<XmlNodeList>();
        private List<XmlNodeList> metaDataList = new List<XmlNodeList>();
        private List<XmlNodeList> activityList = new List<XmlNodeList>();
        private List<XmlNodeList> receiverList = new List<XmlNodeList>();
        private List<XmlNodeList> serviceList = new List<XmlNodeList>();
        private List<XmlNodeList> providerList = new List<XmlNodeList>();
        private Dictionary<string, XmlAttribute> applicationAttributes = new Dictionary<string, XmlAttribute>();

        private readonly string xmlPath = Path.Combine(Application.dataPath, "Plugins/Android/AndroidManifest.xml");
        private Dictionary<string, string> replaceDic;

        public CoreKitSetting coreSetting;

        public NMGXmlGenerator(string packageName, CoreKitSetting coreSetting)
        {
            this.coreSetting = coreSetting;
            this.replaceDic = new Dictionary<string, string>() { { "{package}", packageName }, { "{gameCode}", coreSetting.GameCode }, { "{mainActivity}", coreSetting.MainActivity } };
        }

        public void AddReplaceDic(Dictionary<string, string> dic)
        {
            if (null != dic)
            {
                foreach (KeyValuePair<string, string> value in dic)
                {
                    if (!replaceDic.ContainsKey(value.Key))
                        replaceDic.Add(value.Key, value.Value);
                }
            }
        }

        public void GenerateManifest()
        {
            Debug.Log("Set AndroidManifest");

            GetKitManifest();
            XmlDocument baseXml = GetBaseManifest();

            XmlNode manifestNode = baseXml.SelectSingleNode("manifest");
            string ns = manifestNode.GetNamespaceOfPrefix("android");
            XmlNode applicationNode = manifestNode.SelectSingleNode("application");

            SetPermission(baseXml, manifestNode, ns);
            SetMetaData(baseXml, applicationNode, ns);
            SetActivity(baseXml, applicationNode, ns);
            SetReceiver(baseXml, applicationNode, ns);
            SetService(baseXml, applicationNode, ns);
            SetProvider(baseXml, applicationNode, ns);
            SetApplicationAttributes(baseXml, applicationNode, ns);

            baseXml.Save(xmlPath);
        }

        private void GetKitManifest()
        {
            string path = Path.Combine(Application.dataPath, "NetmarbleS/Kits");
            string[] files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);

                XmlNode manifestNode = xmlDoc.SelectSingleNode("manifest");
                XmlNodeList usespermission = manifestNode.SelectNodes("uses-permission");
                XmlNodeList permission = manifestNode.SelectNodes("permission");

                XmlNode applicationNode = manifestNode.SelectSingleNode("application");

                XmlNodeList metaData = applicationNode.SelectNodes("meta-data");
                XmlNodeList activity = applicationNode.SelectNodes("activity");
                XmlNodeList receiver = applicationNode.SelectNodes("receiver");
                XmlNodeList service = applicationNode.SelectNodes("service");
                XmlNodeList provider = applicationNode.SelectNodes("provider");

                usesPermissionList.Add(usespermission);
                permissionList.Add(permission);
                metaDataList.Add(metaData);
                activityList.Add(activity);
                receiverList.Add(receiver);
                serviceList.Add(service);
                providerList.Add(provider);

                XmlAttributeCollection attrCollection = applicationNode.Attributes;
                foreach (XmlAttribute attr in attrCollection)
                {
                    applicationAttributes[attr.Name] = attr;
                }

            }
        }

        private XmlDocument GetBaseManifest()
        {
            if (!File.Exists(xmlPath))
            {
#if UNITY_5
            string path = Path.Combine(EditorApplication.applicationContentsPath, "PlaybackEngines/AndroidPlayer/Apk/AndroidManifest.xml");
#else
                string path = Path.Combine(EditorApplication.applicationContentsPath, "PlaybackEngines/androidplayer/AndroidManifest.xml");
#endif
                if (File.Exists(path))
                    File.Copy(path, xmlPath);
            }

            if (!File.Exists(xmlPath))
            {
                XmlTextWriter writer = new XmlTextWriter(xmlPath, System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("manifest");
                writer.WriteAttributeString("xmlns", "android", null, "http://schemas.android.com/apk/res/android");
                writer.WriteStartElement("application");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

            XmlDocument baseXml = new XmlDocument();
            baseXml.Load(xmlPath);

            if (baseXml == null)
            {
                Debug.LogError("Couldn't load " + xmlPath);
            }

            return baseXml;
        }

        private void SetPermission(XmlDocument baseXml, XmlNode manifestNode, string ns)
        {
            XmlNodeList baseUsersPermissionList = manifestNode.SelectNodes("uses-permission");
            foreach (XmlNodeList nodeList in usesPermissionList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);
                    string[] currentNameArray = currentNodeName.Split('.');
                    string currentPermission = currentNameArray[currentNameArray.Length - 1];

                    List<XmlNode> toRemoveUserPermission = new List<XmlNode>();

                    foreach (XmlNode baseNode in baseUsersPermissionList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);
                        string[] baseNameArray = baseNodeName.Split('.');
                        string basePermission = baseNameArray[baseNameArray.Length - 1];

                        if (currentPermission.Equals(basePermission))
                        {
                            toRemoveUserPermission.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemoveUserPermission)
                    {
                        manifestNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    manifestNode.AppendChild(node);
                }
            }

            XmlNodeList basePermissionList = manifestNode.SelectNodes("permission");
            foreach (XmlNodeList nodeList in permissionList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);
                    string[] currentNameArray = currentNodeName.Split('.');
                    string currentPermission = currentNameArray[currentNameArray.Length - 1];

                    List<XmlNode> toRemovePermission = new List<XmlNode>();

                    foreach (XmlNode baseNode in basePermissionList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);
                        string[] baseNameArray = baseNodeName.Split('.');
                        string basePermission = baseNameArray[baseNameArray.Length - 1];

                        if (currentPermission.Equals(basePermission))
                        {
                            toRemovePermission.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemovePermission)
                    {
                        manifestNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    manifestNode.AppendChild(node);
                }
            }
        }

        private void SetMetaData(XmlDocument baseXml, XmlNode applicationNode, string ns)
        {
            XmlNodeList baseMetaDataList = applicationNode.SelectNodes("meta-data");

            foreach (XmlNodeList nodeList in metaDataList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);
                    List<XmlNode> toRemoveMetaData = new List<XmlNode>();

                    foreach (XmlNode baseNode in baseMetaDataList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);

                        if (currentNodeName.Equals(baseNodeName))
                        {
                            toRemoveMetaData.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemoveMetaData)
                    {
                        applicationNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    applicationNode.AppendChild(node);
                }
            }
        }

        private void SetActivity(XmlDocument baseXml, XmlNode applicationNode, string ns)
        {
            XmlNodeList baseActivityList = applicationNode.SelectNodes("activity");

            foreach (XmlNode baseNode in baseActivityList)
            {
                XmlNodeList baseIntentFilterList = baseNode.SelectNodes("intent-filter");
                foreach (XmlNode intentFilterNode in baseIntentFilterList)
                {
                    XmlNodeList actionList = intentFilterNode.SelectNodes("action");

                    foreach (XmlNode actionNode in actionList)
                    {
                        if ((actionNode as XmlElement).GetAttribute("name", ns) == "android.intent.action.MAIN")
                        {
                            applicationNode.RemoveChild(baseNode);
                        }
                    }
                }
            }

            foreach (XmlNodeList nodeList in activityList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);

                    List<XmlNode> toRemoveActivity = new List<XmlNode>();

                    foreach (XmlNode baseNode in baseActivityList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);

                        if (currentNodeName.Equals(baseNodeName))
                        {
                            toRemoveActivity.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemoveActivity)
                    {
                        applicationNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    applicationNode.AppendChild(node);
                }
            }
        }

        private void SetReceiver(XmlDocument baseXml, XmlNode applicationNode, string ns)
        {
            XmlNodeList baseReceiverList = applicationNode.SelectNodes("receiver");

            foreach (XmlNodeList nodeList in receiverList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);

                    List<XmlNode> toRemoveReceiver = new List<XmlNode>();

                    foreach (XmlNode baseNode in baseReceiverList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);

                        if (currentNodeName.Equals(baseNodeName))
                        {
                            toRemoveReceiver.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemoveReceiver)
                    {
                        applicationNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    applicationNode.AppendChild(node);
                }
            }
        }

        private void SetService(XmlDocument baseXml, XmlNode applicationNode, string ns)
        {
            XmlNodeList baseServiceList = applicationNode.SelectNodes("service");

            foreach (XmlNodeList nodeList in serviceList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);

                    List<XmlNode> toRemoveService = new List<XmlNode>();

                    foreach (XmlNode baseNode in baseServiceList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);

                        if (currentNodeName.Equals(baseNodeName))
                        {
                            toRemoveService.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemoveService)
                    {
                        applicationNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    applicationNode.AppendChild(node);
                }
            }
        }

        private void SetProvider(XmlDocument baseXml, XmlNode applicationNode, string ns)
        {
            XmlNodeList baseProviderList = applicationNode.SelectNodes("provider");

            foreach (XmlNodeList nodeList in providerList)
            {
                foreach (XmlNode currentNode in nodeList)
                {
                    XmlNode replaceNode = ReplaceAttributeValue(currentNode, replaceDic);
                    string currentNodeName = (replaceNode as XmlElement).GetAttribute("name", ns);

                    List<XmlNode> toRemoveProvider = new List<XmlNode>();

                    foreach (XmlNode baseNode in baseProviderList)
                    {
                        string baseNodeName = (baseNode as XmlElement).GetAttribute("name", ns);

                        if (currentNodeName.Equals(baseNodeName))
                        {
                            toRemoveProvider.Add(baseNode);
                            break;
                        }
                    }

                    foreach (XmlNode xmlElement in toRemoveProvider)
                    {
                        applicationNode.RemoveChild(xmlElement);
                    }

                    XmlNode node = baseXml.ImportNode(replaceNode, true);
                    (node as XmlElement).RemoveAttribute("android", node.GetNamespaceOfPrefix("xmlns"));
                    applicationNode.AppendChild(node);
                }
            }
        }

        private void SetApplicationAttributes(XmlDocument baseXml, XmlNode applicationNode, string ns)
        {
            XmlAttributeCollection baseAttrCollection = applicationNode.Attributes;

            
            foreach (XmlAttribute attr in applicationAttributes.Values)
            {
                bool exist = false;
                foreach (XmlAttribute baseAttr in baseAttrCollection)
                {
                    if (baseAttr.Name.Equals(attr.Name))
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    (applicationNode as XmlElement).SetAttribute(attr.Name, ns, attr.Value);
                }
            }
        }
        private XmlNode ReplaceAttributeValue(XmlNode node, Dictionary<string, string> replaceDic)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            node.WriteTo(xw);
            string nodeString = sw.ToString();

            foreach (KeyValuePair<string, string> replace in replaceDic)
            {
                if (nodeString.Contains(replace.Key))
                    nodeString = nodeString.Replace(replace.Key, replace.Value);
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(nodeString);
            return doc.DocumentElement;


        }

        private string GetResourcePath(string directoryPath)
        {
            string[] pathArray = directoryPath.Split('/');
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(Application.dataPath);
            foreach (string path in pathArray)
            {
                builder.Append("/").Append(path);
                string currentDir = builder.ToString();
                if (!Directory.Exists(currentDir))
                {
                    Directory.CreateDirectory(currentDir);
                }
            }

            return builder.ToString();
        }

        public void GenerateStringsXml(Dictionary<string, object> stringsDic)
        {
            Debug.Log("Set Strings");

            string xmlPath = GetResourcePath("Plugins/Android/res/values") + "/strings.xml";

            if (!File.Exists(xmlPath))
            {
                XmlTextWriter writer = new XmlTextWriter(xmlPath, System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("resources");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode resourcesNode = xmlDoc.SelectSingleNode("resources");
            XmlNodeList stringNode = resourcesNode.SelectNodes("string");

            List<XmlNode> toRemove = new List<XmlNode>();

            foreach (XmlNode node in stringNode)
            {
                foreach (KeyValuePair<string, object> strings in stringsDic)
                {
                    if ((node as XmlElement).GetAttribute("name") == strings.Key)
                    {
                        toRemove.Add(node);
                        break;
                    }
                }
            }

            foreach (XmlNode xmlElement in toRemove)
            {
                resourcesNode.RemoveChild(xmlElement);
            }

            foreach (KeyValuePair<string, object> strings in stringsDic)
            {
                string value = System.Convert.ToString(strings.Value);
                if (!string.IsNullOrEmpty(value))
                {
                    XmlElement element = xmlDoc.CreateElement("string");
                    element.SetAttribute("name", strings.Key);
                    element.InnerText = value;
                    resourcesNode.AppendChild(element);
                }
            }

            xmlDoc.Save(xmlPath);
        }

        public void GenerateNMConfigurationXml()
        {
            //if (coreSetting.zone == null || coreSetting.zone.Length == 0)
            //{
            //    Debug.LogError("Check Zone");
            //    return;
            //}

            //if (coreSetting.gameCode == null || coreSetting.gameCode.Length == 0)
            //{
            //    Debug.LogError("Check GameCode");
            //    return;
            //}

            //if (coreSetting.market == null || coreSetting.market.Length == 0)
            //{
            //    Debug.LogError("Check Market");
            //    return;
            //}

            Debug.Log("Set NMConfiguration");

            string xmlPath = GetResourcePath("Plugins/Android/res/xml") + "/nmconfiguration.xml";

            if (!File.Exists(xmlPath))
            {
                XmlTextWriter writer = new XmlTextWriter(xmlPath, System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("properties");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode propertiesNode = xmlDoc.SelectSingleNode("properties");

            if (propertiesNode.SelectSingleNode("zone") == null)
            {
                XmlElement element = xmlDoc.CreateElement("zone");
                propertiesNode.AppendChild(element);
            }
            (propertiesNode.SelectSingleNode("zone")).InnerText = coreSetting.Zone;

            if (propertiesNode.SelectSingleNode("gameCode") == null)
            {
                XmlElement element = xmlDoc.CreateElement("gameCode");
                propertiesNode.AppendChild(element);
            }
            (propertiesNode.SelectSingleNode("gameCode")).InnerText = coreSetting.GameCode;

            if (propertiesNode.SelectSingleNode("market") == null)
            {
                XmlElement element = xmlDoc.CreateElement("market");
                propertiesNode.AppendChild(element);
            }
            (propertiesNode.SelectSingleNode("market")).InnerText = coreSetting.Market;

            if (propertiesNode.SelectSingleNode("useLog") == null)
            {
                XmlElement element = xmlDoc.CreateElement("useLog");
                propertiesNode.AppendChild(element);
            }
            (propertiesNode.SelectSingleNode("useLog")).InnerText = coreSetting.UseLog ? "true" : "false";

            if (propertiesNode.SelectSingleNode("httpTimeOutSec") == null)
            {
                XmlElement element = xmlDoc.CreateElement("httpTimeOutSec");
                propertiesNode.AppendChild(element);
            }
            (propertiesNode.SelectSingleNode("httpTimeOutSec")).InnerText = coreSetting.HttpTimeOutSec.ToString();

            if (propertiesNode.SelectSingleNode("useFixedPlayerID") == null)
            {
                XmlElement element = xmlDoc.CreateElement("useFixedPlayerID");
                propertiesNode.AppendChild(element);
            }
            (propertiesNode.SelectSingleNode("useFixedPlayerID")).InnerText = coreSetting.UseFixedPlayerId ? "true" : "false";

            xmlDoc.Save(xmlPath);
        }

        public void GenerateNMPluginXml(Dictionary<string, List<object>> pluginAndroid)
        {
            Debug.Log("Set NMPlugin");

            string xmlPath = GetResourcePath("Plugins/Android/res/xml") + "/nmplugin.xml";

            if (!File.Exists(xmlPath))
            {
                XmlTextWriter writer = new XmlTextWriter(xmlPath, System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("properties");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode propertiesNode = xmlDoc.SelectSingleNode("properties");
            propertiesNode.RemoveAll();

            foreach (KeyValuePair<string, List<object>> plugins in pluginAndroid)
            {
                foreach (IDictionary value in plugins.Value)
                {
                    XmlElement element = xmlDoc.CreateElement(plugins.Key);

                    foreach (string key in value.Keys)
                    {
                        element.SetAttribute(key, value[key].ToString());
                    }
                    propertiesNode.AppendChild(element);
                }
            }
            xmlDoc.Save(xmlPath);
        }
    }
}