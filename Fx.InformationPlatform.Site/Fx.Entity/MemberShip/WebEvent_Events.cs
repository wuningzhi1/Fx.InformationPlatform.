//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Entity.MemberShip
{
    
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Web事件 Membership中不对外开放
    /// </summary>
    public partial class WebEvent_Events
    {
        /// <summary>
        /// 事件Id
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// 事件发生的UTC时间
        /// </summary>
        public System.DateTime EventTimeUtc { get; set; }

        /// <summary>
        /// 事件发生时间
        /// </summary>
        public System.DateTime EventTime { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// 事件序号
        /// </summary>
        public decimal EventSequence { get; set; }

        /// <summary>
        /// 事件发生
        /// </summary>
        public decimal EventOccurrence { get; set; }

        /// <summary>
        /// 事件代码
        /// </summary>
        public int EventCode { get; set; }

        /// <summary>
        /// 事件详细代码
        /// </summary>
        public int EventDetailCode { get; set; }

        /// <summary>
        /// 事件消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 程序路径
        /// </summary>
        public string ApplicationPath { get; set; }

        /// <summary>
        /// 程序相关虚拟路径
        /// </summary>
        public string ApplicationVirtualPath { get; set; }

        /// <summary>
        /// 机器名称
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public string Details { get; set; }
    }
}
