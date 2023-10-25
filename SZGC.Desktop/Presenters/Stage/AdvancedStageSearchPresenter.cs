using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Views.Stage.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.AdvancedSearch
{
    public class AdvancedStageSearchPresenter : BasePresenter<IAdvancedStageSearchView>
    {
        public List<StageViewModel> stageViewModels = new List<StageViewModel>();

        private IStageRequestService _stageRequestService;

        public AdvancedStageSearchPresenter(
            IStageRequestService stageRequestService,
            IApplicationController controller,
            IAdvancedStageSearchView view) : base(controller, view)
        {
            _stageRequestService = stageRequestService;

            View.Finish += () => Finish();
        }

        public async new void Finish()
        {
            try
            {
                Constants.DesktopLogger.Info("Проверка полей расширенного поиска");

                var stages = await _stageRequestService.GetStagesAsync();

                if (View.StageName != string.Empty)
                {
                    stages = stages.Where(x => x.Name.ToLower().IndexOf(View.StageName.ToLower()) != -1).ToList();
                }

                if (View.IsEnabled)
                {
                    stages = stages.Where(x => DateTime.Parse(x.DateCreated.ToShortDateString()) >= View.TopDate && DateTime.Parse(x.DateCreated.ToShortDateString()) <= View.BottomDate).ToList();
                }

                stageViewModels = stages;

                View.Cancel = false;
                View.DialogResult = DialogResult.OK;
                View.Close();

                Constants.DesktopLogger.Info("Закрытые формы расширенного поиска");
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Cancel = true;

                View.Error(ex.Message);
            }
        }
    }
}
