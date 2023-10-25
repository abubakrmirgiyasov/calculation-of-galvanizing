using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.Models;
using SZGC.Domain.Models.Response;
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Services
{
	public class UserManager
	{
		public async Task<UserViewModel> FormingViewModel(User user)
		{
			try
			{
				if (user != null)
				{
					var roleModels = new List<RoleViewModel>();
					var roles = await new RoleRequests().GetRoles(user.Login);

					for (int i = 0; i < roles.Count; i++)
					{
						roleModels.Add(new RoleManager().FormingViewModel(roles[i]));
					}

					return new UserViewModel
					{
						Id = user.Id,
						DateCreate = user.CreateDate,
						SurName = user.SurName,
						Name = user.SurName,
						MiddleName = user.SurName,
						Login = user.Login,
						UpdatePassword = user.UpdatePassword,
						Active = user.Active,
						Roles = roleModels,
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