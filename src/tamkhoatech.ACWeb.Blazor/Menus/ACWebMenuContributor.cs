using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.IService;
using tamkhoatech.ACWeb.Localization;
using tamkhoatech.ACWeb.MultiTenancy;
using tamkhoatech.ACWeb.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace tamkhoatech.ACWeb.Blazor.Menus;

public class ACWebMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ACWebResource>();
        var administration = context.Menu.GetAdministration();

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        //else
        //{
        //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //}

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        var service = context.ServiceProvider.GetRequiredService<INavigationNodeService>();

        var nodes = await service.GetListAsync();
        var sidebarGroupName = "MenuGroup:Sidebar";

        context.Menu.AddGroup(
            new ApplicationMenuGroup(
                name: sidebarGroupName,
                displayName: l[sidebarGroupName]
            )
        );

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ACWebMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        var currentUser = context.ServiceProvider.GetService<ICurrentUser>();
        if (currentUser == null || !currentUser.IsAuthenticated) return;

        var root = new ApplicationMenuItem(
            sidebarGroupName,
            sidebarGroupName,
            "/",
            order: 1,
            groupName: sidebarGroupName
        );
        context.Menu.AddItem(root);

        var map = new Dictionary<int?, ApplicationMenuItem>();
        
        foreach (var item in nodes.OrderBy(m => m.NodeLevel))
        {
            var menuNode = new ApplicationMenuItem(
                item.LText,
                l[item.LText],
                item.Url,
                icon: item.Icon,
                order: item.Order,
                groupName: sidebarGroupName,
                elementId: item.Id.ToString()
            );
            map.Add(item.Id, menuNode);

            if (item.ParentId == null)
            {
                root.AddItem(map[item.Id]);
            } else
            {
                if (map.ContainsKey(item.ParentId))
                {
                    map[item.ParentId].AddItem(menuNode);
                }
                else
                {
                    Debug.WriteLine($"Node id:${item.Id} has parent id:${item.ParentId} but parent not found");
                }
            }
        }
    }

    private async Task ConfigureAbpAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ACWebResource>();

        context.Menu.AddGroup(
            new ApplicationMenuGroup(
                name: "Sidebar",
                displayName: l["Menu:Sidebar"]
            )
        );

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ACWebMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        var menu = new ApplicationMenuItem(
                "Menu",
                l["Menu"],
                icon: "fa fa-book", groupName: "Sidebar");
        context.Menu.AddItem(menu);

        //if (await context.IsGrantedAsync(ACWebPermissions.PhieuNhapKhoRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "PhieuNhapKho",
                l["Phiếu nhập kho"],
                url: "/phieunhapkho"));
        }
        //if (await context.IsGrantedAsync(ACWebPermissions.PhieuThuTienMatRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "PhieuThu",
                l["Phiếu thu tiền mặt"],
                url: "/phieuthu"));
        }
        //if (await context.IsGrantedAsync(ACWebPermissions.PhieuChiTienMatRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "PhieuChi",
                l["Phiếu chi tiền mặt"],
                url: "/phieuchi"));
        }
        //if (await context.IsGrantedAsync(ACWebPermissions.GiayBaoCoNHRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "GiayBaoCo",
                l["Giấy báo có (thu) của ngân hàng"],
                url: "/giaybaoco"));
        }
        //if (await context.IsGrantedAsync(ACWebPermissions.GiayBaoNoNHRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "GiayBaoNo",
                l["Giấy báo nợ (chi) của ngân hàng"],
                url: "/giaybaono"));
        }
        if (await context.IsGrantedAsync(ACWebPermissions.KhachHangRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "KhachHang",
                l["Danh sách khách hàng"],
                url: "/khachhang"));
        }
        if (await context.IsGrantedAsync(ACWebPermissions.ChiNhanhRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "ChiNhanh",
                l["Danh sách chi nhánh"],
                url: "/chinhanh"));
        }
        //if (await context.IsGrantedAsync(ACWebPermissions.KhoRead))
        {
            menu.AddItem(
            new ApplicationMenuItem(
                "Kho",
                l["Danh sách kho"],
                url: "/kho"));
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        //else
        //{
        //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //}

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);
    }
}
