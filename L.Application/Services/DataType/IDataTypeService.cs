using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork]
    public interface IDataTypeService
    {
        [NoUnitOfWork]
        Task<IList<DataTypeClassOutput>> GetRootAllClasses();
        [NoUnitOfWork]
        Task<IList<DataTypeClassOutput>> GetChildrenAllClasses(int? parentId);
        Task CreateDataTypeClass(DataTypeClassInput input);
        Task DelDataTypeClass(int? id);
    }
}
