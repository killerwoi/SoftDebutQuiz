using Blazing.Mvvm.ComponentModel;
using FrontEnd.Component;
using FrontEnd.Define;
using FrontEnd.Model.Request;
using FrontEnd.Model.Response;
using FrontEnd.Repository.Interface;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.Notifications;

namespace FrontEnd.ViewModel
{
    public partial class SoftDebuteQuizViewModel : ViewModelBase
    {
        private readonly IApiRepository<DefaultResponse<object>> _apiRepository;
        private readonly IApiRepository<DefaultResponse<List<EmployeeGetResponseModel>>> _apiEmployeeGetRepository;
        private readonly IApiRepository<DefaultResponse<List<DepartmentGetResponseModel>>> _apiDepartmentGetRepository;
        private readonly IApiRepository<DefaultResponse<List<PositionResponseModel>>> _apiJobPositionGetRepository;

        public List<object> GridToolbarItems = [
            new ItemModel() { Text = "เพิ่มข้อมูล",TooltipText="เพิ่มข้อมูล", PrefixIcon = "e-add", Id = "Grid_add"},
            new ItemModel(){ Text = "เรียกดูข้อมูลทั้งหมด",TooltipText="เรียกดูข้อมูลทั้งหมด", PrefixIcon= "e-refresh", Id="Grid_refresh"}
        ];

        public readonly DialogSettings _dialogSettings;
        public PopupComponent PopUp { get; set; } = new PopupComponent();
        public string ErrorMessage { get; set; }
        public List<EmployeeGetResponseModel> EmployeeData { get; set; }
        public List<DepartmentGetResponseModel> DepartmentData { get; set; }
        public List<PositionResponseModel> JobPositionData { get; set; }

        public SfGrid<EmployeeGetResponseModel>? DefaultGrid;

        public Dictionary<string, DepartmentGetResponseModel> DepartmentDataLookUp;
        public Dictionary<string, PositionResponseModel> PositionDataLookUp;

        public bool IsAddMode { get; set; } = false;
        public SfToast? ToastObj { get; set; }

        public SoftDebuteQuizViewModel(
            IApiRepository<DefaultResponse<object>> apiRepository,
            IApiRepository<DefaultResponse<List<EmployeeGetResponseModel>>> apiEmployeeGetRepository,
            IApiRepository<DefaultResponse<List<DepartmentGetResponseModel>>> apiDepartmentGetRepository,
            IApiRepository<DefaultResponse<List<PositionResponseModel>>> apiJobPositionGetRepository)
        {
            _apiRepository = apiRepository;
            _apiEmployeeGetRepository = apiEmployeeGetRepository;
            _apiDepartmentGetRepository = apiDepartmentGetRepository;
            _apiJobPositionGetRepository = apiJobPositionGetRepository;
            EmployeeData = [];
            DepartmentData = [];
            JobPositionData = [];
            DepartmentDataLookUp = [];
            PositionDataLookUp = [];
            _dialogSettings = new DialogSettings { Width = "600px", ShowCloseIcon = false };
        }

        public async Task GetEmployeeData()
        {
            try
            {
                var result = await _apiEmployeeGetRepository.CallApi(EndPointUrl.GetEmployee, HttpMethod.Get);
                EmployeeData = result!.Data!;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task GetJobPositionData()
        {
            try
            {
                var result = await _apiJobPositionGetRepository.CallApi(EndPointUrl.GetPosition, HttpMethod.Get);
                JobPositionData = result!.Data!;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task GetDepartmentData()
        { 
            try
            {
                var result = await _apiDepartmentGetRepository.CallApi(EndPointUrl.GetDepartment, HttpMethod.Get);
                DepartmentData = result!.Data!;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task EditData()
        {
            await DefaultGrid!.EndEditAsync();
        }

        public async Task CancelEdit()
        {
            await DefaultGrid!.CloseEditAsync();
        }

        public async Task RowUpdating(RowUpdatingEventArgs<EmployeeGetResponseModel> args)
        {
            try
            {
                if (args.Action == SaveActionType.Added)
                {
                    var payload = await _apiRepository.CallApi(EndPointUrl.AddEmployee, HttpMethod.Post, new EmployeeAddRequestModel
                    {
                        EmpNum = args.Data.EmpNum,
                        EmpName = args.Data.EmpName,
                        DepNo = args.Data.DepNo,
                        HeadNo = args.Data.HeadNo,
                        HireDate = args.Data.HireDate,
                        PositionNo = args.Data.PositionNo,
                        Salary = args.Data.Salary,
                    });

                    if (!payload!.Result) throw new Exception(payload.Message);
                }

                if (args.Action == SaveActionType.Edited)
                {
                    var payload = await _apiRepository.CallApi(EndPointUrl.UpdateEmployee, HttpMethod.Patch, new EmployeeUpdateRequestModel
                    {
                        EmpNum = args.Data.EmpNum,
                        EmpName = args.Data.EmpName,
                        DepNo = args.Data.DepNo,
                        HeadNo = args.Data.HeadNo,
                        HireDate = args.Data.HireDate,
                        PositionNo = args.Data.PositionNo,
                        Salary = args.Data.Salary,
                    });

                    if (!payload!.Result) throw new Exception(payload.Message);
                }
            }
            catch (Exception ex)
            {
                args.Cancel = true;
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task RowDeleting(RowDeletingEventArgs<EmployeeGetResponseModel> args)
        {
            try
            {
                var payload = await _apiRepository.CallApi(EndPointUrl.DeleteEmployee, HttpMethod.Delete, new EmployeeDeleteRequestModel 
                { 
                    EmpNum = args.Datas[0].EmpNum 
                });

                if (!payload!.Result) throw new Exception(payload.Message);
            }
            catch (Exception ex)
            {
                args.Cancel = true;
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task ToolbarClickHandler(ClickEventArgs args)
        {
            try
            {
                if (args.Item.Id == "Grid_refresh")
                {
                    await GetEmployeeData();
                }

                if (args.Item.Id == "Grid_add")
                {
                    IsAddMode = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task OnGridCommandClicked(CommandClickEventArgs<EmployeeGetResponseModel> args)
        {
            try
            {
                if (args.CommandColumn.Type == CommandButtonType.Edit)
                {
                    IsAddMode = false;
                }
            }
            catch (Exception ex)
            {
                args.Cancel = true;
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }

        public async Task InitLookupData()
        {
            try
            {
                var dataDepartment = await _apiDepartmentGetRepository.CallApi(EndPointUrl.GetDepartment, HttpMethod.Get);

                if (dataDepartment!.Data != null)
                {
                    DepartmentDataLookUp.Clear();

                    foreach (var item in dataDepartment.Data)
                    {
                        if (!DepartmentDataLookUp.ContainsKey(item.DepNo!))
                        {
                            DepartmentDataLookUp.Add(item.DepNo!, item);
                        }
                    }
                }

                var dataJobPosition = await _apiJobPositionGetRepository.CallApi(EndPointUrl.GetPosition, HttpMethod.Get);

                if (dataJobPosition!.Data != null)
                {
                    PositionDataLookUp.Clear();

                    foreach (var item in dataJobPosition.Data)
                    {
                        if (!PositionDataLookUp.ContainsKey(item.PositionNo!))
                        {
                            PositionDataLookUp.Add(item.PositionNo!, item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await ToastObj!.ShowAsync();
            }
        }
    }
}
