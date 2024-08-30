using tamkhoatech.ACWeb.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace tamkhoatech.ACWeb.Permissions;

public class ACWebPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ACWebPermissions.GroupName);
        //Define your own permissions here. Example:
        myGroup.AddPermission(ACWebPermissions.PhieuThuTienMatCreate, L("Permission:PhieuThuTienMatCreate"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.PhieuThuTienMatEdit, L("Permission:PhieuThuTienMatEdit"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.PhieuThuTienMatDelete, L("Permission:PhieuThuTienMatDelete"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.PhieuThuTienMatRead, L("Permission:PhieuThuTienMatRead"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);

        myGroup.AddPermission(ACWebPermissions.PhieuChiTienMatCreate, L("Permission:PhieuChiTienMatCreate"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.PhieuChiTienMatEdit, L("Permission:PhieuChiTienMatEdit"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.PhieuChiTienMatDelete, L("Permission:PhieuChiTienMatDelete"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.PhieuChiTienMatRead, L("Permission:PhieuChiTienMatRead"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);

        myGroup.AddPermission(ACWebPermissions.GiayBaoCoNHCreate, L("Permission:GiayBaoCoNHCreate"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.GiayBaoCoNHEdit, L("Permission:GiayBaoCoNHEdit"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.GiayBaoCoNHDelete, L("Permission:GiayBaoCoNHDelete"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.GiayBaoCoNHRead, L("Permission:GiayBaoCoNHRead"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);

        myGroup.AddPermission(ACWebPermissions.GiayBaoNoNHCreate, L("Permission:GiayBaoNoNHCreate"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.GiayBaoNoNHEdit, L("Permission:GiayBaoNoNHEdit"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.GiayBaoNoNHDelete, L("Permission:GiayBaoNoNHDelete"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.GiayBaoNoNHRead, L("Permission:GiayBaoNoNHRead"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);

        myGroup.AddPermission(ACWebPermissions.ChiNhanhCreate, L("Permission:ChiNhanhCreate"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.ChiNhanhEdit, L("Permission:ChiNhanhEdit"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.ChiNhanhDelete, L("Permission:ChiNhanhDelete"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.ChiNhanhRead, L("Permission:ChiNhanhRead"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);

        myGroup.AddPermission(ACWebPermissions.KhachHangCreate, L("Permission:KhachHangCreate"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.KhachHangEdit, L("Permission:KhachHangEdit"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.KhachHangDelete, L("Permission:KhachHangDelete"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
        myGroup.AddPermission(ACWebPermissions.KhachHangRead, L("Permission:KhachHangRead"), Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ACWebResource>(name);
    }
}
