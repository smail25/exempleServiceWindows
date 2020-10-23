using System.ServiceModel;
using System.ServiceModel.Web;

namespace ExempleService
{
    [ServiceContract]
    public interface ICommand
    {
        [OperationContract]
        [WebGet]
        string CommandWithGet(string strCommand);

        [OperationContract]
        [WebInvoke]
        string CommandWithPost(string strCommand);

    }
}