﻿using LilyCms.BLL.Interfaces;
using LilyCms.DomainObjects.Sites;
using Microsoft.AspNetCore.Authorization;
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
    public class SitesController : ApiControllerBase
    {
        private readonly ISiteService _siteService;

        public SitesController(ISiteService siteService, ISecurityService securityService) : base(securityService)
        {
            _siteService = siteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SiteDto>>> GetSites()
        {
            try
            {
                var userEmail = GetUserEmail();
                var sites = await _siteService.GetSitesAsync(userEmail);

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
                var userEmail = GetUserEmail();
                if (siteDto.Id != default && !await _securityService.HasUserAccessToSite(siteDto.Id, userEmail))
                {
                    return Forbid();
                }
                return Ok(await _siteService.AddOrUpdateSiteAsync(siteDto, userEmail));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to add or update site: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }

        [HttpDelete]
        [Route("{siteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteSite(Guid siteId)
        {
            try
            {
                var userEmail = GetUserEmail();
                if (!await _securityService.HasUserAccessToSite(siteId, userEmail))
                {
                    return Forbid();
                }
                await _siteService.DeleteSiteAsync(siteId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to delete site: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{siteUrl}")]
        public async Task<ActionResult<SiteDetailsDto>> GetSiteDetails(string siteUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(siteUrl))
                {
                    return BadRequest("Url is not valid");
                }
                var userEmail = GetUserEmail();
                if (!await _securityService.HasUserAccessToSite(siteUrl, userEmail))
                {
                    return Forbid();
                }

                var site = await _siteService.GetSiteDetailsAsync(siteUrl, isUserView: false);

                if (site == null)
                {
                    return NotFound();
                }

                return Ok(site);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to retrieve site with url {siteUrl}: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("isUrlFree")]
        public async Task<ActionResult<bool>> IsSiteUrlFree(string siteUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(siteUrl))
                {
                    return BadRequest("Url is not valid");
                }

                return Ok(await _siteService.IsSiteUrlFreeAsync(siteUrl));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error occurred attempting to check if site url {siteUrl} is free: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }
    }
}
