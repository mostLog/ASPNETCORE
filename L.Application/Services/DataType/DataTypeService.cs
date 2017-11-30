using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public class DataTypeService : IDataTypeService
    {
        private readonly IBaseRepository<DataTypeClassification> _dataTypeClassRepository;

        public DataTypeService(IBaseRepository<DataTypeClassification> dataClassTypeRepository)
        {
            _dataTypeClassRepository = dataClassTypeRepository;
        }

        /// <summary>
        /// 获取所有跟节点分类信息
        /// </summary>
        /// <returns></returns>
        public async Task<IList<DataTypeClassOutput>> GetRootAllClasses()
        {
            return await _dataTypeClassRepository
                .Table
                .Where(c => !string.IsNullOrEmpty(c.ClassId))
                .Where(c => c.ClassId.Length == 1)
                .Select(c => new DataTypeClassOutput()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ClassId = c.ClassId
                })
                .ToListAsync();
        }

        /// <summary>
        /// 获取子节点所有项
        /// </summary>
        /// <returns></returns>
        public async Task<IList<DataTypeClassOutput>> GetChildrenAllClasses(int? parentId)
        {
            if (parentId.HasValue)
            {
                return await _dataTypeClassRepository
                    .Table
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new DataTypeClassOutput()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ClassId = c.ClassId
                    })
                    .ToListAsync();
            }
            else
            {
                return new List<DataTypeClassOutput>();
            }
        }

        /// <summary>
        /// 添加数据类型分类
        /// </summary>
        /// <returns></returns>
        public async Task CreateDataTypeClass(DataTypeClassInput input)
        {
            DataTypeClassification classification = input.MapTo<DataTypeClassification>();
            classification.ClassId = GenerateClassId(input.ParentClassId);
            classification.ParentId = input.ParentId;
            await _dataTypeClassRepository.InsertAsync(classification);
        }

        /// <summary>
        /// 删除数据类型分类
        /// </summary>
        /// <returns></returns>
        public async Task DelDataTypeClass(int? id)
        {
            if (id.HasValue)
            {
                await _dataTypeClassRepository.DeleteAsync(id.Value);
            }
        }
        /// <summary>
        /// 生成子项分类标识
        /// </summary>
        private string GenerateClassId(string parentClassId)
        {
            //获取数量
            int count = _dataTypeClassRepository.Table.Count(c => c.ClassId == parentClassId);
            //根节点
            if (string.IsNullOrEmpty(parentClassId))
            {
                return (count + 1).ToString();
            }
            else
            {
                //子节点
                return parentClassId + "_" + count;
            }
        }
    }
}