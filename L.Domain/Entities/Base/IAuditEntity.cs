using System;

namespace L.Domain.Base
{
    /// <summary>
    /// 审计信息
    ///
    /// 暂时无创建人
    /// </summary>
    public interface IAuditEntity
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        string CreatePerson { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        DateTime? OperaterDateTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        string OperaterPerson { get; set; }
    }
}