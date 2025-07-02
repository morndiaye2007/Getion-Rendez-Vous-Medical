using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WcfServiceRdv.Models;

namespace WcfServiceRdv.Service
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        List<Role> GetAllRoles();

        [OperationContract]
        Role GetRoleById(int id);

        [OperationContract]
        bool AddRole(Role role);

        [OperationContract]
        bool UpdateRole(Role role);

        [OperationContract]
        bool DeleteRole(int id);
    }
}