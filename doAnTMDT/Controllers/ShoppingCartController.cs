using doAnTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doAnTMDT.Controllers
{
    public class ShoppingCartController : Controller
    {
        private PhoneDbContext _db = new PhoneDbContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddtoCart(int id)
        {
            var pro = _db.Phone.SingleOrDefault(s => s.PhoneID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return Redirect(Request.UrlReferrer.ToString());

        }
        public ActionResult AddtoCart_Detail(int id)
        {
            var pro = _db.Phone.SingleOrDefault(s => s.PhoneID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");

        }


        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            {
                ViewBag.nullCart = "Giỏ hàng của bạn đang trống! Bạn vui lòng thêm sản phẩm vào giỏ hàng nhé!!!";
                return View();
            }
            Cart cart = Session["Cart"] as Cart;
            if (cart.Items.Count() == 0)
            {
                ViewBag.nullCart = "Giỏ hàng của bạn đang trống! Bạn vui lòng thêm sản phẩm vào giỏ hàng nhé!!!";
                return View();
            }
            return View(cart);
        }

        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = Convert.ToInt32(form["ID_Product"]);
            int _quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, _quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_Cart_Item(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_item = cart.Total_Quantity_In_Cart();
            ViewBag.QuantityCart = total_item;

            return PartialView("BagCart");

        }
        public PartialViewResult BagCartItem()
        {
            if (Session["Cart"] == null)
            {
                ViewBag.nullCart = "Giỏ hàng trống...!";
                return PartialView();
            }
            Cart cart = Session["Cart"] as Cart;
            if (cart.Items.Count() == 0)
            {
                ViewBag.nullCart = "Giỏ hàng trống...!";
                return PartialView();
            }
            return PartialView(cart);

        }
        public ActionResult ThanhToan()
        {
            if (Session["Cart"] == null)
            {
                ViewBag.nullCart = "Giỏ hàng của bạn đang trống! Vui lòng thêm sản phẩm vào giỏ hàng bạn nhé!!!";
                return View();
            }
            Cart cart = Session["Cart"] as Cart;
            if (cart.Items.Count() == 0)
            {
                ViewBag.nullCart = "Giỏ hàng của bạn đang trống! Vui lòng thêm sản phẩm vào giỏ hàng bạn nhé!!!" ;
                return View();
            }

            return View(cart);
        }
    }
}