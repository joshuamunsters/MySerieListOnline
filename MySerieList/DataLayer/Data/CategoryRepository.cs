using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class CategoryRepository
    {
        ICategoryContext _categoryContext = new CategoryContext();
        public IEnumerable<Category> Categories()
        {
            return _categoryContext.GetAllCategories();
        }

    }
}
