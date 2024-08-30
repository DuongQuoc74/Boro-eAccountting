using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Navigations;
using tamkhoatech.ACWeb.Constants;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic;

public partial class MainLayout : IDisposable
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ILocalStorageService _localStorage { get; set; }
    [Inject] private IMenuManager MenuManager { get; set; }
    [Inject] private IJSRuntime JSRunTime { get; set; }

    private bool IsCollapseShown { get; set; }

    public bool SidebarToggle { get; set; } = false;
    public bool hasRefreshed { get; set; } = false;

    public int TreeNodeCount { get; set; } = 0;

    public async Task Toggle()
    {
        SidebarToggle = !SidebarToggle;
    }
    //Hardcode
    public class TreeData2
    {
        public string NodeId { get; set; }
        public string NodeText { get; set; }
        public string IconCss { get; set; }
        public bool HasChild { get; set; }
        public string Pid { get; set; }
    }
    private List<TreeData2> Treedata = new List<TreeData2>();
    //Hardcode end
    protected override async Task OnInitializedAsync()
    {
        if (!hasRefreshed) 
        {

            NavigationManager.LocationChanged += OnLocationChanged;
            //Hardcode
            Treedata.Add(new TreeData2 { NodeId = "01", NodeText = "Quản lý hệ thống", IconCss = "icon-doc-text icon", HasChild = true });
            Treedata.Add(new TreeData2 { NodeId = "01-01", NodeText = "Khai báo các tham số hệ thống", IconCss = "icon-doc-text icon", HasChild = true, Pid = "01" });
            Treedata.Add(new TreeData2 { NodeId = "01-01-01", NodeText = "Danh sách chi nhánh", Pid = "01-01" });
            Treedata.Add(new TreeData2 { NodeId = "01-01-02", NodeText = "Danh sách các tham số", Pid = "01-01" });
            Treedata.Add(new TreeData2 { NodeId = "01-01-03", NodeText = "Danh sách màn hình nhập liệu", Pid = "01-01" });
            Treedata.Add(new TreeData2 { NodeId = "01-02", NodeText = "Cập nhật số dư đầu kỳ", IconCss = "icon-doc-text icon", HasChild = true, Pid = "01" });
            Treedata.Add(new TreeData2 { NodeId = "01-02-01", NodeText = "Cập nhật số dư đầu kỳ tài khoản", Pid = "01-02" });
            Treedata.Add(new TreeData2 { NodeId = "01-02-02", NodeText = "Cập nhật số công nợ dư đầu kỳ", Pid = "01-02" });

            Treedata.Add(new TreeData2 { NodeId = "02", NodeText = "Quản lý tiền", IconCss = "icon-doc-text icon", HasChild = true });
            Treedata.Add(new TreeData2 { NodeId = "02-01", NodeText = "Cập nhật số liệu", IconCss = "icon-doc-text icon", HasChild = true, Pid = "02" });
            Treedata.Add(new TreeData2 { NodeId = "02-01-01", NodeText = "Phiếu thu tiền mặt", Pid = "02-01" });
            Treedata.Add(new TreeData2 { NodeId = "02-01-02", NodeText = "Phiếu chi tiền mặt", Pid = "02-01" });
            Treedata.Add(new TreeData2 { NodeId = "02-01-03", NodeText = "Giấy báo có (thu) của ngân hàng", Pid = "02-01" });
            Treedata.Add(new TreeData2 { NodeId = "02-01-04", NodeText = "Giấy báo nợ (chi) của ngân hàng", Pid = "02-01" });
            Treedata.Add(new TreeData2 { NodeId = "02-01-05", NodeText = "Tự động tải thông tin sổ phụ ngân hàng", Pid = "02-01" });

            Treedata.Add(new TreeData2 { NodeId = "03", NodeText = "Quản lý mua hàng", IconCss = "icon-doc-text icon", HasChild = true });
            Treedata.Add(new TreeData2 { NodeId = "03-01", NodeText = "Cập nhật số liệu", IconCss = "icon-doc-text icon", HasChild = true, Pid = "03" });
            Treedata.Add(new TreeData2 { NodeId = "03-01-01", NodeText = "Phiếu nhập mua hàng", Pid = "03-01" });
            Treedata.Add(new TreeData2 { NodeId = "03-01-02", NodeText = "Phiếu nhập khẩu", Pid = "03-01" });
            Treedata.Add(new TreeData2 { NodeId = "03-01-03", NodeText = "Hóa đơn mua hàng (dịch vụ)", Pid = "03-01" });
            Treedata.Add(new TreeData2 { NodeId = "03-02", NodeText = "Quản lý danh sách nhà cung cấp", IconCss = "icon-doc-text icon", HasChild = true, Pid = "03" });
            Treedata.Add(new TreeData2 { NodeId = "03-02-01", NodeText = "Danh sách nhà cung cấp", Pid = "03-02" });

            Treedata.Add(new TreeData2 { NodeId = "04", NodeText = "Quản lý bán hàng", IconCss = "icon-doc-text icon", HasChild = true });
            Treedata.Add(new TreeData2 { NodeId = "04-01", NodeText = "Cập nhật số liệu", IconCss = "icon-doc-text icon", HasChild = true, Pid = "04" });
            Treedata.Add(new TreeData2 { NodeId = "04-01-01", NodeText = "Hóa đơn dịch vụ", Pid = "04-01" });        
            Treedata.Add(new TreeData2 { NodeId = "04-01-02", NodeText = "Hóa đơn bán hàng kiêm phiếu xuất kho", Pid = "04-01" });
            Treedata.Add(new TreeData2 { NodeId = "04-02", NodeText = "Quản lý danh sách khách hàng", IconCss = "icon-doc-text icon", HasChild = true, Pid = "04" });
            Treedata.Add(new TreeData2 { NodeId = "04-02-01", NodeText = "Danh sách khách hàng", Pid = "04-02" });

            Treedata.Add(new TreeData2 { NodeId = "05", NodeText = "Quản lý kho", IconCss = "icon-doc-text icon", HasChild = true });
            Treedata.Add(new TreeData2 { NodeId = "05-01", NodeText = "Cập nhật số liệu", IconCss = "icon-doc-text icon", HasChild = true, Pid = "05" });
            Treedata.Add(new TreeData2 { NodeId = "05-01-01", NodeText = "Phiếu nhập kho", Pid = "05-01" });
            Treedata.Add(new TreeData2 { NodeId = "05-01-02", NodeText = "Phiếu xuất kho nội bộ", Pid = "05-01" });
            Treedata.Add(new TreeData2 { NodeId = "05-01-03", NodeText = "Phiếu xuất điều chuyển kho", Pid = "05-01" });
            Treedata.Add(new TreeData2 { NodeId = "05-02", NodeText = "Quản lý danh sách vật tư kho", IconCss = "icon-doc-text icon", HasChild = true, Pid = "05" });
            Treedata.Add(new TreeData2 { NodeId = "05-02-01", NodeText = "Danh sách hàng hóa vật tư", Pid = "05-02" });

            Treedata.Add(new TreeData2 { NodeId = "06", NodeText = "Bút toán và sổ sách", IconCss = "icon-doc-text icon", HasChild = true });
            Treedata.Add(new TreeData2 { NodeId = "06-01", NodeText = "Cập nhật số liệu", IconCss = "icon-doc-text icon", HasChild = true, Pid = "06" });
            Treedata.Add(new TreeData2 { NodeId = "06-01-01", NodeText = "Phiếu kế toán", Pid = "06-01" });
        hasRefreshed = true;
        //await InitTreeDataAsync();
        }
    }
    private bool ShowSidebar { get; set; } = false;
    public async Task ToggleSidebar(Microsoft.AspNetCore.Components.ChangeEventArgs args)
    {
        if(args.Value != null)
        {
            ShowSidebar = (bool)args.Value;
            await _localStorage.SetItemAsync("ShowSidebar", ShowSidebar);
        }

    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (JSRunTime != null)
        {
            await JSRunTime.InvokeAsync<object>("changeWidthContentBySidebar");
            bool? showSidebar = await _localStorage.GetItemAsync<bool>("ShowSidebar");
            await JSRunTime.InvokeVoidAsync("document.documentElement.style.setProperty", "--checked", showSidebar); // set biến trong css
        }
    }
    public async Task SidebarCreated()
    {
        bool? showSidebar = await _localStorage.GetItemAsync<bool>("ShowSidebar");
        ShowSidebar = showSidebar.Value;
    }

    public void NodeClickedHandler(NodeClickEventArgs args)
    {
        if(!args.NodeData.HasChildren)
        {
            if (string.Equals(args.NodeData.Id, "01-01-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.ChiNhanh, true);
            }
            else if (string.Equals(args.NodeData.Id, "01-01-02", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.ThamSoHeThong, true);
            }            
            else if (string.Equals(args.NodeData.Id, "01-01-03", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.ManHinhNhapLieu, true);
            }        
            else if (string.Equals(args.NodeData.Id, "01-02-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.DuDauKyTk, true);
            }        
            else if (string.Equals(args.NodeData.Id, "01-02-02", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.DuDauKyCongNo, true);
            }          
            else if (string.Equals(args.NodeData.Id, "02-01-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuThu, true);
            }
            else if(string.Equals(args.NodeData.Id, "02-01-02", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuChi, true);
            }
            else if (string.Equals(args.NodeData.Id, "02-01-03", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.GiayBaoCo, true);
            }
            else if (string.Equals(args.NodeData.Id, "02-01-04", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.GiayBaoNo, true);
            }          
            else if (string.Equals(args.NodeData.Id, "02-01-05", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.TuDongTaiThongTinSoPhuNganHang, true);
            }
            else if(string.Equals(args.NodeData.Id, "03-01-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuNhapMuaHang, true);
            }
            else if (string.Equals(args.NodeData.Id, "03-01-02", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuNhapKhau, true);
            }
            else if (string.Equals(args.NodeData.Id, "03-01-03", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.HoaDonMuaHang, true);
            }      
            else if (string.Equals(args.NodeData.Id, "03-02-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.NhaCungCap, true);
            }
            else if (string.Equals(args.NodeData.Id, "04-01-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.HoaDonDichVu, true);
            }          
            else if (string.Equals(args.NodeData.Id, "04-01-02", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.HoaDonBanHangKiemPhieuXuatKho, true);
            }
            else if (string.Equals(args.NodeData.Id, "04-02-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.KhachHangg, true);
            }
            else if (string.Equals(args.NodeData.Id, "05-01-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuNhapKho, true);
            }
            else if (string.Equals(args.NodeData.Id, "05-01-02", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuXuatKho, true);
            }
            else if (string.Equals(args.NodeData.Id, "05-01-03", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuXuatDcKho, true);
            }
            else if (string.Equals(args.NodeData.Id, "05-02-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.HangHoaVatTu, true);
            }      
            else if (string.Equals(args.NodeData.Id, "06-01-01", StringComparison.OrdinalIgnoreCase))
            {
                NavigationManager.NavigateTo(SystemConstants.UrlPath.PhieuKeToan, true);
            }
        }
    }
    //Hardcode end
    private void ToggleCollapse()
    {
        IsCollapseShown = !IsCollapseShown;
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        IsCollapseShown = false;
        InvokeAsync(StateHasChanged);
    }

    public ExpandAction Expand { get; set; }  = ExpandAction.Click;

    public class TreeData
    {
        public string NodeId { get; set; }
        public string NodeText { get; set; }
        public string IconCss { get; set; }
        public bool HasChild { get; set; }
        public string ParentId { get; set; }
        public string ImageUrl { get; set; }
        public int NodeLevel { get; set; }
    }
    private List<TreeData> TreedataSource = new List<TreeData>();
    protected async Task InitTreeDataAsync()
    {
        Action<ApplicationMenuItem, string> buildTree = null;
        buildTree = (menuItem, parentId) =>
        {
            foreach (var item in menuItem.Items)
            {
                var url = "images/treeview/" + item.Icon;
                if (string.IsNullOrEmpty(parentId))
                {
                    TreedataSource.Add(new TreeData { NodeId = item.ElementId, NodeText = item.DisplayName, ImageUrl = url, NodeLevel = 1});
                }
                else
                {
                    var level = TreedataSource.Find(x => x.NodeId == parentId).ParentId == null?3:2;
                    TreedataSource.Add(new TreeData { NodeId = item.ElementId, NodeText = item.DisplayName, ImageUrl = url, ParentId = parentId, NodeLevel = level});
                    TreedataSource.Find(x => x.NodeId == parentId).HasChild = true;
                }
                TreeNodeCount++;
                buildTree(item, item.ElementId);
            }
        };

        var mainMenu = await MenuManager.GetMainMenuAsync();
        var sidebarMenu = mainMenu.FindMenuItem("MenuGroup:Sidebar");

        if (sidebarMenu != null)
        {
            buildTree(sidebarMenu, null);
        }
    }
}
