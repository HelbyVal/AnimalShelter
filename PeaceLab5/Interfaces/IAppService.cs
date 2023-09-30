using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PeaceLab5.Classes;

namespace PeaceLab5.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IAppService
    {
        [OperationContract]
        int Connect();

        [OperationContract]
        int Disconnect();

        [OperationContract]
        Contrct AddContract(string nameCity, DateTime data, string contractNum, double cost);

        [OperationContract]
        void AddAnimal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate, string cityName);

        [OperationContract(Name = "AddAnimalRepeat")]
        void AddAnimal(string chipNum, DateTime accDate, string cityName);

        [OperationContract]
        void ReleaseAnimal(string chipNum, DateTime accDate, string cityName);

        [OperationContract]
        double CreateReport(string cityName, DateTime firstDate, DateTime lastDate);


    }
}
