using System;
using SZGC.Domain.Models;
using SZGC.Domain.Models.Response;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
    public class RoleManager
    {
        public RoleViewModel FormingViewModel(Role role)
        {
			try
			{
				if (role != null)
				{
					return new RoleViewModel
					{
						Id = role.Id,
						Name = role.Name,
					};
				}
				else
				{
					throw new Exception(UserExceptions.StringNotFoundUser);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
        }
    }
}