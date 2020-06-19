using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private eTicaretDBContext _context;
        public MenuRepository()
        {
            _context = new eTicaretDBContext();
        }
        public long Add(Menu entity)
        {
            var result = _context.Menu.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
        public List<Menu> GetMenus()
        {
            return _context.Menu.Where(r => r.IsDeleted == false).ToList();
        }
        //public long DeleteMenu(Menu id)
        //{
        //    var delete = _context.Menu.Find(id);
        //    if (delete != null) _context.Menu.Remove(delete);
        //    _context.SaveChanges();
        //    return id.Id;
        //}
        public Menu DeleteMenu(long id)
        {
            var delete = _context.Menu.FirstOrDefault(a =>a.Id == id);
            if (delete != null)
            {
                _context.Menu.Remove(delete);
            }
            _context.SaveChanges();
            return delete;
        }
    }
}
