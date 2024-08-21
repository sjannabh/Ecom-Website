using Ecom_Website.DataAccess.Models;
using Ecom_Website.DataAccess.Models.Mongo;
using Ecom_Website.DataAccess.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;


namespace Ecom_Website.Web.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly SignInManager<IdentityUser> _signInManager;


        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7046/api/");

        }
        [HttpGet]
        public ActionResult Index(string name = "usb", int count = 10)
        {
            StreamReader category = new StreamReader("C:/Repos/Ecom-website/Ecom-Website.Web/wwwroot/Data/HomePageData.json");
            StreamReader hero = new StreamReader("C:/Repos/Ecom-website/Ecom-Website.Web/wwwroot/Data/Hero.json");

            var categoryjson = category.ReadToEnd();
            var herojson = hero.ReadToEnd();

            var categoryList = JsonSerializer.Deserialize<List<CategoryGrid>>(categoryjson);
            var heroList = JsonSerializer.Deserialize<List<HeroModel>>(herojson);

            HomeViewModel HGVM = new HomeViewModel();
            HGVM.heroList = heroList;
            HGVM.CategoryGrid = categoryList;
            ProductCarouselViewModel PCVM = new ProductCarouselViewModel();


            if (_signInManager.IsSignedIn(User))
            {
                PCVM.Title = "Recommendations Only For You";
                var user = _httpClient.GetFromJsonAsync<User>(_httpClient.BaseAddress + "User/getByEmail/" + User.Identity?.Name).Result;

                List<Product> userProducts = new List<Product>();
                foreach (var item in user.ProductRecommendations)
                {
                    var product = _httpClient.GetFromJsonAsync<Product>(_httpClient.BaseAddress + "Product/getById/" + item).Result;
                    userProducts.Add(product);
                }
                PCVM.ProductList = userProducts;
            }
            else
            {
                PCVM.Title = "Top Recommended Products";
                //PCVM.ProductList = _httpClient.GetFromJsonAsync<List<Product>>(_httpClient.BaseAddress + "Product/getByName/" + name + "/" + count).Result;
                PCVM.ProductList = _httpClient.GetFromJsonAsync<List<Product>>(_httpClient.BaseAddress + "Product/getByName?name=" + name + "&count=" + count).Result;
            }

            HGVM.Carousel = PCVM;

            return View(HGVM);

        }


        public ActionResult SearchbyProductName(string SearchString)
        {

            List<Product> userProducts = _httpClient.GetFromJsonAsync<List<Product>>(_httpClient.BaseAddress + "Product/getByName?name=" + SearchString).Result;
            return View(userProducts);
        }

        [HttpGet]
        public ActionResult ProductDescription(string productId)
        {

            ProductDescriptionViewModel prodDescVM = new ProductDescriptionViewModel();
            prodDescVM.Product = _httpClient.GetFromJsonAsync<Product>(_httpClient.BaseAddress + "Product/getById/" + productId).Result;

            List<Product> productList = new List<Product>();
            foreach (var item in prodDescVM.Product.ProductRecommendations)
            {
                var productObj = _httpClient.GetFromJsonAsync<Product>(_httpClient.BaseAddress + "Product/getById/" + item).Result;
                productList.Add(productObj);
            }

            ProductCarouselViewModel productCarouselViewModel = new ProductCarouselViewModel();

            var reviews = _httpClient.GetFromJsonAsync<List<Review>>(_httpClient.BaseAddress + "Review/getByProductId/" + productId).Result;

            productCarouselViewModel.Title = "Similar Products You May Like";


            productCarouselViewModel.CarouselType = "type1";
            productCarouselViewModel.ProductList = productList;
            prodDescVM.ProductCarousel = productCarouselViewModel;
            prodDescVM.Reviews = reviews;

            return View(prodDescVM);
        }

        [HttpPost]
        public ActionResult ProductAddedToCart(LineItem lineItem)
        {
            string res = "";
            int cartCount = 0;
            if (_signInManager.IsSignedIn(User))
            {
                var userEmail = User.Identity?.Name;
                User userObj = _httpClient.GetFromJsonAsync<User>(_httpClient.BaseAddress + "User/getByEmail/" + userEmail).Result;
                var userId = userObj.UserId;

                // chaeck if there is any cart for this user
                Cart cartObj = _httpClient.GetFromJsonAsync<Cart>(_httpClient.BaseAddress + "Cart/getByUserId?UserId=" + userId).Result;
                if (cartObj == null)
                {
                    cartObj = new Cart();
                    cartObj.UserId = userId;
                    cartObj.LineItems = new List<LineItem>();
                    cartObj.LineItems.Add(lineItem);
                    foreach (var item in cartObj.LineItems)
                    {
                        cartObj.Total += item.Quantity * item.Price;
                        cartObj.SubTotal += item.Quantity * item.Price;
                        cartObj.Count += item.Quantity;
                    }

                    var newcontent = new StringContent(JsonSerializer.Serialize<Cart>(cartObj), Encoding.UTF8, "application/json");

                    var response = _httpClient.PostAsync(_httpClient.BaseAddress + "Cart/create", newcontent).Result;
                }
                else
                {
                    bool isPresent = false;

                    foreach (var item in cartObj.LineItems)
                    {
                        if (item.ProductId == lineItem.ProductId)
                        {
                            item.Quantity = item.Quantity + lineItem.Quantity;
                            isPresent = true;
                            break;
                        }
                    }

                    if (!isPresent)
                    {
                        cartObj.LineItems.Add(lineItem);
                    }

                    int count = 0;
                    double subtotal = 0;
                    double total = 0;
                    foreach (var item in cartObj.LineItems)
                    {
                        total += item.Quantity * item.Price;
                        subtotal += item.Quantity * item.Price;
                        count += item.Quantity;
                    }

                    cartObj.SubTotal = subtotal;
                    cartObj.Total = total;
                    cartObj.Count = count;
                }
                var updatecontent = new StringContent(JsonSerializer.Serialize<Cart>(cartObj), Encoding.UTF8, "application/json");
                var updatedresponse = _httpClient.PutAsync(_httpClient.BaseAddress + "Cart/update?cartId=" + cartObj.CartId, updatecontent).Result;
                cartCount = cartObj.Count;

            }

            return Json(new { res = "Product added succesfully!", cartCount = cartCount });
        }

        public IActionResult GetCartCount()
        {
            int count = 0;
            if (_signInManager.IsSignedIn(User))
            {
                User userObj = _httpClient.GetFromJsonAsync<User>(_httpClient.BaseAddress + "User/getByEmail/" + User.Identity?.Name).Result;

                Cart cartObj = _httpClient.GetFromJsonAsync<Cart>(_httpClient.BaseAddress + "Cart/getByUserId?UserId=" + userObj.UserId).Result;

                count = cartObj.Count;
            }
            return Json(new { cartCount = count });
        }

        public IActionResult GoCart()
        {
            Cart cartObj = new Cart();
            if (_signInManager.IsSignedIn(User))
            {
                User userObj = _httpClient.GetFromJsonAsync<User>(_httpClient.BaseAddress + "User/getByEmail/" + User.Identity?.Name).Result;

                cartObj = _httpClient.GetFromJsonAsync<Cart>(_httpClient.BaseAddress + "Cart/getByUserId?UserId=" + userObj.UserId).Result;

            }

            return View(cartObj);
        }

        //public IActionResult DeleteItemFromCart(string prodcutId)
        //{
        //    return Json(new );
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
