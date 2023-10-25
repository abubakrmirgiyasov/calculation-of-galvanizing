using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Nomenclature.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Presenters.Nomenclature
{
    public class NomenclaturePresenter : BasePresenter<INomenclatureView, NomenclatureViewModel>
    {
        private List<NomenclatureStageViewModel> _nomenclatureStageViewModels;
        private NomenclatureViewModel _nomenclature;

        public NomenclaturePresenter(
            IApplicationController controller,
            INomenclatureView view) : base(controller, view)
        {
            View.Start += () => Start();
            View.Finish += () => Finish();
            View.AddStage += () => AddStage();
            View.Delete += () => DeleteStage();
        }

        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Открыто диалоговое окно номенклатуры");

                View.NomenclatureName = _nomenclature.Name;
                View.Weight = _nomenclature.Weight.ToString();
                View.MaxCountTraverse = _nomenclature.MaxCountTraverse.ToString();
                View.MaxWeightTraverse = _nomenclature.MaxWeightTraverse.ToString();
                _nomenclatureStageViewModels = _nomenclature.NomenclatureStages ?? new List<NomenclatureStageViewModel>();
                View.ShowStages(_nomenclatureStageViewModels);

                load.Finish();

                await flag;
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);
            }
        }

        private void AddStage()
        {
            var nomenclatureStage = new NomenclatureStageViewModel();

            Constants.DesktopLogger.Info("Добавление этапа");

            if (Controller.Create<StageChoosePresenter, NomenclatureStageViewModel>().RunDialog(nomenclatureStage, View.Form) == DialogResult.OK)
            {
                _nomenclatureStageViewModels.Add(nomenclatureStage);
                View.ShowStages(_nomenclatureStageViewModels);

                Constants.DesktopLogger.Info("Этап успешно добавлен");
            }
        }

        private void DeleteStage()
        {
            Constants.DesktopLogger.Info("Удаление этапа");

            _nomenclatureStageViewModels.Remove(View.ChoosedNomenclatureStage);
            View.ShowStages(_nomenclatureStageViewModels);

            Constants.DesktopLogger.Info("Этап успешно удален");
        }

        public override void Run(NomenclatureViewModel argument)
        {
            try
            {
                _nomenclature = argument;
                View.Show();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        public override DialogResult RunDialog(NomenclatureViewModel argument, Form owner)
        {
            _nomenclature = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public override void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }

        public override async Task<DialogResult> RunDialogAsync(NomenclatureViewModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                _nomenclature = argument;
                SetOwner(owner);
                return View.ShowDialog();
            }
        }

        public override void Finish()
        {
            var load = Controller.Create<LoadPresenter>();

            try
            {
                if (string.IsNullOrEmpty(View.Weight))
                {
                    throw new Exception("Заполните все поля корректно");
                }
                else if (string.IsNullOrEmpty(View.NomenclatureName))
                {
                    throw new Exception("Заполните все поля корректно");
                }
                else if (string.IsNullOrEmpty(View.MaxCountTraverse))
                {
                    throw new Exception("Заполните все поля корректно");
                }
                else if (string.IsNullOrEmpty(View.MaxWeightTraverse))
                {
                    throw new Exception("Заполните все поля корректно");
                }

                Constants.DesktopLogger.Info("Зактрытые диалогового окна номенклатуры");

                _ = load.RunDialogAsync(View.Form);

                load.SetStatus("Добавление данных в БД");

                _nomenclature.Name = View.NomenclatureName;
                _nomenclature.Weight = double.Parse(View.Weight);
                _nomenclature.MaxWeightTraverse = double.Parse(View.MaxWeightTraverse);
                _nomenclature.MaxCountTraverse = int.Parse(View.MaxCountTraverse);
                _nomenclature.NomenclatureStages = _nomenclatureStageViewModels;

                load.SetStatus("Добавлено успешно");

                load.Finish();

                Constants.DesktopLogger.Info("Диалоговое окно номенклатуры закрыто");

                View.Cancel = false;
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                View.Cancel = true;
                View.Error(ex.Message);
            }
        }
    }
}
