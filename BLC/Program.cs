using MateuszDobrowolski.Interfaces;
using System.Reflection;
using System;
using MateuszDobrowolski.BLC.Properties;

namespace MateuszDobrowolski.BLC
{
    public static class BLC
    {
        private static IDAO _instance;

        private static IDAO createInstance()
        {
            Settings settings = new Settings();
            string dbName = settings.dbNameConf;
            Assembly assembly = Assembly.UnsafeLoadFrom(dbName);
            Type daoToCreate = null;
            Type daoType = typeof(IDAO);

            foreach (var assemblyType in assembly.GetTypes())
            {
                foreach (var assemblyInterface in assemblyType.GetInterfaces())
                {
                    if (assemblyInterface == daoType)
                    { 
                        daoToCreate = assemblyType;
                    }
                }
            }
            return (IDAO)Activator.CreateInstance(daoToCreate, new object[] { });
        }

        public static IDAO DAO
        {
            get
            {
                if (_instance == null)
                    _instance = createInstance();
       
                return _instance;
            }
        }
    }
}
