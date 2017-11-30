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
    }
}