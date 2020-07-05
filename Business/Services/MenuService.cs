using BusinessDto.Menu;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Business.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }
        public long Add(MenuDto dto)
        {
            var result = this._menuRepository.Add(new Menu
            {
                Adi = dto.Adi,
                Code = dto.Code,
                IsDeleted = false
            });
            return result;
        }
        public List<MenuDto> GetMenus()
        {
            var menuEntityList = _menuRepository.GetMenus();
            return menuEntityList.Select(r => new MenuDto
            {
                Adi = r.Adi,
                Code = r.Code,
                Id = r.Id
            }).ToList();
        }

        /// null dönüyor
        //public List<MenuDto> DeleteMenu(int id)
        //{
        //    var delete = _menuRepository.DeleteMenu(id)
        //    List<MenuDto> menus = new List<MenuDto>() { };
        //    var menu = menus.FirstOrDefault(a => a.Id == id);
        //    menus.Remove(menu);
        //    return (menus);
        //}

        public MenuDto DeleteMenu(long id)
        {
            var result = new MenuDto();
            var delete = _menuRepository.DeleteMenu(id);
            if (delete == null)
            {
                throw new Exception("id bulunamadı");
            }
            result.Id = delete.Id;
            result.Adi = delete.Adi;
            result.Code = delete.Code;
            result.IsDeleted = true;
            return result;
        }

        //public MenuDto DeleteMenu(long id)
        //{
        //    var delete = _menuRepository.DeleteMenu(id);
        //    if (delete == null)
        //    {
        //        throw new Exception("Id bulunamadı");
        //    }
        //    var result = new MenuDto()
        //    {
        //        Adi = delete.Adi,
        //        Id = delete.Id,
        //        Code = delete.Code,
        //        IsDeleted = delete.IsDeleted
        //    };
        //    return result;
        //}
    }
}
