using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.AdvancedSearch;
using SZGC.Desktop.Presenters.Nomenclature;
using SZGC.Desktop.Presenters.Order;
using SZGC.Desktop.Presenters.Setting;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Presenters.Stage;
using SZGC.Desktop.Services.Interfaces;
using SZGC.Desktop.Views.Main.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Main
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly ISettingRequestService _settingRequestService;
        private readonly INomenclatureManagerService _nomenclatureManagerService;
        private readonly IOrderRequestService _orderRequestService;
        private readonly IStageRequestService _stageRequestService;
        private readonly INomenclatureRequestService _nomenclatureRequestService;
        private readonly IOrderManagerService _orderManagerService;
        private readonly IStageManagerService _stageManagerService;

        public MainPresenter(
            ISettingRequestService settingRequestService,
            IStageManagerService stageManagerService,
            IOrderManagerService orderManagerService,
            INomenclatureManagerService nomenclatureManagerService,
            IOrderRequestService orderRequestService,
            IStageRequestService stageRequestService,
            INomenclatureRequestService nomenclatureRequestService,
            IApplicationController controller,
            IMainView view) : base(controller, view)
        {
            try
            {
                _settingRequestService = settingRequestService;
                _stageManagerService = stageManagerService;
                _orderManagerService = orderManagerService;
                _orderRequestService = orderRequestService;
                _stageRequestService = stageRequestService;
                _nomenclatureRequestService = nomenclatureRequestService;
                _nomenclatureManagerService = nomenclatureManagerService;

                View.Start += () => Start();
                View.Finish += () => Finish();
                View.Settings += () => Settings();
                View.Reset += async () => await Refresh();
                View.Nomenclature += async () => await ShowNomenclatureTable();
                View.Stage += async () => await ShowStageTable();
                View.Order += async () => await ShowOrderTable();
                View.Add += () => AddData();
                View.Edit += () => EditData();
                View.Remove += () => RemoveData();
                View.Search += () => Search();
                View.DoubleClickToDataGrid += () => EditData();
                View.AdvancedSearch += () => AdvancedSearch();
                View.AddBasedOn += () => AddBaseOn();
            }
            catch (Exception ex)
            {
                View.Error(ex.Message);
            }
        }

        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Загружено главня форма");
                Constants.DesktopLogger.Info("Получение данных");

                load.SetStatus("Получение настроек");

                GetSettings();

                load.SetStatus("Успешное получение настроек");

                load.SetStatus("Получение данных");

                ShowData();

                load.SetStatus("Успешное получение данных");

                Constants.DesktopLogger.Info("Успешное получение данных");

                load.Finish();

                await flag;
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);

                View.Close();
            }
        }

        private List<T> GetModels<T>(List<T> entity) where T : class
        {
            return entity;
        }

        private async void GetSettings()
        {
            var settings = await _settingRequestService.GetSettingsAsync();
            for(int i = 0; i < settings.Count; i++)
            {
                switch (settings[i].Name)
                {
                    case "WorkingShift":
                        Domain.Settings.Shared.WorkingShift = Convert.ToInt32(settings[i].Value);
                        break;
                }
            }
        }

        private async void ShowData()
        {
            var load = Controller.Create<LoadPresenter>();

            switch (View.ButtonTag)
            {
                case "order":
                    try
                    {
                        Constants.DesktopLogger.Info("Загрузка заказов");

                        load.SetStatus("Получение данных...");

                        _ = load.RunDialogAsync(View.Form);

                        await ShowOrderTable();

                        Constants.DesktopLogger.Info("Заказыы успешно загружены");

                        load.Finish();
                    }
                    catch (Exception ex)
                    {
                        Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                        load.Finish();

                        View.Error(ex.Message);
                    }
                    break;
                case "nomen":
                    try
                    {
                        Constants.DesktopLogger.Info("Загрузка номенклатуры");

                        load.SetStatus("Получение данных...");

                        _ = load.RunDialogAsync(View.Form);

                        await ShowNomenclatureTable();

                        Constants.DesktopLogger.Info("Номенклатуры успешно загружены");

                        load.Finish();
                    }
                    catch (Exception ex)
                    {
                        Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                        load.Finish();

                        View.Error(ex.Message);
                    }
                    break;
                case "stage":
                    try
                    {
                        Constants.DesktopLogger.Info("Загрузка этапов");

                        load.SetStatus("Получение данных...");

                        _ = load.RunDialogAsync(View.Form);

                        await ShowStageTable();

                        Constants.DesktopLogger.Info("Этапы успешно загружены");

                        load.Finish();
                    }
                    catch (Exception ex)
                    {
                        Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                        load.Finish();

                        View.Error(ex.Message);
                    }
                    break;
            }
        }

        private async void Settings()
        {
            Constants.DesktopLogger.Info("Открыто диалоговое окно изменения настроек");

            if (Controller.Create<SettingPresenter>().RunDialog(View.Form) == DialogResult.OK)
            {
                await Refresh();
            }
        }

        private async void AddData()
        {
            try
            {
                switch (View.ButtonTag)
                {
                    case "order":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для добавление заказа");

                        var orderViewModel = new OrderViewModel();
                        if (Controller.Create<OrderPresenter, OrderViewModel>().RunDialog(orderViewModel, View.Form) == DialogResult.OK)
                        {
                            Constants.DesktopLogger.Info("Добавление заказа");

                            await _orderRequestService.AddOrderAsync(_orderManagerService.FormingBindingModel(orderViewModel));

                            Constants.DesktopLogger.Info("Заказ успешно добавлено");

                            await Refresh();
                        }
                        break;
                    case "nomen":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для добавление номенклатуры");

                        var nomenclatureViewModel = new NomenclatureViewModel();
                        if (Controller.Create<NomenclaturePresenter, NomenclatureViewModel>().RunDialog(nomenclatureViewModel, View.Form) == DialogResult.OK)
                        {
                            Constants.DesktopLogger.Info("Добавление номенклатуры");

                            await _nomenclatureRequestService.AddNomenclatureAsync(_nomenclatureManagerService.FormingBindingModel(nomenclatureViewModel));

                            Constants.DesktopLogger.Info("Номеклатура успешно добавлено");

                            await Refresh();
                        }
                        break;
                    case "stage":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для добавление этапа");

                        var stageViewModel = new StageViewModel();
                        if (Controller.Create<StagePresenter, StageViewModel>().RunDialog(stageViewModel, View.Form) == DialogResult.OK)
                        {
                            Constants.DesktopLogger.Info("Добавление этапа");

                            await _stageRequestService.AddStageAsync(_stageManagerService.FormingBindingModel(stageViewModel));

                            Constants.DesktopLogger.Info("Этап успешно добавлено");

                            await Refresh();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        private async void EditData()
        {
            var load = Controller.Create<LoadPresenter>();

            try
            {
                switch (View.ButtonTag)
                {
                    case "order":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для изменение заказа");

                        var order = View.DataBoundItem<OrderViewModel>();
                        if (order != null)
                        {
                            if (Controller.Create<OrderPresenter, OrderViewModel>().RunDialog(order, View.Form) == DialogResult.OK)
                            {
                                Constants.DesktopLogger.Info("Изменение заказа");

                                load.SetStatus("Изменение...");

                                _ = load.RunDialogAsync(View.Form);

                                await _orderRequestService.EditOrderAsync(_orderManagerService.FormingBindingModel(order));

                                Constants.DesktopLogger.Info("Заказ успешно изменен");

                                await Refresh();

                                load.Finish();
                            }
                        }
                        break;
                    case "nomen":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для изменение номенклатуры");

                        var nomenclature = View.DataBoundItem<NomenclatureViewModel>();
                        if (nomenclature != null)
                        {
                            if (Controller.Create<NomenclaturePresenter, NomenclatureViewModel>().RunDialog(nomenclature, View.Form) == DialogResult.OK)
                            {
                                Constants.DesktopLogger.Info("Изменение номенклатуры");

                                load.SetStatus("Изменение...");

                                _ = load.RunDialogAsync(View.Form);

                                await _nomenclatureRequestService.EditNomenclatureAsync(_nomenclatureManagerService.FormingBindingModel(nomenclature));

                                Constants.DesktopLogger.Info("Номенклатура успешно изменен");

                                await Refresh();

                                load.Finish();
                            }
                        }
                        break;
                    case "stage":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для изменение этапа");

                        var stage = View.DataBoundItem<StageViewModel>();
                        if (stage != null)
                        {
                            if (Controller.Create<StagePresenter, StageViewModel>().RunDialog(stage, View.Form) == DialogResult.OK)
                            {
                                Constants.DesktopLogger.Info("Изменение этапа");

                                load.SetStatus("Добавление...");

                                _ = load.RunDialogAsync(View.Form);

                                await _stageRequestService.EditStageAsync(_stageManagerService.FormingBindingModel(stage));

                                Constants.DesktopLogger.Info("Этап успешно изменен");

                                await Refresh();

                                load.Finish();
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                View.Error(ex.Message);
            }
        }

        private async void RemoveData()
        {
            var load = Controller.Create<LoadPresenter>();

            try
            {
                switch (View.ButtonTag)
                {
                    case "order":
                        OrderViewModel order = View.DataBoundItem<OrderViewModel>();
                        if (order != null)
                        {
                            Constants.DesktopLogger.Info("Открыто диалоговое окно для удаление заказа");

                            var messageBox = MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (messageBox == DialogResult.Yes)
                            {
                                Constants.DesktopLogger.Info("Удаление заказа");

                                _ = load.RunDialogAsync(View.Form);

                                load.SetStatus("Удаление...");

                                await _orderRequestService.RemoveOrderAsync(_orderManagerService.FormingBindingModel(order));

                                Constants.DesktopLogger.Info("Заказ успешно удален");

                                load.SetStatus("Успешно удален");
                                load.Finish();

                                await Refresh();
                            }
                        }
                        break;
                    case "nomen":
                        NomenclatureViewModel nomenclature = View.DataBoundItem<NomenclatureViewModel>();
                        if (nomenclature != null)
                        {
                            Constants.DesktopLogger.Info("Открыто диалоговое окно для удаление номенклатуры");

                            var messageBox = MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (messageBox == DialogResult.Yes)
                            {
                                Constants.DesktopLogger.Info("Удаление номенклатуры");

                                _ = load.RunDialogAsync(View.Form);

                                load.SetStatus("Удаление...");

                                await _nomenclatureRequestService.RemoveNomenclatureAsync(_nomenclatureManagerService.FormingBindingModel(nomenclature));

                                Constants.DesktopLogger.Info("Номенклатура успешно удален");

                                load.SetStatus("Успешно удален");
                                load.Finish();

                                await Refresh();
                            }
                        }
                        break;
                    case "stage":
                        StageViewModel stage = View.DataBoundItem<StageViewModel>();
                        if (stage != null)
                        {
                            Constants.DesktopLogger.Info("Открыто диалоговое окно для удаление этапа");

                            var messageBox = MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (messageBox == DialogResult.Yes)
                            {
                                Constants.DesktopLogger.Info("Удаление этапа");

                                _ = load.RunDialogAsync(View.Form);

                                load.SetStatus("Удаление...");

                                await _stageRequestService.RemoveStageAsync(_stageManagerService.FormingBindingModel(stage));

                                Constants.DesktopLogger.Info("Этап успешно удален");

                                load.SetStatus("Успешно удален");
                                load.Finish();

                                await Refresh();
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                View.Error(ex.Message);
            }
        }

        private async void AddBaseOn()
        {
            var load = Controller.Create<LoadPresenter>();

            try
            {
                switch (View.ButtonTag)
                {
                    case "nomen":
                        Constants.DesktopLogger.Info("Открыто диалоговое окно для добавление номенклатуры");

                        var nomenclatureViewModel = View.DataBoundItem<NomenclatureViewModel>();
                        nomenclatureViewModel.Name += " (скопировано)";
                        if (Controller.Create<NomenclaturePresenter, NomenclatureViewModel>().RunDialog(nomenclatureViewModel, View.Form) == DialogResult.OK)
                        {
                            Constants.DesktopLogger.Info("Добавление номенклатуры");

                            await _nomenclatureRequestService.AddNomenclatureAsync(_nomenclatureManagerService.FormingBindingModel(nomenclatureViewModel));

                            Constants.DesktopLogger.Info("Номеклатура успешно добавлено");

                            await Refresh();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                View.Error(ex.Message);
            }
        }

        private async void Search()
        {
            try
            {
                switch (View.ButtonTag)
                {
                    case "order":
                        Constants.DesktopLogger.Info("Поиск по заказам");

                        var orders = GetModels(await _orderRequestService.GetOrdersAsync());
                        orders = orders.Where(x => x.ToSearchString().ToLower().IndexOf(View.SearchText.ToLower()) != -1).ToList();
                        FilterDataGrid(View.SearchText, orders);

                        Constants.DesktopLogger.Info("Поиск завершен");
                        break;
                    case "nomen":
                        Constants.DesktopLogger.Info("Поиск по номенклатурам");

                        var nomenclatures = GetModels(await _nomenclatureRequestService.GetNomenclaturesAsync());
                        nomenclatures = nomenclatures.Where(x => x.ToSearchString().ToLower().IndexOf(View.SearchText.ToLower()) != -1).ToList();
                        FilterDataGrid(View.SearchText, nomenclatures);

                        Constants.DesktopLogger.Info("Поиск завершен");
                        break;
                    case "stage":
                        Constants.DesktopLogger.Info("Поиск по этапом");

                        var stages = GetModels(await _stageRequestService.GetStagesAsync());
                        stages = stages.Where(x => x.ToSearchString().ToLower().IndexOf(View.SearchText.ToLower()) != -1).ToList();
                        FilterDataGrid(View.SearchText, stages);

                        Constants.DesktopLogger.Info("Поиск завершен");
                        break;
                }
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        private void FilterDataGrid<T>(string text, List<T> list)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    if (list.Count() > 0)
                    {
                        View.ShowData(list);
                    }
                    else
                    {
                        View.ShowData(list);

                        View.Warning("По этому запоросу ничего не найдено!");
                    }
                }
                else
                {
                    View.Warning("Поле не может быть пустым");
                }
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        private async Task Refresh()
        {
            try
            {
                switch (View.ButtonTag)
                {
                    case "order":
                        Constants.DesktopLogger.Info("Обновление заказа");

                        View.ShowData(GetModels(await _orderRequestService.GetOrdersAsync()));

                        Constants.DesktopLogger.Info("Заказ успешно обновлен");
                        break;
                    case "nomen":
                        Constants.DesktopLogger.Info("Обновление номенклатуры");

                        View.ShowData(GetModels(await _nomenclatureRequestService.GetNomenclaturesAsync()));

                        Constants.DesktopLogger.Info("Номенклатура успешно обновлен");
                        break;
                    case "stage":
                        Constants.DesktopLogger.Info("Обновление этапа");

                        View.ShowData(GetModels(await _stageRequestService.GetStagesAsync()));

                        Constants.DesktopLogger.Info("Этап успешно обновлен");
                        break;
                }

                View.SearchText = "";
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                throw new Exception(ex.Message);
            }
        }

        private async Task ShowNomenclatureTable()
        {
            View.ShowData(GetModels(await _nomenclatureRequestService.GetNomenclaturesAsync()));
        }

        private async Task ShowStageTable()
        {
            View.ShowData(GetModels(await _stageRequestService.GetStagesAsync()));
        }

        private async Task ShowOrderTable()
        {
            View.ShowData(GetModels(await _orderRequestService.GetOrdersAsync()));
        }

        private void AdvancedSearch()
        {
            switch (View.ButtonTag)
            {
                case "order":
                    var orders = Controller.Create<AdvancedOrderSearchPresenter>();
                    if (orders.RunDialog(View.Form) == DialogResult.OK)
                    {
                        Constants.DesktopLogger.Info("Откыто окно расширенного поиска по заказам");

                        View.ShowData(orders.orderViewModels);

                        Constants.DesktopLogger.Info("Расширенный поиск по заказам завершен");
                    }
                    break;
                case "nomen":
                    var nomenclatures = Controller.Create<AdvancedNomenclatureSearchPresenter>();
                    if (nomenclatures.RunDialog(View.Form) == DialogResult.OK)
                    {
                        Constants.DesktopLogger.Info("Откыто окно расширенного поиска по номенклатурам");

                        View.ShowData(nomenclatures.nomenclatureViewModels);

                        Constants.DesktopLogger.Info("Расширенный поиск по номенклатурам завершен");
                    }
                    break;
                case "stage":
                    var stages = Controller.Create<AdvancedStageSearchPresenter>();
                    if (stages.RunDialog(View.Form) == DialogResult.OK)
                    {
                        Constants.DesktopLogger.Info("Откыто окно расширенного поиска по этапам");

                        View.ShowData(stages.stageViewModels);

                        Constants.DesktopLogger.Info("Расширенный поиск по этапам завершен");
                    }
                    break;
            }
        }

        private new void Finish()
        {
            Constants.DesktopLogger.Info("Закрытые главной формы");

            View.Cancel = false;
            View.Close();
        }
    }
}
