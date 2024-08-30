using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tamkhoatech.ACWeb.BoroExDbMigrator.Models;

[Table("NavigationNode")]
public class NavigationNode
{
    [Key]
    public int NavigationNodeID { get; set; }

    public string DisplayText0 { get; set; }

    public string? DisplayText1 { get; set; }

    public string? NodeImage { get; set; }

    public string? CommandToExecute { get; set; }

    public int? NodeLevel { get; set; }

    public string? LanguageIDPrefix { get; set; }

    public bool? Hidden { get; set; }

    public int? ParentID { get; set; }

    public int? ParentID_SimpleUI { get; set; }

    public int? ThuTu { get; set; }

    public int? ThuTu_SimpleUI { get; set; }

    public string? NodeType { get; set; }

    public string? RibbonText0 { get; set; }

    public string? RibbonText1 { get; set; }

    public int? RibbonThuTu { get; set; }

    public bool? LoiTatHienThi { get; set; }

    public int? LoiTatThuTu { get; set; }

    public string? LinkHDSD { get; set; }
}
