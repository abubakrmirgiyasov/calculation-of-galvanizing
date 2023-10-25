using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Views.Nomenclature.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Nomenclature
{
    public class AdvancedNomenclatureSearchPresenter : BasePresenter<IAdvancedNomenclatureSearchView>
    {
        public List<NomenclatureViewModel> nomenclatureViewModels = new List<NomenclatureViewModel>();

        private INomenclatureRequestService _nomenclatureRequestService;

        public AdvancedNomenclatureSearchPresenter(
            INomenclatureRequestService nomenclatureRequestService,
            IApplicationController controller,
            IAdvancedNomenclatureSearchView view) : base(controller, view)
        {
            _nomenclatureRequestService = nomenclatureRequestService;

            View.Finish += () => Finish();
        }

        public async new void Finish()
        {
            try
            {
                Constants.DesktopLogger.Info("Проверка полей расширенного поиска");

                var nomenclatures = await _nomenclatureRequestService.GetNomenclaturesAsync();

                if (View.NomenclatureName != string.Empty)
                {
                    nomenclatures = nomenclatures.Where(x => x.Name.ToLower().IndexOf(View.NomenclatureName.ToLower()) != -1).ToList();
                }

                if (View.Weight != string.Empty && int.Parse(View.Weight) >= 0.1)
                {
                    nomenclatures = nomenclatures.Where(x => x.Weight.ToString().IndexOf(View.Weight) != -1).ToList();
                }

                if (View.MaxWeightTraverse != string.Empty && double.Parse(View.MaxWeightTraverse) >= 0.1)
                {
                    nomenclatures = nomenclatures.Where(x => x.MaxWeightTraverse.ToString().IndexOf(View.MaxWeightTraverse) != -1).ToList();
                }

                if (View.MaxCountTraverse != string.Empty && int.Parse(View.MaxCountTraverse) >= 0.1)
                {
                    nomenclatures = nomenclatures.Where(x => x.MaxCountTraverse.ToString().IndexOf(View.MaxCountTraverse) != -1).ToList();
                }

                if (View.IsEnabled)
                {
                    nomenclatures = nomenclatures.Where(x => DateTime.Parse(x.DateCreated.ToShortDateString()) >= View.TopDate && DateTime.Parse(x.DateCreated.ToShortDateString()) <= View.BottomDate).ToList();
                }

                nomenclatureViewModels = nomenclatures;

                Constants.DesktopLogger.Info("Закрытые формы расширенного поиска");

                View.Cancel = false;
                View.DialogResult = DialogResult.OK;
                View.Close();
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
