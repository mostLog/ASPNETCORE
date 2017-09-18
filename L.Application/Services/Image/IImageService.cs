using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace L.Application.Services
{
    /// <summary>
    /// 图片服务接口
    /// </summary>
    [UnitOfWork(isTransactional: true)]
    public interface IImageService
    {
        /// <summary>
        /// 添加图片信息集合
        /// </summary>
        /// <param name="img"></param>
        Task AddImages(IList<Img> imgs);

      
        Task AddImageInfos(IList<ImageInfo> infos);
        Task AddImageInfos(IList<ImageInfo> infos, Img img);

        [NoUnitOfWork]
        Task UpdateImage(Img img);

        [NoUnitOfWork]
        Task<IList<Img>> GetSourceImgs(ImageSearchInput input);

        [NoUnitOfWork]
        Task<PagedListResult<ImageListOutput>> GetImagePagedList(ImageSearchInput input);
    }
}