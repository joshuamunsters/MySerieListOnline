using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface ICategoryContext
    {
        List<Category> GetAllCategories();
    }
}