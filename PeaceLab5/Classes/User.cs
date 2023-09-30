using System.ServiceModel;

namespace PeaceLab5.Classes
{
    public class User
    {
        string Name { get; set; }
        string City { get; set; }

        public OperationContext operationContext { get; set; }
    }
}
