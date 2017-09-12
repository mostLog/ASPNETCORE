using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
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
                .Take(input.RowCount)
                .ToListAsync();
        }
    }
}