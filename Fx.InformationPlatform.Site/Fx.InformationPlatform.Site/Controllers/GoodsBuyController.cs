﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity;
using Fx.Entity.FxGoods;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 物品求购发布控制器
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
    public class GoodsBuyController : BaseController, ISiteJob
    {
        IGoods goodsService;
        IBuyGoods buyService;
        IAccountService accountService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="goodsService">点下物品基础信息接口</param>
        /// <param name="buyService">物品求购保存读取接口</param>
        /// <param name="accountService">帐号服务接口</param>
        public GoodsBuyController(IGoods goodsService,
            IBuyGoods buyService,
            IAccountService accountService)
        {
            this.goodsService = goodsService;
            this.buyService = buyService;
            this.accountService = accountService;
        }

        /// <summary>
        /// 数码产品求购页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Electronics()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 居家用品求购页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult HomeSupplies()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 衣服鞋包求购页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Fashion()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 文化生活求购页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult CultureLife()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 物品其他求购页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Other()
        {
            BindData();
            return View();
        }

        private void BindData()
        {
            BindCatagroy();
            BindArea();
        }

        private void BindArea()
        {
            var siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            ViewData["area"] = siteCache.GetAreaListItems();
        }

        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            goodsService.GetChannelBuyDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }

        /// <summary>
        ///  数码产品发布
        /// </summary>
        /// <param name="goods">物品求购视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Electronics(BuyViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  居家用品发布
        /// </summary>
        /// <param name="goods">物品求购视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult HomeSupplies(BuyViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  衣服鞋包发布
        /// </summary>
        /// <param name="goods">物品求购视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Fashion(BuyViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  文化生活发布
        /// </summary>
        /// <param name="goods">物品求购视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult CultureLife(BuyViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  物品其他发布
        /// </summary>
        /// <param name="goods">物品求购视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Other(BuyViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }




        private ActionResult PublishGoods(BuyViewGoods goods, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildGoods(goods, facefile, otherfile, badfile))
            {
                GoodsBuyInfo transfergoods = MapperGoods(goods);
                buyService.SaveBuyGoods(transfergoods);
                RunJob();
                FxCacheService.FxSite.GlobalCache cache = System.Web.Mvc.DependencyResolver.Current.GetService<FxCacheService.FxSite.GlobalCache>();
                cache.InfoPublishAllCountAdd();
                return View("Success");
            }
            return View("FaildTransfer");
        }

        private bool BuildGoods(BuyViewGoods goods, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            InitParas();
            string pictureName;
            string pictureMinName;
            //图片保存到
            #region FaceFile
            foreach (var face in facefile)
            {

                if (face.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    goods.FaceFiles.Add(new BuyPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        BuyPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(face, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            #region OtherFile
            foreach (var other in otherfile)
            {
                if (other.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    goods.OtherFiles.Add(new BuyPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        BuyPictureCatagroy = (int)PictureCatagroy.Other,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(other, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            #region badFile
            foreach (var bad in badfile)
            {
                if (bad.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    goods.BadFiles.Add(new BuyPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        BuyPictureCatagroy = (int)PictureCatagroy.Bad,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(bad, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion
            return true;
        }

        private GoodsBuyInfo MapperGoods(BuyViewGoods goods)
        {
            var info = new GoodsBuyInfo();
            info.CatagroyId = goods.CatagroyId;
            info.AreaId = goods.AreaId;
            info.ChangeMsg = goods.ChangeGoodsMsg;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = goods.CityId;
            info.GoodsConditionMsg = goods.GoodConditonMsg;
            info.GoodsconditonId = goods.GoodConditionId;
            info.IsChange = goods.IsChangeGoods;
            info.Mark = goods.Mark;
            goods.FaceFiles.ForEach(r => info.Pictures.Add(r));
            goods.OtherFiles.ForEach(r => info.Pictures.Add(r));
            goods.BadFiles.ForEach(r => info.Pictures.Add(r));
            info.Price = (int)goods.Price;
            info.PublishTitle = goods.Title;
            info.PublishUserEmail = goods.Email;
            info.UserAccount = User.Identity.Name;
            return info;
        }


        #region UpLoad
        private readonly string transferPhysicalImagePath = @"UploadImage\Buy\GoodsImage\";
        private readonly string transferVirtualImagePath = "UploadImage/Buy/GoodsImage/";


        private string GetPhysicalPath()
        {
            return string.Format(@"{0}{1}{2}\{3}\", HttpContext.Server.MapPath("../"), transferPhysicalImagePath, GetDate(), GetUserId());
        }

        private string GetVirtualPath()
        {
            return string.Format("{0}{1}/{2}/", transferVirtualImagePath, GetDate(), GetUserId());
        }


        string userId;
        private string GetUserId()
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = accountService.GetCurrentUser(User.Identity.Name).ToString();
            }
            return userId;
        }

        string date;
        private string GetDate()
        {
            if (string.IsNullOrEmpty(date))
            {
                date = Helper.GetDate();
            }
            return date;
        }


        int pictureCount = 100;
        string timestamp = DateTime.Now.GetTimeStamp();

        private string GetPictureName()
        {
            string pictureName = string.Format("{0}{1}.jpg", timestamp, pictureCount);
            pictureCount++;
            return pictureName;
        }

        private string GetPictureMinName()
        {
            string pictureName = string.Format("{0}{1}-64X64.jpg", timestamp, pictureCount);
            return pictureName;
        }


        private void SaveFile(HttpPostedFileBase file, string folderPath, string filePath)
        {
            if (!System.IO.File.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            file.SaveAs(filePath);
        }
        #endregion

        /// <summary>
        /// Job执行
        /// </summary>
        public void RunJob()
        {
            new System.Threading.Thread(() =>
            {
                new FxTask.FxGoods.Buy.GoodsBuyJobLoad().Execute();
            }).Start();
        }
    }
}
