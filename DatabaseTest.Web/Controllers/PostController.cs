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
            return View();
        }

        public ActionResult EditPost(int id)
        {
            var postToEdit = _postRepository.FindByKey(id);
            return View(postToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Post post)
        {
            if (ValidateRequest)
            {
                _postRepository.Update(post);
            }

            return View();
        }

        public ActionResult MyPosts()
        {
            return View();
        }
    }
}