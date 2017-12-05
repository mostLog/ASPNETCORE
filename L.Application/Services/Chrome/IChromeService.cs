using L.Application.Dto;
using L.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork()]
    public interface IChromeService
    {
        [NoUnitOfWork]
        Task<PagedListResult<PushTextListOutput>> GetPushTextPagedList(PushTextSearchInput input);
        Task AddOrUpdatePushText(PushTextAddOrEditInput input);
        Task CheckOk(CheckInput input);
    }
}
