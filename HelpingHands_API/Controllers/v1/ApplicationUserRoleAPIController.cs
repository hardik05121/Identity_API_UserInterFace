﻿using AutoMapper;
using Azure;
using HelpingHands_API.Models;
using HelpingHands_API.Models.DTO;
using HelpingHands_API.Models.VM;
using HelpingHands_API.Repository.IRepostiory;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HelpingHands_API.Controllers.v1
{

    [Route("api/v{version:apiVersion}/ApplicationUserRoleAPI")]
    [ApiController]
    [ApiVersion("1.0")]

    public class ApplicationUserRoleAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationUserRoleAPIController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetApplicationUserRoles()
        {
            try
            {
                IEnumerable<ApplicationUserRole> applicationUserRoleList = await _unitOfWork.ApplicationUserRole.GetAllAsync();
                _response.Result = _mapper.Map<List<ApplicationUserRoleDTO>>(applicationUserRoleList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{Id}", Name = "GetApplicationUserRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetApplicationUserRole(string Id)
        {
            try
            {
                var applicationUser = await _unitOfWork.ApplicationUserRole.GetAsync(u => u.UserId == Id);
                if (applicationUser == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ApplicationUserRoleDTO>(applicationUser);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}