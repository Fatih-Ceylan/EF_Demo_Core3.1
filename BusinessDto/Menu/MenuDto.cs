using System.Collections.Generic;

namespace BusinessDto.Menu
{
    public class MenuDto
    {
        public long Id { get; set; }
        public string Adi { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public List<MenuDto> MenuDtoList { get; set; }
        public MenuDto()
        {
            MenuDtoList = new List<MenuDto>();
        }

    }
}
