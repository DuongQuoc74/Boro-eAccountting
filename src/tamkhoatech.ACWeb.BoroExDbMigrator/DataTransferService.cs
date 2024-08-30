using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.BoroExDbMigrator.Models;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;

namespace tamkhoatech.ACWeb.BoroExDbMigrator
{
    public class DataTransferService
    {
        private readonly BoroExDBContext _boroExDbContext;
        private readonly ACWebDbContext _acWebDbContext;

        public DataTransferService(BoroExDBContext boroExDbContext, ACWebDbContext acWebDbContext)
        {
            _boroExDbContext = boroExDbContext;
            _acWebDbContext = acWebDbContext;
        }

        public void TransferNavigationNodes()
        {
            // Query all NavigationNode from BoroExDBContext
            var navigationNodes = _boroExDbContext.NavigationNodes.ToList();

            //map to NavigationNode in ACWebDbContext
            foreach (var navigationNode in navigationNodes)
            {
                _acWebDbContext.SYNavigationNodes.Add(new SYNavigationNode
                {
                    HelpUrl = navigationNode.LinkHDSD!=null ? navigationNode.LinkHDSD : "",
                    Icon = navigationNode.NodeImage!=null ? navigationNode.NodeImage : "",
                    LText = navigationNode.DisplayText0!=null ? navigationNode.DisplayText0 : "",
                    NodeLevel = navigationNode.NodeLevel!.Value,
                    ParentId = navigationNode.ParentID,
                    Order = navigationNode.NavigationNodeID,
                    Url = navigationNode.CommandToExecute!=null ? navigationNode.CommandToExecute : "",
                });
            }

            _acWebDbContext.SaveChanges(true);

            var nodes = _acWebDbContext.SYNavigationNodes.ToList();

            //map ParentId to corresponding node in ACWebDbContext by comparing with value in Order
            foreach (var node in nodes)
            {
                if (node.ParentId != null)
                {
                    var p = _acWebDbContext.SYNavigationNodes.FirstOrDefault(x => x.Order == node.ParentId);
                    if (node.ParentId != p?.Id)
                    {
                        node.ParentId = p?.Id;
                    }
                }
            }

            // Write to NavigationNode in ACWebDbContext
            _acWebDbContext.SaveChanges(true);
        }
    }
}
