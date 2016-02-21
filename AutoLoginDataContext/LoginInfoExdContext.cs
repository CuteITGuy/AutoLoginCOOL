using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoLoginModels;


namespace AutoLoginDataContext
{
    public class LoginInfoExdContext: LoginInfoContextBase
    {
        #region  Constructors & Destructor
        public LoginInfoExdContext(string filePath): base(filePath) { }
        #endregion


        #region Override
        protected override Website[] DoLoadLogic()
        {
            using (var reader = new StreamReader(_filePath))
            {
                var ser = CreateWebsitesSerializer();
                return ser.Deserialize(reader) as Website[];
            }
        }

        protected override void DoSaveChangesLogic(Website[] websites)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                var ser = CreateWebsitesSerializer();
                ser.Serialize(writer, websites);
            }
        }
        #endregion


        #region Implementation
        private static XmlSerializer CreateWebsitesSerializer() => new XmlSerializer(typeof(Website[]));
        #endregion
    }
}