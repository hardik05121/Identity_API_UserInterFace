﻿
using HelpingHands_Web.Models.VM;

namespace HelpingHands_Web.Service.IService
{
	public interface IApplicationUserService
    {
            Task<T> GetAllAsync<T>(string token);
            Task<T> GetAsync<T>(string Id, string token);
            Task<T> UpdateAsync<T>(UserVM dto, string token);
    }
}
