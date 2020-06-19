using BusinessDto.Menu;
using DataAccess.Models;
using System.Collections.Generic;
 

namespace DataAccess.Repositories
{
   public interface IMenuRepository
    {
        long Add(Menu entity);
        List<Menu> GetMenus();
       
        //long DeleteMenu(Menu id);
        Menu DeleteMenu(long id);
  }
}
