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
    /// 用户信息
    /// </summary>
    public partial class Users
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Users()
        {
            this.PersonalizationPerUser = new HashSet<PersonalizationPerUser>();
            this.Roles = new HashSet<Roles>();
        }

        /// <summary>
        /// 应用程序Id
        /// </summary>
        public System.Guid ApplicationId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public System.Guid UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 小写的用户名
        /// </summary>
        public string LoweredUserName { get; set; }

        /// <summary>
        /// 移动电话的pin码（未使用）
        /// </summary>
        public string MobileAlias { get; set; }

        /// <summary>
        /// 是否为匿名用户
        /// </summary>
        public bool IsAnonymous { get; set; }

        /// <summary>
        /// 最后活动日期
        /// </summary>
        public System.DateTime LastActivityDate { get; set; }

        /// <summary>
        /// 用户信息相关应用程序信息
        /// </summary>
        public virtual Applications Applications { get; set; }

        /// <summary>
        /// 用户信息相关成员信息
        /// </summary>
        public virtual Membership Membership { get; set; }

        /// <summary>
        /// 用户信息相关单个用户个性化信息集合
        /// </summary>
        public virtual ICollection<PersonalizationPerUser> PersonalizationPerUser { get; set; }

        /// <summary>
        /// 用户信息相关用户资料
        /// </summary>
        public virtual Profile Profile { get; set; }

        /// <summary>
        /// 用户信息相关角色集合
        /// </summary>
        public virtual ICollection<Roles> Roles { get; set; }
    }
}
