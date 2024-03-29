﻿using LilyCms.DomainObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilyCms.BLL.Interfaces
{
    public interface IPageService
    {
        Task<IEnumerable<PageDto>> GetPagesAsync(string siteUrl);
        Task<PageDto> AddOrUpdatePageAsync(PageDto pageDto);
        Task DeletePageAsync(Guid pageId);
        Task<bool> IsPageUrlFreeAsync(string pageUrl, Guid siteId);
        Task<PageDto> GetPageByFeedbackIdAsync(Guid pageFeedbackId);
        Task<PageDetailsDto> GetPageDetailsAsync(string siteUrl, string pageUrl, bool isUserView);
        Task<PageDetailsDto> SavePageContentAsync(PageDetailsDto pageDetailsDto);
    }
}
