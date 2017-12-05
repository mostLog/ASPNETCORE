using L.Application.Dto;
using L.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace L.Web.Controllers
{
    public class DataTypeController : Controller
    {
        private readonly IDataTypeService _dataTypeService;

        public DataTypeController(IDataTypeService dataTypeService)
        {
            _dataTypeService = dataTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有分类的根节点
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetRootDataTypeClasses()
        {
            var list = await _dataTypeService.GetRootAllClasses();
            return Json(list);
        }

        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetChildrenClasses(int? parentId)
        {
            var list=await _dataTypeService.GetChildrenAllClasses(parentId);
            return Json(list);
        }

        /// <summary>
        /// 添加数据类型分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDataTypeClass(DataTypeClassInput input)
        {
            int result = 0;
            try
            {
                await _dataTypeService.CreateDataTypeClass(input);
            }
            catch (System.Exception)
            {
                result = -1;
            }
            return Json(result);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DelDataTypeClass(int? id)
        {
            int result = 0;
            try
            {
                await _dataTypeService.DelDataTypeClass(id);
            }
            catch (System.Exception)
            {

                result = -1;
            }
            return Json(result);
        }

        /// <summary>
        /// 获取分页数据类型信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPagedDataTypes(DataTypeSearchInput input)
        {
            var result = await _dataTypeService.GetDataTypesByClass(input);
            return Json(result);
        }

        /// <summary>
        /// 添加数据类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDataType(DataTypeInput input)
        {
            int result = 0;
            try
            {
                await _dataTypeService.CreateDataType(input);
            }
            catch (System.Exception)
            {
                result = -1;
            }
            return Json(result);
        }

        /// <summary>
        /// 删除数据类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DelDataType(int? id)
        {
            int result = 0;
            try
            {
                await _dataTypeService.DelDataType(id);
            }
            catch (System.Exception)
            {

                result = -1;
            }
            return Json(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> QueryDataTypeAsync(string searchText)
        {
            return Json(await _dataTypeService.QueryDataTypeByName(searchText));
        }
    }
}