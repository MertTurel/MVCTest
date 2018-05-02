using AutoMapper;
using DatabaseTest.Web.Models.Data;
using DatabaseTest.Web.Models.Domain;
using DatabaseTest.Web.Models.ViewModels;
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

        // GET: Post
        public ActionResult Index()
        {
            var allPosts = _postRepository.FindAll();
            
            return View(allPosts);
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

        public ActionResult MyPosts()
        {
            return View();
        }
    }
}