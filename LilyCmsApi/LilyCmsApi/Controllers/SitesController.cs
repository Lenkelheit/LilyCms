﻿using LilyCms.BLL.Interfaces;
using LilyCms.DomainObjects.Sites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilyCmsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        private readonly ISiteService _siteService;

        public SitesController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SiteDto>>> GetSites()
        {
            try
            {
                var sites = await _siteService.GetSitesAsync();

                return Ok(sites);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to retrieve sites: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SiteDto>> AddOrUpdateSite(SiteDto siteDto)
        {
            try
            {
                return Ok(await _siteService.AddOrUpdateSiteAsync(siteDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to add or update site: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }

        [HttpDelete]
        [Route("{siteId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteSite(Guid siteId)
        {
            try
            {
                await _siteService.DeleteSiteAsync(siteId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to delete site: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }

    }
}
