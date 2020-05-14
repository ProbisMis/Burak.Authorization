using Microsoft.Extensions.Configuration;
using Burak.Authorization.Utilities.ConfigModels;
using Burak.Authorization.Utilities.Constants;
using System;
using System.Linq;

namespace Burak.Authorization.Helper
{
    public class ConfigurationHelper
    {
        public static DataStorage GetDataStorage(IConfiguration configuration)
        {
            var dataStorageList = configuration.GetSection(AppConstants.DataStorageSection).Get<DataStorageSection>();

            if (dataStorageList == null)
            {
                throw new ApplicationException($"{nameof(DataStorageSection)} is null");
            }

            if (!Enum.IsDefined(typeof(DataStorageTypes), dataStorageList.SelectedDataStorageType))
            {
                throw new ApplicationException($"{dataStorageList.SelectedDataStorageType} is not defined data storage type");
            }

            DataStorage dataStorage = dataStorageList.DataStorageCollection.FirstOrDefault(storage => storage.DataStorageType == dataStorageList.SelectedDataStorageType);

            if (dataStorage == null)
            {
                throw new ApplicationException($"DataStorageList does not contains {dataStorageList.SelectedDataStorageType}");
            }

            return dataStorage;
        }
    }
}
