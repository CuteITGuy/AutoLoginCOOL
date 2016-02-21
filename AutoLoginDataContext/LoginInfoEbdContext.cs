using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AutoLoginModels;


namespace AutoLoginDataContext
{
    public class LoginInfoEbdContext: LoginInfoContextBase
    {
        #region  Constructors & Destructor
        public LoginInfoEbdContext(string filePath): base(filePath) { }
        #endregion


        #region Override
        protected override Website[] DoLoadLogic()
        {
            using (var reader = new FileStream(_filePath, FileMode.Open))
            {
                var ser = CreateWebsitesSerializer();
                return ser.Deserialize(reader) as Website[];
            }
        }

        protected override void DoSaveChangesLogic(Website[] websites)
        {
            using (var writer = new FileStream(_filePath, FileMode.Create))
            {
                var ser = CreateWebsitesSerializer();
                ser.Serialize(writer, websites);
            }
        }
        #endregion


        #region Implementation
        private static BinaryFormatter CreateWebsitesSerializer()
        {
            return new BinaryFormatter();
        }
        #endregion
    }
}