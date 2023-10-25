using System;
using SZGC.Desktop.Services.Interfaces;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Services.Managers
{
	public class StageManagerService : IStageManagerService
	{
		public StageBindingModel FormingBindingModel(StageViewModel stageModel)
		{
			try
			{
				if (stageModel != null)
				{
					return new StageBindingModel
					{
						Id = stageModel.Id,
						Name = stageModel.Name,
						SortedBy = stageModel.SortedBy,
						IsSumming = stageModel.IsSumming,
					};
				}
				else
				{
					throw new Exception("Пустой этап");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
