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
        private readonly IBaseRepository<DataType> _dataTypeRepository;

        public DataTypeService(
            IBaseRepository<DataTypeClassification> dataClassTypeRepository,
            IBaseRepository<DataType> dataTypeRepository
            )
        {
            _dataTypeClassRepository = dataClassTypeRepository;
            _dataTypeRepository = dataTypeRepository;
        }

        #region 分类操作
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
        #endregion

        #region 数据类型

        /// <summary>
        /// 根据分类 获取数据类型
        /// </summary>
        /// <returns></returns>
        public async Task<PagedListResult<DataTypeOutput>> GetDataTypesByClass(DataTypeSearchInput input)
        {
            var tempList = _dataTypeRepository.Table
                .AsNoTracking()
                .WhereIf(input.ClassId.HasValue, c => c.DataTypeClassification.Id == input.ClassId.Value)
                .WhereIf(!string.IsNullOrEmpty(input.DataTypeName),c=>c.Name.Contains(input.DataTypeName))
                .OrderByDescending(c => c.CreateDateTime);

            var list = await tempList.Select(c => new DataTypeOutput()
            {
                Id=c.Id,
                Name = c.Name,
                Value = c.Value,
                Remark = c.Remark,
                CreateDateTime = c.CreateDateTime.ToString("yyyy-MM-dd HH:mm")
            })
            .PageBy(input.PageIndex, input.PageSize)
            .ToListAsync();
            int count = tempList.Count();
            return new PagedListResult<DataTypeOutput>()
            {
                Data = list,
                Count = count,
                Code = 0
            };
        }

        /// <summary>
        /// 添加数据类型
        /// </summary>
        /// <returns></returns>
        public async Task CreateDataType(DataTypeInput input)
        {
            DataType dataType = input.MapTo<DataType>();
            if (input.ClassId.HasValue)
            {
                dataType.DataTypeClassification = _dataTypeClassRepository.GetEntityById(input.ClassId.Value);
            }
            await _dataTypeRepository.InsertAsync(dataType);
        }

        /// <summary>
        /// 删除数据类型
        /// </summary>
        /// <returns></returns>
        public async Task DelDataType(int? id)
        {
            if (id.HasValue)
            {
                await _dataTypeRepository.DeleteAsync(id.Value);
            }
        }

        #endregion

        /// <summary>
        /// 模糊查询匹配的数据类型信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IList<QueryDataTypeOutput>> QueryDataTypeByName(string name)
        {
            return await (from d in _dataTypeRepository.Table
                          join c in _dataTypeClassRepository.Table
                          on d.DataTypeClassification.Id equals c.Id
                          where d.Name.Contains(name)
                          orderby d.CreateDateTime descending
                          select new QueryDataTypeOutput()
                          {
                              DataTypeId=d.Id,
                              Name = d.Name,
                              ClassName = c.Name
                          }).Take(10).ToListAsync();
        }
    }
}