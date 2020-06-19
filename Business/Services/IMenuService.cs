using BusinessDto.Menu;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services
{
    public interface IMenuService
    {
        long Add(MenuDto dto);
        List<MenuDto> GetMenus();
        //long DeleteMenu(MenuDto id);
        MenuDto DeleteMenu(long id);
        //List<MenuDto> DeleteMenu(int id);
       
    }
}
