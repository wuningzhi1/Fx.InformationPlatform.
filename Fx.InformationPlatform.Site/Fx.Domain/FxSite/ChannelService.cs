﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.FxSite;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    public class ChannelService :  BaseIService<SiteContext>,IService.IChannelService, IDisposable
    {
        public ChannelService()
        {
            this.content = new SiteContext();
        }

        public List<Channel> GetAllChannels()
        {
            return content.Channels.OrderBy(r=>r.Sorted).ToList();
        }
    }
}