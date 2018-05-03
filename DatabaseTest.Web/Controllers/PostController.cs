using AutoMapper;
using DatabaseTest.Web.Models.Data;
using DatabaseTest.Web.Models.Domain;
using DatabaseTest.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DatabaseTest.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        
        public PostController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public ActionResult Index()
        {
            var allPosts = _postRepository.FindAll();
            var allPostsViewModel = new HashSet<PostViewModel>();

            foreach (var item in allPosts)
            {
                var mappedItem = Mapper.Map<PostViewModel>(item);
                allPostsViewModel.Add(mappedItem);
            }

            return View(allPostsViewModel);
        }
        
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(PostViewModel postViewModel)
        {
            if (ValidateRequest)
            {
                var newPost = Mapper.Map<Post>(postViewModel);
                _postRepository.Insert(newPost);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditPost(int id)
        {
            var postToEdit = _postRepository.FindByKey(id);
            var postToEditPostViewModel = Mapper.Map<PostViewModel>(postToEdit);

            return View(postToEditPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(PostViewModel postViewModel)
        {
            if (ValidateRequest)
            {
                var postToUpdate = _postRepository.FindByKey(postViewModel.Id);
                postToUpdate = Mapper.Map(postViewModel, postToUpdate);
                _postRepository.Update(postToUpdate);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public JsonResult DeletePost(int id)
        {
            var postToDelete = _postRepository.FindByKey(id);
            postToDelete.IsDeleted = true;
            _postRepository.Update(postToDelete);

            return Json(Response.StatusCode, JsonRequestBehavior.AllowGet);
        }
    }
}