using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Presenters.Auth;

namespace SZGC.Desktop.Views
{
    static class Program
    {
        public static readonly ApplicationContext context = new ApplicationContext();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ru-RU");
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<Auth.Interfaces.IAuthVIew, Auth.AuthView>()
                .RegisterView<Shared.Interfaces.ILoadView, Shared.LoadView>()
                .RegisterView<Main.Interfaces.IMainView, Main.MainView>()
                .RegisterView<Stage.Interfaces.IStageView, Stage.StageView>()
                .RegisterView<Nomenclature.Interfaces.INomenclatureView, Nomenclature.NomenclatureView>()
                .RegisterView<Nomenclature.Interfaces.IChooseStageView, Nomenclature.ChooseStageView>()
                .RegisterView<Order.Interfaces.IOrderView, Order.OrderView>()
                .RegisterView<Order.Interfaces.IChooseStageView, Order.ChooseStageView>()
                .RegisterView<Order.Interfaces.IChooseNomenclatureView, Order.ChooseNomenclatureView>()
                .RegisterView<Order.Interfaces.IAdvancedOrderSearchView, Order.AdvancedOrderSearchView>()
                .RegisterView<Nomenclature.Interfaces.IAdvancedNomenclatureSearchView, Nomenclature.AdvancedNomenclatureSearchView>()
                .RegisterView<Stage.Interfaces.IAdvancedStageSearchView, Stage.AdvancedStageSearchView>()
                .RegisterView<Setting.Interfaces.ISettingView, Setting.SettingView>()
                .RegisterService<Services.Settings.Interfaces.IDataUserSettingsService, Services.Settings.DataUserSettingsService>()
                .RegisterService<Middleware.Interfaces.IAuthRequestService, Middleware.Services.Requests.AuthRequestService>()
                .RegisterService<Middleware.Services.Interfaces.IUserRequestService, Middleware.Services.Requests.UserRequestService>()
                .RegisterService<Middleware.Services.Interfaces.INomenclatureRequestService, Middleware.Services.Requests.NomenclatureRequestService>()
                .RegisterService<Middleware.Services.Interfaces.IOrderRequestService, Middleware.Services.Requests.OrderRequestService>()
                .RegisterService<Middleware.Services.Interfaces.IStageRequestService, Middleware.Services.Requests.StageRequestService>()
                .RegisterService<Services.Interfaces.INomenclatureManagerService, Services.Managers.NomenclatureManagerService>()
                .RegisterService<Services.Interfaces.IOrderManagerService, Services.Managers.OrderManagerService>()
                .RegisterService<Services.Interfaces.IStageManagerService, Services.Managers.StageManagerService>()
                .RegisterService<Middleware.Services.Interfaces.IParamsService, Middleware.Services.ParamsService>()
                .RegisterService<Middleware.Services.Interfaces.ISettingRequestService, Middleware.Services.Requests.SettingRequestService>()
                .RegisterInstance(new ApplicationContext());

            controller.Create<AuthPresenter>().Run();
        }
    }
}
