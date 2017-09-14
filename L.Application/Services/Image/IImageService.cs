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
        /// 添加图片信息
        /// </summary>
        /// <param name="img"></param>
        [NoUnitOfWork]
        void AddImage(Img img);

        [NoUnitOfWork]
        void AddImageInfo(ImageInfo info);
        [NoUnitOfWork]
        void UpdateImage(Img img);

        [NoUnitOfWork]
        Task<IList<Img>> GetSourceImgs(ImageSearchInput input);
        [NoUnitOfWork]
        Task<PagedListResult<ImageListOutput>> GetImagePagedList(ImageSearchInput input);
    }
}