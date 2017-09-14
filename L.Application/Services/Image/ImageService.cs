using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L.Application.Services
{
    /// <summary>
    /// 图片服务实现类
    /// </summary>
    public class ImageService : IImageService
    {
        /// <summary>
        /// 图片信息源仓储
        /// </summary>
        private readonly IBaseRepository<Img> _imgRepository;

        /// <summary>
        /// 图片信息仓储
        /// </summary>
        private readonly IBaseRepository<ImageInfo> _imageInfoRepository;

        public ImageService(
            IBaseRepository<Img> imgRepository,
            IBaseRepository<ImageInfo> imageInfoRepository)
        {
            _imgRepository = imgRepository;
            _imageInfoRepository = imageInfoRepository;
        }

        /// <summary>
        /// 添加图片源
        /// </summary>
        /// <param name="img"></param>
        public async void AddImage(Img img)
        {
            if (img == null)
            {
                throw new ArgumentException(nameof(img));
            }
            await _imgRepository.InsertAsync(img);
        }

        /// <summary>
        /// 更新图片源信息
        /// </summary>
        public async void UpdateImage(Img img)
        {
            var imageSource = await _imgRepository.GetEntityByIdAsync(img.Id);
            imageSource.IsCrawlerImgInfo = img.IsCrawlerImgInfo;
            imageSource.PageEndIndex = img.PageEndIndex;
            imageSource.PageStartIndex = img.PageStartIndex;
            await _imgRepository.UpdateAsync(imageSource);
        }

        /// <summary>
        /// 添加图片信息
        /// </summary>
        public async void AddImageInfo(ImageInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException(nameof(info));
            }
            await _imageInfoRepository.InsertAsync(info);
        }

        /// <summary>
        /// 获取Imgs
        /// </summary>
        public async Task<IList<Img>> GetSourceImgs(ImageSearchInput input)
        {
            return await _imgRepository.Table
                .WhereIf(input.IsCrawlerImgInfo.HasValue, m => m.IsCrawlerImgInfo == input.IsCrawlerImgInfo.Value)
                .Take(input.RowCount)
                .ToListAsync();
        }
        /// <summary>
        /// 获取分页图片信息
        /// </summary>
        /// <returns></returns>
        public async Task<PagedListResult<ImageListOutput>> GetImagePagedList(ImageSearchInput input)
        {
            var query=_imageInfoRepository.Table.AsNoTracking();
            var list=await query
                .PageBy(input.PageIndex, input.PageSize)
                .ToListAsync();

            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<ImageInfo, ImageListOutput>());

            return new PagedListResult<ImageListOutput>() {
                Code = 0,
                Data = AutoMapper.Mapper.Map<IList<ImageListOutput>>(list)
            };
        }
    }
}