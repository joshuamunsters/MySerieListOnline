using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class CategoryLogic
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IEnumerable<Category> Categories()
        {
            return categoryRepository.Categories();
        }

    }
}
