using BookStore.Models.ViewModels;
using BookStore.Models.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetCatogires()
        {
            var categories = _categoryRepository.GetCategories();
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);
        }


        [Route("extra/list")]
        [HttpGet]
      
       public IActionResult GetCatogire(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var categories = _categoryRepository.GetCategorie(pageIndex, pageSize, keyword);
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);
        }


        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            CategoryModel categoryModel = new CategoryModel(category);

            return Ok(categoryModel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.AddCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }
}
