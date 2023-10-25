using System;
using SZGC.Domain.Models;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
	public class StageManager
	{
		public StageViewModel FormingViewModel(Stage stage)
		{
			try
			{
				if (stage != null)
				{
					return new StageViewModel
					{
						Id = stage.Id,
						DateCreated = stage.DateCreated,
						Name = stage.Name,
						SortedBy = stage.SortedBy,
						IsSumming = stage.IsSumming,
					};
				}
				else
				{
					throw new Exception("Запись не найдено");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
	}
}