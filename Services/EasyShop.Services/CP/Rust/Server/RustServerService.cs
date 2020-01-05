using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Server;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.Rust.Server
{
    public class RustServerService : IRustServerService
    {
        private readonly EasyShopContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RustServerService> _logger;

        public RustServerService(EasyShopContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ILogger<RustServerService> logger)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _logger = logger;
        }

        public RustServer GetRustServerById(Guid serverId)
        {
            var server = _context.RustServers.Include(x => x.ServerMap).FirstOrDefault(x => x.Id == serverId);
            return server;
        }

        public IEnumerable<RustServer> GetAllShopServersById(Guid shopId)
        {
            return _context.RustServers
                .Include(x => x.Shop)
                .Include(x => x.ServerMap)
                .Where(x => x.Shop.Id == shopId)
                .OrderBy(x => x.Index);
        }

        public async Task<(RustEditServerResult, string)> UpdateAsync(RustShopViewModel model)
        {
            var shop = _context.Shops.FirstOrDefault(x => x.Id == Guid.Parse(model.Id));

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (shop is null)
                return (RustEditServerResult.NotFound, string.Empty);

            if (model.RustServerEditViewModel.Id is null)
            {
                var newServerId = Guid.NewGuid();
                var newServer = new RustServer
                {
                    Id = newServerId,
                    Name = model.RustServerEditViewModel.Name,
                    NameInShop = model.RustServerEditViewModel.NameInShop,
                    Index = model.RustServerEditViewModel.Index,
                    IpAddress = model.RustServerEditViewModel.IpAddress,
                    Port = model.RustServerEditViewModel.Port,
                    ShowInShop = model.RustServerEditViewModel.ShowInShop,
                    Shop = shop,
                    ServerMap = _context.RustServerMaps.First(x =>
                        x.Id == Guid.Parse(model.RustServerEditViewModel.MapId))
                };

                _context.RustServers.Add(newServer);
                await _context.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Server was successfully created. ServerId: {newServer.Id}");

                return (RustEditServerResult.Created, newServerId.ToString());
            }

            var server = _context.RustServers.FirstOrDefault(x => x.Id == Guid.Parse(model.RustServerEditViewModel.Id));

            if(server is null)
                return (RustEditServerResult.NotFound, String.Empty);

            server.Name = model.RustServerEditViewModel.Name;
            server.NameInShop = model.RustServerEditViewModel.NameInShop;
            server.Index = model.RustServerEditViewModel.Index;
            server.IpAddress = model.RustServerEditViewModel.IpAddress;
            server.Port = model.RustServerEditViewModel.Port;
            server.ShowInShop = model.RustServerEditViewModel.ShowInShop;
            server.Shop = shop;

            if (model.RustServerEditViewModel.MapId != null)
            {
                var map = _context.RustServerMaps.FirstOrDefault(x =>
                    x.Id == Guid.Parse(model.RustServerEditViewModel.MapId));
                server.ServerMap = map;
            }

            _context.RustServers.Update(server);
            await _context.SaveChangesAsync();

            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Server was successfully updated. ServerId: {server.Id}");

            return (RustEditServerResult.Updated, server.Id.ToString());
        }

        public async Task<bool> DeleteAsync(Guid serverId)
        {
            var server = _context.RustServers.FirstOrDefault(x => x.Id == serverId);

            if (server is null)
                return false;

            _context.RustServers.Remove(server);
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Server was successfully deleted. ServerId: {server.Id}");

            return true;
        }

        public Dictionary<string, string> GetAllMaps()
        {
            Dictionary<string, string> mapsDict = 
                new Dictionary<string, string>(_context.RustServerMaps
                        .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Type)));

            return mapsDict;
        }
    }
}
